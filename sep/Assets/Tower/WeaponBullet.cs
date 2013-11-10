using UnityEngine;
using System.Collections;

public class WeaponBullet : MonoBehaviour, IMakeDamage, IWeapon {

    private GameObject bullet;
    private Health npcHealth;
    private GameObject npc;
    private int weaponDamage = 15;
    private Quaternion startRotation;
    private PrefabSource prefabSource;

    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
	// Use this for initialization
	void Start () {
        GameObject gameController = GameObject.Find("GameController");
        prefabSource = gameController.GetComponent<PrefabSource>();
        startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (npc == null) StopShooting();
	}
    /// <summary>
    /// Initialize single shoot to one NPC
    /// </summary>
    /// <param name="npcEnemy"> target </param>
    /// <param name="towerWeapon"> weapon typ </param>
    public void Shoot(GameObject npcEnemy, GameObject towerWeapon) {
        bullet = prefabSource.Bullet();
        npc = npcEnemy;
        npcHealth = npcEnemy.GetComponent<Health>();
        GameObject bulletCopy = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
        bulletCopy.SetActive(true);

        Shoot script_b = bulletCopy.GetComponent<Shoot>();
        script_b.SetStart(transform, npcEnemy.transform, transform.gameObject); 
        
        }
    /// <summary>
    /// Initialize shooting stop
    /// </summary>
    public void StopShooting() {
        transform.rotation = startRotation;
    }

    /// <summary>
    /// Make damage on target. Target must have Health-Script with tackeDamage-Method.
    /// </summary>
    public void MakeDamage() {
        npcHealth.tackeDamage(weaponDamage);
    }
}
