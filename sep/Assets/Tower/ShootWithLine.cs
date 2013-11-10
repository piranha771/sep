using UnityEngine;
using System.Collections;

public class ShootWithLine : MonoBehaviour, IShootWith {
    LineRenderer lineBullet;
    private Health npcHealth;
    private GameObject target;
    private int weaponDamage = 1;
    private Quaternion startRotation;

    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }

	// Use this for initialization
	void Start () {
        startRotation = transform.rotation;
        lineBullet = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null) StopShooting();
	}

    /// <summary>
    /// Initialize single shoot
    /// </summary>
    /// <param name="npc">target</param>
    /// <param name="towerWeapon">weapon</param>
    public void Shoot(GameObject npc){
            target = npc;
            npcHealth = npc.GetComponent<Health>();
            lineBullet.SetPosition(0, transform.position);
            lineBullet.SetPosition(1, npc.transform.position);
            npcHealth.tackeDamage(weaponDamage);
       
    }

    public void StopShooting() {
        transform.rotation = startRotation;
        lineBullet.SetPosition(0, transform.position);
        lineBullet.SetPosition(1, transform.position);
    }

}
