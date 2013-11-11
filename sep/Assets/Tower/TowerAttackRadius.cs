using UnityEngine;
using System.Collections;

public class TowerAttackRadius : MonoBehaviour {


    private BoxCollider colliderTower;
    private GameObject towerRadius;
    private PrefabSource prefabSource;

	// Use this for initialization
	void Start () {
    
        colliderTower = transform.parent.GetComponent<BoxCollider>();
        GameObject gameCOntroller = GameObject.Find("GameController");
        prefabSource = gameCOntroller.GetComponent<PrefabSource>();
	
        
	}
	
	// Update is called once per frame
	void Update () {
        isMouseOnMeClicked();
	}
    /// <summary>
    /// Update radius renderer. Is equal to colliderbox size
    /// </summary>
    public void UpdateRadius() {
        if (towerRadius == null) towerRadius = (GameObject)Instantiate(prefabSource.RadiusRenderer());
        towerRadius.transform.position = transform.position;
        Vector3 workScale = new Vector3(0,0,0);
        workScale.y = colliderTower.size.z;
        workScale.x = colliderTower.size.x;
        towerRadius.transform.localScale = (workScale/2);
       
    }

    void isMouseOnMeClicked() {
		
		GuiTowerSpawnMenu guiMenu = GameObject.Find("BackGround").GetComponent<GuiTowerSpawnMenu>();
    
        if(Input.GetMouseButtonDown(0)){
            
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "tower" && hit.transform == transform)) {
                UpdateRadius();
                towerRadius.SetActive(true);
				guiMenu.buyMode =false;
				guiMenu.upMode = true;
            } else {
                if(towerRadius != null) towerRadius.SetActive(false);
				guiMenu.buyMode =true;
				guiMenu.upMode = false;
            }
        }

    }
}
