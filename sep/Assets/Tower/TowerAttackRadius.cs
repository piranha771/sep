using UnityEngine;
using System.Collections;

public class TowerAttackRadius : MonoBehaviour {


    private BoxCollider colliderTower;
    private GameObject towerRadius;

	// Use this for initialization
	void Start () {
    
        colliderTower = transform.GetComponent<BoxCollider>();
        GameObject workRadius = GameObject.Find("TowerRadius");
        towerRadius = (GameObject) Instantiate(workRadius);
        towerRadius.SetActive(false);
        updateRadius();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// Update radius renderer. Is equal to colliderbox size
    /// </summary>
    public void updateRadius() {
        towerRadius.transform.position = transform.position;
        towerRadius.transform.localScale = (colliderTower.size/2);
        towerRadius.SetActive(true);
    }
}
