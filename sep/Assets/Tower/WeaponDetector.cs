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

    private bool shooting;
    private float currentAnimationLength;

    public float AnimationLength { get { return animationLength; } set { animationLength = value; } }

    public int WeaponDamage { get { return 0; } set { return; } }

    void Start() {
        laser = GetComponent<LineRenderer>();
    }

    void Update() {
        if (target == null) {
           
            StopShooting();
        } else {

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
        laser.enabled = true;
      
       
    }
    /// <summary>
    /// Stops the shooting at the target
    /// </summary>
    public void StopShooting() {
        laser.enabled = false;
        transform.parent.GetComponent<NPCShooter>().ShootPermission = true;
    }

    private void PlayAnimation() {
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, target.transform.position);
           
    }

    private void ApplyAction() {
        NPCStateController nsc = target.GetComponent<NPCStateController>();
        nsc.State = NPCState.Evil;
    }

    void triggerShoot() {
   
        shootDelay -= Time.deltaTime;
        currentAnimationLength += Time.deltaTime;
        if (shootDelay < 0 && target != null) {
            ShootAtNPC();
            currentAnimationLength = 0;
            shootDelay = delay;

        }
        if (currentAnimationLength < (delay / 2)) {
            PlayAnimation();
        } else {
            laser.enabled = false;
        }
    }
}
