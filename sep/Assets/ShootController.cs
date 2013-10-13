using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {
    private ShootWithBullet scriptSWB;
	// Use this for initialization
	void Start () {
        scriptSWB = transform.GetComponent<ShootWithBullet>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startShoot(GameObject monster, GameObject towerWeapon, string towerTyp) {
        
        switch (towerTyp) {
            
            case "bulletTower":
                
                scriptSWB.shoot(monster, towerWeapon);
                break;
            default:
                break;

        }

      
    }
}
