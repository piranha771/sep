using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {
    private ShootWithBullet scriptSWB;
    private ShootWithLine scriptSWL;
	// Use this for initialization
	void Start () {
        scriptSWB = transform.GetComponent<ShootWithBullet>();
        scriptSWL = transform.GetComponent<ShootWithLine>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startShoot(GameObject monster, GameObject towerWeapon, string towerTyp) {
        switch (towerTyp) {
            
            case "bulletTower":
                
                scriptSWB.shoot(monster, towerWeapon);
                break;

            case "lineBulletTower":
                scriptSWL.shoot(monster, towerWeapon);
                break;
            default:
                break;

        }

     
      
    }

    public void stopShooting(string towerTyp) {

        switch (towerTyp) {

            case "bulletTower":

              
                break;

            case "lineBulletTower":
                scriptSWL.stopShooting();
                break;
            default:
                break;

        }
    }
}
