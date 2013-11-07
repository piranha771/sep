using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {
    private ShootWithBullet scriptSWB;
    private ShootWithLine scriptSWL;
    private ShootWithBurrelGun scriptSWG;
	// Use this for initialization
	void Start () {
        scriptSWB = transform.GetChild(0).GetComponent<ShootWithBullet>();
        scriptSWL = transform.GetChild(0).GetComponent<ShootWithLine>();
        scriptSWG = transform.GetChild(0).GetComponent<ShootWithBurrelGun>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// Direct shoot command to right shoot script
    /// </summary>
    /// <param name="npcEnemy"> target </param>
    /// <param name="towerWeapon"> weapon </param>
    /// <param name="towerTyp"> weapon typ </param>
    public void StartShoot(GameObject npcEnemy, GameObject towerWeapon, string towerTyp) {
        switch (towerTyp) {
            
            case "bulletTower":
                
                scriptSWB.Shoot(npcEnemy, towerWeapon);
                break;

            case "lineBulletTower":
                scriptSWL.Shoot(npcEnemy, towerWeapon);
                break;
            case "gatlingTower":
                scriptSWG.Shoot(npcEnemy, towerWeapon);
                break;
            default:
                break;

        }

     
      
    }

    public void StopShooting(string towerTyp) {

        switch (towerTyp) {

            case "bulletTower":
                scriptSWB.StopShooting();
              
                break;

            case "lineBulletTower":
                scriptSWL.StopShooting();
                break;
            case "gatlingTower":
                scriptSWG.StopShooting();
                break;
            default:
                break;

        }
    }
}
