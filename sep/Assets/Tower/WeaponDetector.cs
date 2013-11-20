        using UnityEngine;
using System.Collections;

public class WeaponDetector : MonoBehaviour, IWeapon {

    [SerializeField]
    private float animationLength;

    private GameObject target;
    private LineRenderer laser;
    [SerializeField]
    private float delay;
    private float shootDelay;
    private bool animationFlag;
    private float currentAnimationLength;

    public float AnimationLength { get { return animationLength; } set { animationLength = value; } }

    public int WeaponDamage { get { return 0; } set { return; } }

    void Start() {
        animationFlag = false;
        laser = GetComponent<LineRenderer>();
    }

    void Update() {
        if (target == null) {
           
            StopShooting();
        } else{

            transform.LookAt(target.transform);
            triggerShoot();
        }
        
    }

    /// <summary>
    /// Initialize single shoot to one NPC
    /// </summary>
    /// <param name="npc"> target </param>
    public void Shoot(GameObject npc) {
        target = npc;
    }

    private void ShootAtNPC() {
        PlayAnimation();
    }
    /// <summary>
    /// Stops the shooting at the target
    /// </summary>
    public void StopShooting() {
        laser.enabled = false;
        target = null;
        currentAnimationLength = animationLength * 2;
        transform.parent.GetComponent<NPCShooter>().ShootPermission = true;
    }

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

    void triggerShoot() {
   
        shootDelay -= Time.deltaTime;
       
      
        if (shootDelay < 0 && target != null) { 
            animationFlag = true;
        }

         if ((currentAnimationLength > animationLength) && animationFlag) {
            animationFlag = false;
            currentAnimationLength = 0;
            ApplyAction();
        } else if (animationFlag) {
            PlayAnimation();
            currentAnimationLength += Time.deltaTime;
        } 

      
    }
}
