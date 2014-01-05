using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NPCShooter : MonoBehaviour {

    private bool shootPermission;
    private string attackTag;    
    private GameObject targetMonster;
    
    private IWeapon scriptWeapon;
    private LinkedList<GameObject> attackList;

    [SerializeField]
    private GameObject towerWeapon;
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
        scriptWeapon = (IWeapon)towerWeapon.GetComponent(typeof(IWeapon));
        shootPermission = true;
        attackList = new LinkedList<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (attackList.Count != 0 && shootPermission == true) {
             AttackMonster(attackList.Last.Value);
        }
	}

    void OnTriggerEnter(Collider npc) {
        if (npc.GetComponent<NPCStateController>() == null) return;
        attackList.AddLast(npc.gameObject);
    }

    void OnTriggerExit(Collider npc) {
        if((attackList.Contains(npc.gameObject))){
            attackList.Remove(npc.gameObject);
                scriptWeapon.StopShooting();
            
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
