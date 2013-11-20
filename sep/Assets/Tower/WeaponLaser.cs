using UnityEngine;
using System.Collections;

public class WeaponLaser : MonoBehaviour, IWeapon {
    LineRenderer lineBullet;
    private NPCHealth npcHealth;
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

        if (npc == null) StopShooting();
	}
    /// <summary>
    /// Initialize single shoot
    /// </summary>
    /// <param name="monster">target</param>
    /// <param name="towerWeapon">weapon</param>
    public void Shoot(GameObject monster){
            npc = monster;
            npcHealth = monster.GetComponent<NPCHealth>();
            lineBullet.enabled = true;
            lineBullet.SetPosition(0, transform.position);
            lineBullet.SetPosition(1, monster.transform.position);
            npcHealth.TakeDamage(weaponDamage);
       
    }

    public void StopShooting() {
        transform.rotation = startRotation;
        lineBullet.enabled = false;
        //lineBullet.SetPosition(0, transform.position);
        //lineBullet.SetPosition(1, transform.position);
    }

}
