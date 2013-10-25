using UnityEngine;
using System.Collections;

public class ShootWithBullet : MonoBehaviour {

    private GameObject bullet;

	// Use this for initialization
	void Start () {
        bullet = GameObject.Find("Bullet");
        bullet.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void shoot(GameObject monster, GameObject towerWeapon) {

        GameObject bullet_2 = (GameObject)Instantiate(bullet, towerWeapon.transform.position, towerWeapon.transform.rotation);
        bullet_2.SetActive(true);

        Shoot script_b = bullet_2.GetComponent<Shoot>();
        script_b.set_start(towerWeapon.transform, monster.transform);

    }
}
