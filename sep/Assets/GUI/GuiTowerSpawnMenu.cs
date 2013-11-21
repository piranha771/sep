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
	
	public float scale;


    public GameObject TowerBullet { get { return towerBullet; } set { towerBullet = value; } }
    public GameObject TowerLaser { get { return towerLaser; } set { towerLaser = value; } }
    public GameObject TowerGatling { get { return towerGatling; } set { towerGatling = value; } }
    public GameObject TowerFourBurrelGun { get { return towerFourBurrelGun; } set { towerFourBurrelGun = value; } }
    public GameObject TowerNova { get { return towerNova; } set { towerNova = value; } }
    public GameObject TowerDetector { get { return towerDetector; } set { towerDetector = value; } }


    void OnGUI() {
		
		if (buyMode) {
            CPUComputeTimeController controller = GetComponent<CPUComputeTimeController>();
			
			int currentHeight = Screen.height;
			int currentWidth = Screen.width;
			int xPosition = (int)(currentWidth*xPositionModifier);
			int yPosition = (int)(currentHeight*yPositionModifier);
			
			
			//TowerBullet
			TowerButtonCreate(towerBullet,"TB",xPosition,yPosition,controller);			
			
			//TowerLaser
			TowerButtonCreate(towerLaser,"TL",50+xPosition,yPosition,controller);
			
			//TowerGatling
			TowerButtonCreate(towerGatling,"TG",100+xPosition,yPosition,controller);			
			
			//TowerFourBarrel
			TowerButtonCreate(towerFourBurrelGun,"T4",150+xPosition,yPosition,controller);		
			
			//TowerNova
			TowerButtonCreate(towerNova,"TN",200+xPosition,yPosition,controller);		
			
			//TowerDetector
			TowerButtonCreate(towerDetector,"TD",250+xPosition,yPosition,controller);
		
 
            isHoverGUI = rect.Contains( Event.current.mousePosition );
        }
		
		if (upMode) {
			
			//DMG
			if(false) {GUI.enabled = false;}
			
			 if (GUI.Button(new Rect(10, 60, 50, 50), "DMG")) {
				//TODO
			}
			GUI.enabled = true;
			
			//RNG
			if(false) {GUI.enabled = false;}
			
			 if (GUI.Button(new Rect(60, 60, 50, 50), "RNG")) {
				//TODO
			}
			GUI.enabled = true;
			
			//SPD
			if(false) {GUI.enabled = false;}
			
			 if (GUI.Button(new Rect(110, 60, 50, 50), "SPD")) {
				//TODO
			}
			GUI.enabled = true;
			
			//SLL
			if(false) {GUI.enabled = false;}
			
			 if (GUI.Button(new Rect(160, 60, 50, 50), "SLL")) {
				//TODO
			}
			GUI.enabled = true;
		}
	}
	
	void TowerButtonCreate(GameObject tower, string name, int x, int y, CPUComputeTimeController controller ){
		int cost = tower.GetComponent<TowerCost>().CPUTimeCost;
		int time = controller.CPUTime;
		if (time<cost) {
				GUI.enabled = false;
			}
            if (GUI.Button(new Rect(x, y, 50, 50), name)) {
						
                controller.CPUTime -= cost;
                selectedTower = tower;
            }
			GUI.enabled = true;
	}
	
	void Start () {
		yPositionModifier = yPositionInPercent/100.0f;
		xPositionModifier = xPositionInPercent/100.0f;
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