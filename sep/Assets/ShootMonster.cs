using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShootMonster : MonoBehaviour {

    private float attackDelay = 0;
    [SerializeField]
    private float delay = 1;
    private int monster_on_target = 1;
    [SerializeField]
    private string towerTyp;

    
    private GameObject targetMonster;
    private GameObject towerWeapon;
    private ShootController scriptSC;


    public float Delay { get { return delay; } set { delay = value; } }

    public string TowerTyp { get { return towerTyp; } set { towerTyp = value; } }
	// Use this for initialization
	void Start () {


        scriptSC = transform.GetComponent<ShootController>();
        towerWeapon = transform.FindChild("TowerWeapon").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if (targetMonster != null) {
            

            towerWeapon.transform.LookAt(targetMonster.transform);
            attack_monster(targetMonster.transform.collider);

        }

	}

    void OnTriggerStay(Collider monster) {
      
        if (targetMonster == null) {

            targetMonster = monster.gameObject;

        }

    }

    void OnTriggerExit(Collider monster) {

        targetMonster = null;

    }

    void attack_monster(Collider monster) {

        attackDelay -= Time.deltaTime;
        if (monster == null)
            targetMonster = null;
        if (attackDelay < 0 && monster != null) {
            if (monster.gameObject.tag == "EnemyMonster") {


                scriptSC.startShoot(monster.gameObject, towerWeapon, towerTyp);
               

                attackDelay = delay;

                

            }
        }

    }

}
