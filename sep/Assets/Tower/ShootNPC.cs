using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShootNPC : MonoBehaviour {

    private float attackDelay = 0;
    [SerializeField]
    private float delay = 1;
    private int monster_on_target = 1;
    [SerializeField]
    private string towerTyp;
   
    private GameObject targetMonster;
    private GameObject towerWeapon;
    private IShootWith shootController;

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
    public int WeaponDamage { get { return shootController.WeaponDamage; } set { shootController.WeaponDamage = value; } }
	// Use this for initialization
	void Start () {
        towerWeapon = transform.FindChild("TowerWeapon").gameObject;
        shootController = (IShootWith)towerWeapon.GetComponent(typeof(IShootWith));
	}
	
	// Update is called once per frame
	void Update () {
        if (targetMonster != null) {
            towerWeapon.transform.LookAt(targetMonster.transform);
             AttackMonster(targetMonster.transform.collider);
        }
	}

    void OnTriggerStay(Collider monster) {
    
        if (targetMonster == null) {
            targetMonster = monster.gameObject;
        }
    }

    void OnTriggerExit(Collider monster) {
        targetMonster = null;
        shootController.StopShooting();
    }

    void AttackMonster(Collider monster) {

        attackDelay -= Time.deltaTime;
        if (monster == null)
            targetMonster = null;
        if (attackDelay < 0 && monster != null) {
            if (monster.gameObject.tag == "EnemyMonster") {
                shootController.Shoot(monster.gameObject);
                attackDelay = delay;
            }
        }
    }
}
