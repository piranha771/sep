using UnityEngine;
using System.Collections;

public class ShootWithLine : MonoBehaviour {
    LineRenderer lineBullet;
	// Use this for initialization
	void Start () {
        lineBullet = transform.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lineBullet.SetPosition(0, transform.position);
        lineBullet.SetPosition(1, transform.position);
	}

    public void shoot(GameObject monster, GameObject towerWeapon)
    {

        lineBullet.SetPosition(0, towerWeapon.transform.position);
        lineBullet.SetPosition(1, monster.transform.position);
        
        
    }
}
