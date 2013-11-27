using UnityEngine;
using System.Collections;

public class TowerGostSpaceChecker : MonoBehaviour {

    [SerializeField]
    private TowerGhost towerGhost;

    private int numColliders = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(numColliders);
        towerGhost.Placeable = numColliders == 3;
	}

    void OnTriggerEnter(Collider coll) {
        numColliders++;
    }

    void OnTriggerExit(Collider coll) {
        numColliders--;
    }
}
