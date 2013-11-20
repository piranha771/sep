using UnityEngine;
using System.Collections;

public class CPUComputeTimeController : MonoBehaviour {

    [SerializeField]
    private float healthCPUTimeMultiplier;

    [SerializeField]
    private int cpuTime;

    public int CPUTime { get { return cpuTime; } set { cpuTime = value; } }
    public float HealthCPUTimeMultiplier { get { return healthCPUTimeMultiplier; } set { healthCPUTimeMultiplier = value; } }

    public void Impact(GameObject npcGoodBit) {
        cpuTime += Mathf.CeilToInt(npcGoodBit.GetComponent<NPCHealth>().Health * healthCPUTimeMultiplier); 
    }
}
