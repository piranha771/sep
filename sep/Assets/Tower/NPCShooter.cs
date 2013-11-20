using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NPCShooter : MonoBehaviour {

    private float attackDelay = 0;
    [SerializeField]
    private float delay = 1;
    private int monster_on_target = 1;
    [SerializeField]
    private string towerTyp;
    
    private bool shootPermission;

    
    private GameObject targetMonster;
    private GameObject towerWeapon;
    private IWeapon scriptWeapon;

    /// <summary>
    /// Setter and getter for delay of attack.  
    /// </summary>
    public float Delay { get { return delay; } set { delay = value; } }

    /// <summary>
    /// Setter and getter for tower typ. Not in use. 
    /// Delete?
    /// </summary>
    public string TowerTyp { get { return towerTyp; } set { towerTyp = value; } }

    /// <summary>
    /// Setter and getter fpr damage of weapon. Send method to IShootWith.
    /// </summary>
    public int WeaponDamage { get { return scriptWeapon.WeaponDamage; } set { scriptWeapon.WeaponDamage = value; } }
    /// <summary>
    /// Setter and getter for shoot permission. 
    /// </summary>
    public bool ShootPermission { get { return shootPermission; } set { shootPermission = value; } }
	// Use this for initialization
	void Start () {
        towerWeapon = transform.FindChild("TowerWeapon").gameObject;
        scriptWeapon = (IWeapon)towerWeapon.GetComponent(typeof(IWeapon));
        shootPermission = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (targetMonster != null && shootPermission == true) {
             AttackMonster(targetMonster);
        }
	}

    void OnTriggerEnter(Collider npc) {
          if(targetMonster == null)  targetMonster = npc.gameObject;
    }

    void OnTriggerExit(Collider monster) {
        if (monster.gameObject.GetInstanceID() == targetMonster.GetInstanceID()) {
            targetMonster = null;
            
            scriptWeapon.StopShooting();
        }
    }

    void AttackMonster(GameObject npc) {
        shootPermission = false;
        scriptWeapon.Shoot(npc.gameObject);
    }
       
}
