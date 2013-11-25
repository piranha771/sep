using UnityEngine;
using System.Collections;

public class WeaponBullet : MonoBehaviour, IMakeDamage, IWeapon {

    private GameObject bullet;
    private NPCHealth npcHealth;
    private GameObject npc;
    [SerializeField]
    private int weaponDamage = 15;
    private Quaternion startRotation;
    private PrefabSource prefabSource;
    [SerializeField]
    private float delay;
    private float shootDelay;
    [SerializeField]
    private string npcTag;

    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
    public float Delay { get { return delay; } set { delay = value; } }

    // Use this for initialization
    void Start() {
        npc = null;
        GameObject gameController = GameObject.Find("GameController");
        prefabSource = gameController.GetComponent<PrefabSource>();
        startRotation = transform.rotation;
    }
    
    // Update is called once per frame
    void Update() {
        
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
    /// Initialize single shoot to one NPC
    /// </summary>
    /// <param name="npcEnemy"> target </param>
    /// <param name="towerWeapon"> weapon typ </param>
    /// 
    public void Shoot(GameObject npc) {
  
        this.npc = npc;
    }
    private void ShootAtNPC() {
      
        bullet = prefabSource.Bullet();
        npcHealth = npc.GetComponent<NPCHealth>();

        GameObject bulletCopy = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
        bulletCopy.SetActive(true);

        Shoot script_b = bulletCopy.GetComponent<Shoot>();
        script_b.SetStart(transform, npc.transform, transform.gameObject);

    }

    /// <summary>
    /// Initialize shooting stop
    /// </summary>
    public void StopShooting() {
        npc = null;
        transform.rotation = startRotation;
        transform.parent.GetComponent<NPCShooter>().ShootPermission = true;
    }

    /// <summary>
    /// Make damage on target. Target must have Health-Script with tackeDamage-Method.
    /// </summary>
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
