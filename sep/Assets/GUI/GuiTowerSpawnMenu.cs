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

    private GameObject selectedTower;
    private bool isHoverGUI = false;
    private Rect rect = new Rect(10, 10, 110, 50);

    public GameObject TowerBullet { get { return towerBullet; } set { towerBullet = value; } }
    public GameObject TowerLaser { get { return towerLaser; } set { towerLaser = value; } }
    public GameObject TowerGatling { get { return towerGatling; } set { towerGatling = value; } }
    public GameObject TowerFourBurrelGun { get { return towerFourBurrelGun; } set { towerFourBurrelGun = value; } }
    public GameObject TowerNova { get { return towerNova; } set { towerNova = value; } }


    void OnGUI() {

        if (GUI.Button(new Rect(10, 10, 50, 50), "TB")) {
            selectedTower = towerBullet;
        }

        if (GUI.Button(new Rect(60, 10, 50, 50), "TL")) {
            selectedTower = towerLaser;
        }

        if (GUI.Button(new Rect(110, 10, 50, 50), "TG")) {
            selectedTower = towerGatling;
        }

        if (GUI.Button(new Rect(160, 10, 50, 50), "T4B")) {
            selectedTower = towerFourBurrelGun;
        }

        if (GUI.Button(new Rect(210, 10, 50, 50), "TN")) {
            selectedTower = towerNova;
        }

        isHoverGUI = rect.Contains(Event.current.mousePosition);
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