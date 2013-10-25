using UnityEngine;
using System.Collections;
using System;

public class TankTower : MonoBehaviour {

    [SerializeField]
    private bool isActive = true;
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float cooldownInSeconds = 1.5f;

    private GameObject currentEnemy;
    private Health enemyHealth;
    private float cooldown;

    public bool IsActive { get { return isActive; } set { isActive = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public float CooldownInSeconds { get { return cooldownInSeconds; } set { cooldownInSeconds = value; } }

	void Start () {
        cooldown = cooldownInSeconds;
        getNearestEnemy();
	}
	
	void Update () {
        if (currentEnemy == null) {
            getNearestEnemy();
        } else {
            transform.LookAt(currentEnemy.transform.position);
            if (cooldown < 0) {
                attack();
                cooldown = 1;
            } else {
                cooldown -= Time.deltaTime;
            }
        }
	}

    private void attack() {
        
        enemyHealth.CurrentHealth -= damage;
        GameObject.Find("HealthText").GetComponent<GUIText>().text = "Health: " + enemyHealth.CurrentHealth.ToString();
        // TODO: effects
    }

    private void getNearestEnemy() {        
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("enemy");
        print(gameObjects.Length);
        float smallestDist = float.MaxValue;
        foreach (var go in gameObjects) {
            float distance = Vector3.Distance(go.transform.position, transform.position);
            if (distance < smallestDist) {
                smallestDist = distance;
                currentEnemy = go;
                enemyHealth = go.GetComponent<Health>();
                if (enemyHealth == null) throw new Exception("Health for enemy was not found!");
            }
        }

        if (currentEnemy == null || gameObjects.Length == 0) {
            enemyHealth = null;
            transform.rotation = transform.parent.rotation;  
        }
    }
}
