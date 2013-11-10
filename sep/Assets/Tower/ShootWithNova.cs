using UnityEngine;
using System.Collections;

public class ShootWithNova : MonoBehaviour, IShootWith {
    private GameObject npc;
    private int weaponDamage = 15;
    private bool npcState = true;
    private float radiusDelay = 1f;
    private float delay = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

      
	
	}

    public void Shoot(GameObject npcEnemy) {

       if(npcState) makeRadius();
        
    }

    public void StopShooting() {
        if (npcState) {
            Vector3 oldScale = new Vector3(0.1f, 0.1f, 0.1f);
            transform.localScale = oldScale;
        }
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
        
        while (radiusDelay > 0) {
            npcState = false;
            radiusDelay -= Time.deltaTime;
            Vector3 newScale = new Vector3(0.0025f, 0.0025f, 0.0025f);

            transform.localScale = transform.localScale + newScale;
        }
        radiusDelay = delay;

        npcState = true;
    }
}
