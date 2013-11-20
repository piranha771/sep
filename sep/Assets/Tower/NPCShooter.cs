using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NPCShooter : MonoBehaviour {

    private float attackDelay = 0;
    [SerializeField]
    private float delay = 1;
    
    private bool shootPermission;
    private string attackTag;    
    private GameObject targetMonster;
    private GameObject towerWeapon;
    private IWeapon scriptWeapon;

    public float Delay { get { return delay; } set { delay = value; } }
    public string AttackTag { get { return attackTag; } set { attackTag = value; } }

    /// <summary>
    /// Setter and getter fpr damage of weapon. Send method to IShootWith.
    /// </summary>
    public int WeaponDamage { get { return scriptWeapon.WeaponDamage; } set { scriptWeapon.WeaponDamage = value; } }

    /// <summary>
    /// Setter and getter for shoot permission. 
    /// </summary>
    public bool ShootPermission { get { return shootPermission; } set { shootPermission = value; } }
	// Use this for initialization

	
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
