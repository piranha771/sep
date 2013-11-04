using UnityEngine;
using System.Collections;

public class TowerAttackRadius : MonoBehaviour {


    private BoxCollider colliderTower;
    private GameObject towerRadius;
    private PrefabSource prefabSource;

	// Use this for initialization
	void Start () {
    
        colliderTower = transform.GetComponent<BoxCollider>();
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
    public void updateRadius() {
        towerRadius = (GameObject)Instantiate(prefabSource.getRadiusRenderer());
        towerRadius.transform.position = transform.position;
        towerRadius.transform.localScale = (colliderTower.size/2);
       
    }

    void isMouseOnMeClicked() {
    
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "tower" && hit.transform == transform)) {
                updateRadius();
                towerRadius.SetActive(true);
            } else {
                towerRadius.SetActive(false);
            }
        }

    }
}
