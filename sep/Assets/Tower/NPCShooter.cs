using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NPCShooter : MonoBehaviour {

    private float attackDelay = 0;
    [SerializeField]
    private float delay = 1;
    [SerializeField]
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
	
    // Use this for initialization
	void Start () {
        towerWeapon = transform.FindChild("TowerWeapon").gameObject;
        scriptWeapon = (IWeapon)towerWeapon.GetComponent(typeof(IWeapon));
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
        scriptWeapon.StopShooting();
    }

    void AttackMonster(Collider monster) {
        attackDelay -= Time.deltaTime;
        if (monster == null)
            targetMonster = null;
        if (attackDelay < 0 && monster != null) {
            if (monster.gameObject.tag == attackTag) {
                scriptWeapon.Shoot(monster.gameObject);
                attackDelay = delay;
            }
        }
    }
}
