using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShootMonster : MonoBehaviour {

    private float attackDelay = 0;
    private float delay = 1;
    private int monster_on_target = 1;

    private GameObject bullet;
    private GameObject targetMonster;
    private GameObject towerWeapon;


	// Use this for initialization
	void Start () {
        Debug.Log("hallo");
        
        bullet = GameObject.Find("Bullet");
        bullet.SetActive(false);
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
                
                GameObject bullet_2 = (GameObject)Instantiate(bullet, towerWeapon.transform.position, towerWeapon.transform.rotation);
                bullet_2.SetActive(true);

                Shoot script_b = bullet_2.GetComponent<Shoot>();
                script_b.set_start(towerWeapon.transform, monster.transform);

                attackDelay = delay;

                

            }
        }

    }

}
