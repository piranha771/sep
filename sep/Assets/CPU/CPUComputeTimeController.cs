using UnityEngine;
using System.Collections;

public class CPUComputeTimeController : MonoBehaviour {

    [SerializeField]
    private int cpuTimePerBit;
    [SerializeField]
    private int cpuTime;

    public int CPUTime { get { return cpuTime; } set { cpuTime = value; } }
    public int CPUTimePerBit { get { return cpuTimePerBit; } set { cpuTimePerBit = value; } }

    public void Impact(GameObject npcGoodBit) {
        cpuTime += cpuTimePerBit; 
    }
}
