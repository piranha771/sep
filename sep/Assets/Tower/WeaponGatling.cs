using UnityEngine;
using System.Collections;

public class WeaponGatling : MonoBehaviour, IMakeDamage, IWeapon {
    private GameObject bullet;
    private NPCHealth npcHealth;
    private GameObject npc;
    [SerializeField]
    private int weaponDamage = 0;
    private Quaternion startRotation;
    private PrefabSource prefabSource;
    private GatlingControll gatlingControll;
    private float rotateSpeed;
    private bool npcState = true;
    private NPCShooter shootNPC ;
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
        GameObject gameController = GameObject.Find("GameController");
        prefabSource = gameController.GetComponent<PrefabSource>();
        gatlingControll = transform.GetComponentInChildren<GatlingControll>();
        shootNPC = transform.parent.GetComponent<NPCShooter>();

        startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if ((delay > 0.045f && delay < 0.21f) && npcState) shootNPC.Delay = delay + 0.01f;
        if (gatlingControll.RotateSpeed > 0f && npcState) gatlingControll.RotateSpeed = gatlingControll.RotateSpeed - 0.1f;
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
        npcState = false;
        bullet = prefabSource.Bullet();
        npcHealth = npc.GetComponent<NPCHealth>();
        GameObject bulletCopy = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
        bulletCopy.SetActive(true);
        Shoot script_b = bulletCopy.GetComponent<Shoot>();
        script_b.SetStart(transform, npc.transform, transform.gameObject);
        if (gatlingControll.RotateSpeed < 15f)gatlingControll.RotateSpeed = gatlingControll.RotateSpeed + 1f;
        if (delay <= 0.22f && delay > 0.05f) delay = delay - 0.01f;
    }

    public void StopShooting() {
        npcState = true;
        npc = null;
        //transform.rotation = startRotation;
        transform.parent.GetComponent<NPCShooter>().ShootPermission = true;
    }

    public void MakeDamage() {
        npcHealth.TakeDamage(weaponDamage);
    }

    void triggerShoot() {

        shootDelay -= Time.deltaTime;
        if (shootDelay < 0 && npc != null) {
            ShootAtNPC();
            shootDelay = delay;

        }
    }
}
