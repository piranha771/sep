using UnityEngine;
using System.Collections;

public class ShootWithBullet : MonoBehaviour {

    private GameObject bullet;
    private Health npcHealth;
    private GameObject npc;
    private int weaponDamage = 15;
    private Quaternion startRotation;

    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
	// Use this for initialization
	void Start () {
        bullet = GameObject.Find("Bullet");
        bullet.SetActive(false);
        startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (npc == null) stopShooting();
	}

    public void shoot(GameObject monster, GameObject towerWeapon) {
        npc = monster;
        npcHealth = monster.GetComponent<Health>();
        GameObject bullet_2 = (GameObject)Instantiate(bullet, towerWeapon.transform.position, towerWeapon.transform.rotation);
        bullet_2.SetActive(true);

        Shoot script_b = bullet_2.GetComponent<Shoot>();
        script_b.set_start(towerWeapon.transform, monster.transform);
        npcHealth.tackeDamage(weaponDamage);
    }

    public void stopShooting() {
        transform.rotation = startRotation;
    }
}
