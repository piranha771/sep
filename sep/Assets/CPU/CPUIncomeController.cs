using UnityEngine;
using System.Collections;

public class CPUIncomeController : MonoBehaviour {
	[SerializeField]
    private int availableComputingTime;
	// Use this for initialization
	void Start () {
		availableComputingTime = 0;
	}

    void OnTriggerEnter(Collider collider) {
        //TODO check if evil!
        gameObject.GetComponent<CPUHeatController>().Impact(collider.gameObject);
		availableComputingTime+=1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int getComputingTime(){
		return availableComputingTime;
	}
}
