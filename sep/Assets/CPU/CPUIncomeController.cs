using UnityEngine;
using System.Collections;

public class CPUIncomeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider collider) {
        Debug.Log("HIT!");
        //TODO check if evil!
        gameObject.GetComponent<CPUHeatController>().Impact(collider.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
