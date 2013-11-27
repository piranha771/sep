using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NPCShooter : MonoBehaviour {

    private bool shootPermission;
    private string attackTag;    
    private GameObject targetMonster;
    private GameObject towerWeapon;
    private IWeapon scriptWeapon;

    [SerializeField]
    private bool hasDelay;
    [SerializeField]
    private bool hasRadius;
    [SerializeField]
    private bool hasDamage;
    
    /// <summary>
    /// Setter and getter for weapon delay. Also how often shoot it.
    /// </summary>
    public float Delay { get { return scriptWeapon.Delay; } set { scriptWeapon.Delay = value; } }
   
    public string AttackTag { get { return attackTag; } set { attackTag = value; } }

    public bool HasDelay { get { return hasDelay; } set { hasDelay = value; } }
    public bool HasRadius { get { return hasRadius; } set { hasRadius = value; } }
    public bool HasDamage { get { return hasDamage; } set { hasDamage = value; } }

    /// <summary>
    /// Setter and getter for damage of weapon. Send method to IShootWith.
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
        if (npc.GetComponent<NPCStateController>() == null) return;
        if (targetMonster == null)  targetMonster = npc.gameObject;
    }

    void OnTriggerExit(Collider npc) {
        if((targetMonster != null)){
            if (npc.gameObject.GetInstanceID() == targetMonster.GetInstanceID()) {

                targetMonster = null;
                scriptWeapon.StopShooting();
            }
        }
    }

    void AttackMonster(GameObject npc) {
        shootPermission = false;
        scriptWeapon.Shoot(npc.gameObject);
    }

    public void BiggerRadius(int value) {
        Vector3 radius = new Vector3(0,0,0);
        radius = transform.GetComponent<BoxCollider>().size;
        radius.x += value;
        radius.z += value;
        transform.GetComponent<BoxCollider>().size = radius;
    }
       
}
