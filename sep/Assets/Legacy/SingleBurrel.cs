using UnityEngine;
using System.Collections;

public class SingleBurrel : MonoBehaviour, IMakeDamage {
    private GameObject bullet;
    private NPCHealth npcHealth;
    private GameObject npc;
    private int weaponDamage = 1;
    private Quaternion startRotation;
    private PrefabSource prefabSource;

    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
    // Use this for initialization
    void Start() {
        GameObject gameController = GameObject.Find("GameController");
        prefabSource = gameController.GetComponent<PrefabSource>();
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update() {
        
    }
    /// <summary>
    /// Initialize single shoot to one NPC
    /// </summary>
    /// <param name="npcEnemy"> target </param>
    /// <param name="towerWeapon"> weapon typ </param>
    public void Shoot(GameObject npcEnemy, GameObject towerWeapon) {
        bullet = prefabSource.Bullet();
        npc = npcEnemy;
        
        npcHealth = npcEnemy.GetComponent<NPCHealth>();
        GameObject bullet_2 = (GameObject)Instantiate(bullet, transform.position, towerWeapon.transform.rotation);
        bullet_2.SetActive(true);
     
        Shoot script_b = bullet_2.GetComponent<Shoot>();
        script_b.SetStart(transform, npcEnemy.transform, transform.gameObject);
       
    }

    public void MakeDamage() {

        npcHealth.TakeDamage(weaponDamage);

    }
    
}
