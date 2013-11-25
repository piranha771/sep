using UnityEngine;
using System.Collections;

public class WeaponLaser : MonoBehaviour, IWeapon {
    LineRenderer lineBullet;
    private NPCHealth npcHealth;
    private GameObject npc;
    [SerializeField]
    private int weaponDamage = 1;
    private Quaternion startRotation;
    [SerializeField]
    private float delay;
    private float shootDelay;
    [SerializeField]
    private string npcTag;

    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
    public float Delay { get { return delay; } set { delay = value; } }

	// Use this for initialization
	void Start () {
        npc = null;
        startRotation = transform.rotation;
        lineBullet = transform.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (npc == null) {
            StopShooting();
        } else if (npc.tag == npcTag) {

            transform.LookAt(npc.transform);
            triggerShoot();

        } else {
            StopShooting();
        }
	}
    /// <summary>
    /// Initialize single shoot
    /// </summary>
    /// <param name="monster">target</param>
    /// <param name="towerWeapon">weapon</param>


    public void Shoot(GameObject npc) {
        this.npc = npc;
    }


    public void ShootAtNPC(){
            npcHealth = npc.GetComponent<NPCHealth>();
            lineBullet.enabled = true;
            lineBullet.SetPosition(0, transform.position);
            lineBullet.SetPosition(1, npc.transform.position);
            npcHealth.TakeDamage(weaponDamage);

       
    }

    public void StopShooting() {
        transform.rotation = startRotation;
        lineBullet.enabled = false;
        npc = null;
        transform.parent.GetComponent<NPCShooter>().ShootPermission = true;
        //lineBullet.SetPosition(0, transform.position);
        //lineBullet.SetPosition(1, transform.position);
    }

    void triggerShoot() {

        shootDelay -= Time.deltaTime;
        if (shootDelay < 0 && npc != null) {
            ShootAtNPC();
            shootDelay = delay;

        }
    }

}
