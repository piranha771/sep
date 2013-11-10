using UnityEngine;
using System.Collections;

public class WeaponDetector : MonoBehaviour, IWeapon {

    [SerializeField]
    private float animationLength;

    private GameObject target;
    private LineRenderer laser;

    private bool shooting;
    private float currentAnimationLength;

    public float AnimationLength { get { return animationLength; } set { animationLength = value; } }

    public int WeaponDamage { get { return 0; } set { return; } }

    void Start() {
        laser = GetComponent<LineRenderer>();
    }

    void Update() {
        if (shooting && target == null) {
            StopShooting();
        } else if (shooting) {
            if (currentAnimationLength < animationLength) {
                currentAnimationLength += Time.deltaTime;
                PlayAnimation();
            } else {
                ApplyAction();
                StopShooting();
            }
        }
    }

    /// <summary>
    /// Initialize single shoot to one NPC
    /// </summary>
    /// <param name="npc"> target </param>
    public void Shoot(GameObject npc) {
        target = npc;
        currentAnimationLength = 0;
        shooting = true;
        laser.enabled = true;
    }

    /// <summary>
    /// Stops the shooting at the target
    /// </summary>
    public void StopShooting() {
        laser.enabled = false;
        shooting = false;
    }

    private void PlayAnimation() {        
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, target.transform.position);
    }

    private void ApplyAction() {
        NPCStateController nsc = target.GetComponent<NPCStateController>();
        nsc.State = NPCState.Evil;
    }
}
