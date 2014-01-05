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
	private NPCShooter upgradeComp;
	private TowerSelect temp;
    private bool isHoverGUI = false;
    private Rect rect = new Rect(10, 10, 110, 50);

	public GameObject currentTower;
	public bool buyMode = true;
	public bool upMode = false;
	
	public float xPositionInPercent;
	public float yPositionInPercent;
	
	private float xPositionModifier;
	private float yPositionModifier;
	
	public GUIStyle customGuiStyle;
	public int fontSize;
	
	public float scaleInPercent = 100.0f;
	private float scale;
	private int buttonSize;
	private CPUComputeTimeController controller;


    public GameObject TowerBullet { get { return towerBullet; } set { towerBullet = value; } }
    public GameObject TowerLaser { get { return towerLaser; } set { towerLaser = value; } }
    public GameObject TowerGatling { get { return towerGatling; } set { towerGatling = value; } }
    public GameObject TowerFourBurrelGun { get { return towerFourBurrelGun; } set { towerFourBurrelGun = value; } }
    public GameObject TowerNova { get { return towerNova; } set { towerNova = value; } }
    public GameObject TowerDetector { get { return towerDetector; } set { towerDetector = value; } }


    void OnGUI() {	
		int currentHeight = Screen.height;
		int currentWidth = Screen.width;
		buttonSize = (int) (currentWidth/16.5f*scale);
		int xPosition = (int)(currentWidth*xPositionModifier);
		int yPosition = (int)(currentHeight*yPositionModifier);
		yPosition = currentHeight-(yPosition+buttonSize);
		
        if (buyMode) {			
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
            //TowerDetector
            TowerButtonCreate(towerNova, "TN", xPosition + buttonSize * 5, yPosition, controller);
		
            isHoverGUI = rect.Contains( Event.current.mousePosition );
        }
		
		if (upMode) {
			UpdateButtonsCreate(currentTower,xPosition, yPosition);
		}
		GUI.skin.textField.fontSize = fontSize;
		switch (GUI.tooltip)
		{
		case "TBlabel" : GUI.TextField (new Rect (xPosition+buttonSize*0,yPosition-80*scale,120*scale,80*scale), "Cheap Tower \nCost: " +towerBullet.GetComponent<TowerCost>().CPUTimeCost); break;
		case "TLlabel" : GUI.TextField (new Rect (xPosition+buttonSize*1,yPosition-80*scale,120*scale,80*scale), "Laser Tower \nCost: "+towerLaser.GetComponent<TowerCost>().CPUTimeCost); break;
		case "TGlabel" : GUI.TextField (new Rect (xPosition+buttonSize*2,yPosition-80*scale,120*scale,80*scale), "Fast Firing Tower \nCost: " +towerGatling.GetComponent<TowerCost>().CPUTimeCost); break;
		case "T4label" : GUI.TextField (new Rect (xPosition+buttonSize*3,yPosition-80*scale,120*scale,80*scale), "Tower with four Barrels \nCost: " +towerFourBurrelGun.GetComponent<TowerCost>().CPUTimeCost); break;
		case "TDlabel" : GUI.TextField (new Rect (xPosition+buttonSize*4,yPosition-80*scale,120*scale,80*scale), "Tower that identifies \npackages \nCost: " +towerDetector.GetComponent<TowerCost>().CPUTimeCost ); break;
		case "TNlabel" : GUI.TextField (new Rect (xPosition+buttonSize*5,yPosition-80*scale,120*scale,80*scale), "Tower that damages all \nenemies within range \nCost: " +towerNova.GetComponent<TowerCost>().CPUTimeCost); break;
		case "DMGlabel" : GUI.TextField (new Rect (xPosition+buttonSize*0,yPosition-80*scale,120*scale,80*scale), "Increases damage");break;
		case "RNGlabel" : GUI.TextField (new Rect (xPosition+buttonSize*1,yPosition-80*scale,120*scale,80*scale), "Incrases Range"); break;
		case "SPDlabel" : GUI.TextField (new Rect (xPosition+buttonSize*2,yPosition-80*scale,120*scale,80*scale), "Increases Attack Speed"); break;
		case "SLLlabel" : GUI.TextField (new Rect (xPosition+buttonSize*3,yPosition-80*scale,120*scale,80*scale), "Sells"); break;
		}
	}
	
	void TowerButtonCreate(GameObject tower, string name, int x, int y, CPUComputeTimeController controller ){

		int cost = tower.GetComponent<TowerCost>().CPUTimeCost;
		string costString = cost.ToString();
		int time = controller.CPUTime;
		if (time<cost) {
				GUI.enabled = false;
		}
		GUI.skin.label.fontSize = fontSize;
		GUI.Label(new Rect(x+((int)buttonSize*0.65f),y-5,buttonSize/2,buttonSize/3),name);
		GUI.Label(new Rect(x+((int)buttonSize*0.65f),y+(int)(buttonSize-fontSize*1.6f),buttonSize/2,buttonSize/3),costString);
		if (GUI.Button(new Rect(x, y, buttonSize, buttonSize),new GUIContent("",(name+"label")), customGuiStyle)) {

						
            controller.CPUTime -= cost;
            selectedTower = (GameObject)Instantiate(tower, Vector3.zero, Quaternion.identity);	
        }

		GUI.enabled = true;
	}
	
	void Start () {
		controller = GetComponent<CPUComputeTimeController>();
		yPositionModifier = yPositionInPercent/100.0f;
		xPositionModifier = xPositionInPercent/100.0f;
		scale = scaleInPercent/100.0f;
		fontSize =(int)(9.0f*scale);
	}
	
	void UpdateButtonsCreate(GameObject tower, int x, int y){
		if(false) {GUI.enabled = false;}

		GUI.skin.label.fontSize = fontSize;
		GUI.Label(new Rect(x+((int)buttonSize*0.65f),y-buttonSize,buttonSize/2,buttonSize/3),"DMG");
		if (GUI.Button(new Rect(x, y-buttonSize, buttonSize, buttonSize), new GUIContent("",("DMGlabel")), customGuiStyle)) {
			//Increase DMG
			upgradeComp =tower.GetComponent<NPCShooter>();
			if(upgradeComp.HasDamage) upgradeComp.WeaponDamage += 1;
		}
		GUI.enabled = true;

		if(false) {GUI.enabled = false;}
		
		GUI.skin.label.fontSize = fontSize;
		GUI.Label(new Rect(x+buttonSize+((int)buttonSize*0.65f),y-buttonSize,buttonSize/2,buttonSize/3),"RNG");
		if (GUI.Button(new Rect(x+buttonSize, y-buttonSize, buttonSize, buttonSize), new GUIContent("",("RNGlabel")), customGuiStyle)) {
			//increase Range
			upgradeComp =tower.GetComponent<NPCShooter>();
			if(upgradeComp.HasRadius) upgradeComp.BiggerRadius(1);
		}
		GUI.enabled = true;

		if(false) {GUI.enabled = false;}
		
		GUI.skin.label.fontSize = fontSize;
		GUI.Label(new Rect(x+buttonSize*2+((int)buttonSize*0.65f),y-buttonSize,buttonSize/2,buttonSize/3),"SPD");
		if (GUI.Button(new Rect(x+buttonSize*2, y-buttonSize, buttonSize, buttonSize), new GUIContent("",("SPDlabel")), customGuiStyle)) {
			//increase Speed
			upgradeComp =tower.GetComponent<NPCShooter>();
            // TODO: Creates an exception if the script hasnt been started!
			//if(upgradeComp.HasDelay) tower.GetComponent<NPCShooter>().Delay /= 1.1f;
		}
		GUI.enabled = true;

		if(false) {GUI.enabled = false;}
		
		GUI.skin.label.fontSize = fontSize;
		GUI.Label(new Rect(x+buttonSize*3+((int)buttonSize*0.65f),y-buttonSize,buttonSize/2,buttonSize/3),"SLL");
		if (GUI.Button(new Rect(x+buttonSize*3, y-buttonSize, buttonSize, buttonSize), new GUIContent("",("SLLlabel")), customGuiStyle)) {
			//sell tower
			//controller.CPUTime +=	tower.GetComponent<TowerCost>().CPUTimeCost;		
			//Destroy(tower);
		GUI.enabled = true;
	}
	}}