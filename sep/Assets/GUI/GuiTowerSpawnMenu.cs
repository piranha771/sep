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


    public GameObject TowerBullet { get { return towerBullet; } set { towerBullet = value; } }
    public GameObject TowerLaser { get { return towerLaser; } set { towerLaser = value; } }
    public GameObject TowerGatling { get { return towerGatling; } set { towerGatling = value; } }
    public GameObject TowerFourBurrelGun { get { return towerFourBurrelGun; } set { towerFourBurrelGun = value; } }
    public GameObject TowerNova { get { return towerNova; } set { towerNova = value; } }
    public GameObject TowerDetector { get { return towerDetector; } set { towerDetector = value; } }


    void OnGUI() {
		
		if (buyMode) {
            CPUComputeTimeController controller = GetComponent<CPUComputeTimeController>();
		    TowerCost costTable = GameObject.Find("CPU").GetComponent<TowerCost>();		
		    int time = controller.CPUTime;

            if (GUI.Button(new Rect(10, 10, 50, 50), "TB") && time >= towerBullet.GetComponent<TowerCost>().CPUTimeCost) {
                controller.CPUTime -= towerBullet.GetComponent<TowerCost>().CPUTimeCost;
                selectedTower = towerBullet;
            }

            if (GUI.Button(new Rect(60, 10, 50, 50), "TL") && time >= towerLaser.GetComponent<TowerCost>().CPUTimeCost) {
                controller.CPUTime -= towerLaser.GetComponent<TowerCost>().CPUTimeCost;
                selectedTower = towerLaser;
            }

            if (GUI.Button(new Rect(110, 10, 50, 50), "TG") && time >= towerGatling.GetComponent<TowerCost>().CPUTimeCost) {
                controller.CPUTime -= towerGatling.GetComponent<TowerCost>().CPUTimeCost;
                selectedTower = towerGatling;
            }

            if (GUI.Button(new Rect(160, 10, 50, 50), "T4B") && time >= towerFourBurrelGun.GetComponent<TowerCost>().CPUTimeCost) {
                controller.CPUTime -= towerFourBurrelGun.GetComponent<TowerCost>().CPUTimeCost;
                selectedTower = towerFourBurrelGun;
            }

            if (GUI.Button(new Rect(210, 10, 50, 50), "TN") && time >= towerNova.GetComponent<TowerCost>().CPUTimeCost) {
                controller.CPUTime -= towerNova.GetComponent<TowerCost>().CPUTimeCost;
                selectedTower = towerNova;
            }

            if (GUI.Button(new Rect(260, 10, 50, 50), "TD") && time >= towerDetector.GetComponent<TowerCost>().CPUTimeCost) {
                controller.CPUTime -= towerDetector.GetComponent<TowerCost>().CPUTimeCost;
                selectedTower = towerDetector;
            }
 
            isHoverGUI = rect.Contains( Event.current.mousePosition );
        }
		
		if (upMode) {
			 if (GUI.Button(new Rect(10, 60, 50, 50), "DMG")) {
				//TODO
		}
			 if (GUI.Button(new Rect(60, 60, 50, 50), "RNG")) {
				//TODO
		}
			 if (GUI.Button(new Rect(110, 60, 50, 50), "SPD")) {
				//TODO
		}
			 if (GUI.Button(new Rect(160, 60, 50, 50), "SLL")) {
				//TODO
		}
			
		}
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