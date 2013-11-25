using UnityEngine;
using System.Collections;

public class GuiTowerSpawnMenu : MonoBehaviour {

    [SerializeField]
    private GameObject towerBullet;
    [SerializeField]
    private GameObject towerLaser;
    [SerializeField]
    private GameObject towerGatling;
    [SerializeField]
    private GameObject towerFourBurrelGun;
    [SerializeField]
    private GameObject towerNova;
    [SerializeField]
    private GameObject towerDetector;

    private GameObject selectedTower;
    private bool isHoverGUI = false;
    private Rect rect = new Rect(10, 10, 110, 50);
	
	public bool buyMode = true;
	public bool upMode = false;
	
	public float xPositionInPercent;
	public float yPositionInPercent;
	
	private float xPositionModifier;
	private float yPositionModifier;
	
	public GUIStyle customGuiStyle;
	
	public float scaleInPercent = 100.0f;
	private float scale;
	private int buttonSize;


    public GameObject TowerBullet { get { return towerBullet; } set { towerBullet = value; } }
    public GameObject TowerLaser { get { return towerLaser; } set { towerLaser = value; } }
    public GameObject TowerGatling { get { return towerGatling; } set { towerGatling = value; } }
    public GameObject TowerFourBurrelGun { get { return towerFourBurrelGun; } set { towerFourBurrelGun = value; } }
    public GameObject TowerNova { get { return towerNova; } set { towerNova = value; } }
    public GameObject TowerDetector { get { return towerDetector; } set { towerDetector = value; } }


    void OnGUI() {
		int currentHeight = Screen.height;
		int currentWidth = Screen.width;
		int xPosition = (int)(currentWidth*xPositionModifier);
		int yPosition = (int)(currentHeight*yPositionModifier);
		buttonSize = (int) (currentWidth/16.5f*scale);
		if (buyMode) {
            CPUComputeTimeController controller = GetComponent<CPUComputeTimeController>();
			
			//TowerBullet
			TowerButtonCreate(towerBullet,"TB",xPosition+buttonSize*0,yPosition,controller);			
			//TowerLaser
			TowerButtonCreate(towerLaser,"TL",xPosition+buttonSize*1,yPosition,controller);
			//TowerGatling
			TowerButtonCreate(towerGatling,"TG",xPosition+buttonSize*2,yPosition,controller);			
			//TowerFourBarrel
			TowerButtonCreate(towerFourBurrelGun,"T4",xPosition+buttonSize*3,yPosition,controller);		
			//TowerDetector
			TowerButtonCreate(towerDetector,"TD",xPosition+buttonSize*4,yPosition,controller);
		
 
            isHoverGUI = rect.Contains( Event.current.mousePosition );
        }
		
		if (upMode) {
			//DMG
			UpdateButtonCreate("DMG",xPosition+buttonSize*0, yPosition);
			//RNG
			UpdateButtonCreate("RNG",xPosition+buttonSize*1, yPosition);
			//SPD
			UpdateButtonCreate("SPD",xPosition+buttonSize*2, yPosition);
			//SLL
			UpdateButtonCreate("$$$",xPosition+buttonSize*3, yPosition);
		}
	}
	
	void TowerButtonCreate(GameObject tower, string name, int x, int y, CPUComputeTimeController controller ){
		int cost = tower.GetComponent<TowerCost>().CPUTimeCost;
		int time = controller.CPUTime;
		if (time<cost) {
				GUI.enabled = false;
			}
            if (GUI.Button(new Rect(x, y, buttonSize, buttonSize), name, customGuiStyle)) {
						
                controller.CPUTime -= cost;
                selectedTower = tower;
            }
			GUI.enabled = true;
	}
	
	void Start () {
		yPositionModifier = yPositionInPercent/100.0f;
		xPositionModifier = xPositionInPercent/100.0f;
		scale = scaleInPercent/100.0f;
	}
	
	void UpdateButtonCreate(string name, int x, int y){
		if(false) {GUI.enabled = false;}
			
			 if (GUI.Button(new Rect(x, y, buttonSize, buttonSize), name, customGuiStyle)) {
				//TODO
			}
			GUI.enabled = true;
	}
 
    void Update() {
        if (Input.GetMouseButtonDown(0) && !isHoverGUI) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;
 
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "spawnarea") {
                Vector3 towerPosition = hit.point;
                towerPosition.y += 0.4f;
                if (selectedTower != null) Instantiate(selectedTower, towerPosition, Quaternion.identity);
                    selectedTower = null;
            }
        }
    }
}