using UnityEngine;
using System.Collections;

public class WeaponBurrelGun : MonoBehaviour, IWeapon {
    private SingleBurrel[] burrelsScripts;
    private Quaternion startRotation;
    private GameObject npc;
    [SerializeField]
    private float delay;
    private float shootDelay;
    [SerializeField]
    private string npcTag;
    
   public int WeaponDamage { get { return burrelsScripts[0].WeaponDamage; } set { 
       foreach (SingleBurrel item in burrelsScripts)
	{
        item.WeaponDamage = value;
	}; } }
   public float Delay { get { return delay; } set { delay = value; } }
	// Use this for initialization
	void Start () {
        npc = null;
        burrelsScripts = transform.GetComponentsInChildren<SingleBurrel>();
        startRotation = transform.rotation;
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

    public void Shoot(GameObject npc) {
        this.npc = npc;
    }

    public void ShootAtNPC() {
        foreach (SingleBurrel item in burrelsScripts) {
            item.Shoot(npc, transform.gameObject);
        }
    }

    public void StopShooting() {
        npc = null;
        transform.rotation = startRotation;
        transform.parent.GetComponent<NPCShooter>().ShootPermission = true;
    }

    void triggerShoot() {

        shootDelay -= Time.deltaTime;
        if (shootDelay < 0 && npc != null) {
            ShootAtNPC();
            shootDelay = delay;

        }
    }
}
