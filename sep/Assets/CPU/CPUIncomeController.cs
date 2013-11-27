using UnityEngine;
using System.Collections;

public class CPUIncomeController : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {
        NPCStateController stateCon = collider.gameObject.GetComponent<NPCStateController>();
        if (stateCon == null) return;
        switch (stateCon.State) {
            case NPCState.Unknown:
                gameObject.GetComponent<CPUHeatController>().ImpactUnknown();
                break;
            case NPCState.Evil:
            case NPCState.SuperEvil:
                gameObject.GetComponent<CPUHeatController>().ImpactEvil();
                break;
            case NPCState.Good:
            case NPCState.SuperGood:
                gameObject.GetComponent<CPUComputeTimeController>().Impact(collider.gameObject);
                break;
            default:
                break;
        }
    }
}
