using UnityEngine;
using System.Collections;

public class ShootWithBurrelGun : MonoBehaviour, IShootWith {
    private SingleBurrel[] burrelsScripts;
    private Quaternion startRotation;
    
   public int WeaponDamage { get { return burrelsScripts[0].WeaponDamage; } set { 
       foreach (SingleBurrel item in burrelsScripts)
	{
        item.WeaponDamage = value;
	}; } }
	// Use this for initialization
	void Start () {
        burrelsScripts = transform.GetComponentsInChildren<SingleBurrel>();
        startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void Shoot(GameObject npcEnemy) {
        foreach (SingleBurrel item in burrelsScripts) {
            item.Shoot(npcEnemy, transform.gameObject);
        }
    }

    public void StopShooting() {
        transform.rotation = startRotation;
    }
}
