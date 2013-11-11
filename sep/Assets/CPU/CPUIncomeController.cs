using UnityEngine;
using System.Collections;

public class CPUIncomeController : MonoBehaviour {

    void OnTriggerEnter(Collider collider) {
        switch (collider.gameObject.GetComponent<NPCStateController>().State) {
            case NPCState.Unknown:
            case NPCState.Evil:
            case NPCState.SuperEvil:
                gameObject.GetComponent<CPUHeatController>().Impact(collider.gameObject);
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
