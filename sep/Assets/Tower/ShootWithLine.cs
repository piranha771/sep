using UnityEngine;
using System.Collections;

public class ShootWithLine : MonoBehaviour {
    LineRenderer lineBullet;
    private Health npcHealth;
    private GameObject npc;
    private int weaponDamage = 1;
    private Quaternion startRotation;

    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }

	// Use this for initialization
	void Start () {
        startRotation = transform.rotation;
        lineBullet = transform.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (npc == null) stopShooting();
	}

    public void shoot(GameObject monster, GameObject towerWeapon){
            npc = monster;
            npcHealth = monster.GetComponent<Health>();
            lineBullet.SetPosition(0, towerWeapon.transform.position);
            lineBullet.SetPosition(1, monster.transform.position);
            npcHealth.tackeDamage(weaponDamage);
       
    }

    public void stopShooting() {
        transform.rotation = startRotation;
        lineBullet.SetPosition(0, transform.position);
        lineBullet.SetPosition(1, transform.position);
    }

}
