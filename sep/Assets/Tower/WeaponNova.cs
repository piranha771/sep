using UnityEngine;
using System.Collections;

public class WeaponNova : MonoBehaviour, IWeapon {
    private GameObject npc;
    private float animationLength;
    [SerializeField]
    private int weaponDamage = 15;
    private bool npcState = true;
    private float radiusDelay = 1f;
    [SerializeField]
    private float delay;
    private bool animationFlag;
    private float currentAnimationLength;
    private float shootDelay;

    public float Delay { get { return delay; } set { delay = value; } }
	// Use this for initialization
	void Start () {
        npcState = false;
        npc = null;
        animationLength = delay * 0.75f;
	}
	
	// Update is called once per frame
	void Update () {
       
        if (!npcState) {

            RStopShooting();
            
        } else if (npcState) {
            triggerShoot();
        } 
        
	
	}

    void OnTriggerEnter(Collider npc) {

        if (npc.transform.tag == "enemy") {
            npc.GetComponent<NPCHealth>().TakeDamage(weaponDamage);
        }

    }

    public void Shoot(GameObject npcEnemy) {
        if (npcEnemy == null) return;
       if(npcEnemy.tag == "enemy") npcState = true;
        
    }

    public void RStopShooting() {
            npc = null;
            Vector3 oldScale = new Vector3(0.1f, 0.1f, 0.1f);
            transform.localScale = oldScale;
            transform.parent.GetComponent<NPCShooter>().ShootPermission = true;
      
    }

    public void StopShooting() {

    }

    public int WeaponDamage {
        get {
            return weaponDamage;
        }
        set {
            weaponDamage = value;
        }
    }

    private void makeRadius() {
  
            Vector3 newScale = new Vector3(0.25f, 0.25f, 0.25f);

            transform.localScale = transform.localScale + newScale;
       
    }

    void triggerShoot() {

        shootDelay -= Time.deltaTime;


        if (currentAnimationLength < animationLength) {
            currentAnimationLength += Time.deltaTime;
            makeRadius();
        } else  {
            npcState = false;
            animationFlag = false;
            currentAnimationLength = 0;
        }


    }
}
