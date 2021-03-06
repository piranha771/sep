﻿        using UnityEngine;
using System.Collections;

public class WeaponDetector : MonoBehaviour, IWeapon {

 
    private float animationLength;
    private GameObject target;
    private LineRenderer laser;
    [SerializeField]
    private float delay;
    private float shootDelay;
    private bool animationFlag;
    private float currentAnimationLength;
    [SerializeField]
    private NPCShooter npcShooter;
    [SerializeField]
    private GameObject plate;

    public float AnimationLength { get { return animationLength; } set { animationLength = value; } }

    public int WeaponDamage { get { return 0; } set { return; } }
    public float Delay { get { return delay; } set { delay = value; } }

    void Start() {
        animationFlag = false;
        animationLength = delay * 0.25f;
        laser = GetComponent<LineRenderer>();
    }

    void Update() {
        if (target == null) {
           
            StopShooting();
        } else if (target.tag == "unknown") {
            transform.LookAt(target.transform);
            plate.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);      
            triggerShoot();
        } else {
            StopShooting();
        }
        
    }

    /// <summary>
    /// Initialize single shoot to one NPC
    /// </summary>
    /// <param name="npc"> target </param>
    public void Shoot(GameObject npc) {
        target = npc;
    }

    /// <summary>
    /// Make an hit on other gameobject. 
    /// </summary>
    private void ShootAtNPC() {
        PlayAnimation();
    }
    /// <summary>
    /// Stops the shooting at the target
    /// </summary>
    public void StopShooting() {
        laser.enabled = false;
        target = null;
        shootDelay = delay;
        currentAnimationLength = 0;
        npcShooter.ShootPermission = true;
    }

    /// <summary>
    /// Line is drawn.
    /// </summary>
    private void PlayAnimation() {
            laser.enabled = true;
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, target.transform.position);
           
    }

    private void ApplyAction() {
        NPCStateController nsc = target.GetComponent<NPCStateController>();
        int rnd = Random.Range(0, 100);
        if (target.tag == "unknown") {
            if (rnd < 50 ) {
                nsc.State = NPCState.Evil;
            } else{
                nsc.State = NPCState.Good;
            }
        } else {
            StopShooting();
        }
    }

    /// <summary>
    /// Start shooting
    /// </summary>
    void triggerShoot() {
   
        shootDelay -= Time.deltaTime;
       
      
        if (shootDelay < 0 && target != null) {
            animationFlag = true;
            shootDelay = delay;
        }else if(animationFlag && currentAnimationLength < animationLength) {
            currentAnimationLength += Time.deltaTime;
            PlayAnimation();
        } else if (animationFlag) {
            animationFlag = false;
            currentAnimationLength = 0;
            ApplyAction();
        }

      
    }
}
