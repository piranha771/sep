using UnityEngine;
using System.Collections;

public class ShootWithBullet : MonoBehaviour {

    private GameObject bullet;
    private Health npcHealth;
    private GameObject npc;
    private int weaponDamage = 15;
    private Quaternion startRotation;
    private PrefabSource prefabSource;
    private GameObject gameController;
    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController");
        prefabSource = gameController.GetComponent<PrefabSource>();
        startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (npc == null) stopShooting();
	}
    /// <summary>
    /// Initialize single shoot to one NPC
    /// </summary>
    /// <param name="npcEnemy"> target </param>
    /// <param name="towerWeapon"> weapon typ </param>
    public void shoot(GameObject npcEnemy, GameObject towerWeapon) {
        bullet = prefabSource.getBullet();
        npc = npcEnemy;
        npcHealth = npcEnemy.GetComponent<Health>();
        GameObject bullet_2 = (GameObject)Instantiate(bullet, towerWeapon.transform.position, towerWeapon.transform.rotation);
        bullet_2.SetActive(true);

        Shoot script_b = bullet_2.GetComponent<Shoot>();
        script_b.set_start(towerWeapon.transform, npcEnemy.transform);
        npcHealth.tackeDamage(weaponDamage);
    }
    /// <summary>
    /// Initialize shooting stop
    /// </summary>
    public void stopShooting() {
        transform.rotation = startRotation;
    }
}
