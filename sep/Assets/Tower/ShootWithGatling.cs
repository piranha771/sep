﻿using UnityEngine;
using System.Collections;

public class ShootWithGatling : MonoBehaviour, IMakeDamage, IShootWith {
    private GameObject bullet;
    private Health npcHealth;
    private GameObject npc;
    private int weaponDamage = 1;
    private Quaternion startRotation;
    private PrefabSource prefabSource;
    private GatlingControll gatlingControll;
    private float rotateSpeed;
    private bool npcState = true;
    private ShootNPC shootNPC ;

    public int WeaponDamage { get { return weaponDamage; } set { weaponDamage = value; } }
	// Use this for initialization
	void Start () {
        GameObject gameController = GameObject.Find("GameController");
        prefabSource = gameController.GetComponent<PrefabSource>();
        gatlingControll = transform.GetComponentInChildren<GatlingControll>();
        shootNPC = transform.parent.GetComponent<ShootNPC>();

        startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if ((shootNPC.Delay > 0.045f && shootNPC.Delay < 0.21f) && npcState) shootNPC.Delay = shootNPC.Delay + 0.01f;
        if (gatlingControll.RotateSpeed > 0f && npcState) gatlingControll.RotateSpeed = gatlingControll.RotateSpeed - 0.1f;
        if (npc == null) {            
            StopShooting();
        }
	}

    public void Shoot(GameObject npcEnemy, GameObject towerWeapon) {
        npcState = false;
        bullet = prefabSource.Bullet();
        npc = npcEnemy;
        npcHealth = npcEnemy.GetComponent<Health>();
        GameObject bulletCopy = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
        bulletCopy.SetActive(true);
        Shoot script_b = bulletCopy.GetComponent<Shoot>();
        script_b.SetStart(transform, npcEnemy.transform, transform.gameObject);
        if (gatlingControll.RotateSpeed < 15f)gatlingControll.RotateSpeed = gatlingControll.RotateSpeed + 1f;
        if (shootNPC.Delay <= 0.22f && shootNPC.Delay > 0.05f) shootNPC.Delay = shootNPC.Delay - 0.01f;
    }

    public void StopShooting() {
        npcState = true;
        transform.rotation = startRotation;
    }

    public void MakeDamage() {
        npcHealth.tackeDamage(weaponDamage);
    }
}