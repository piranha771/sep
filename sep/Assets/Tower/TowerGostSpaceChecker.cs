using UnityEngine;
using System.Collections;

public class TowerGostSpaceChecker : MonoBehaviour {

    [SerializeField]
    private TowerGhost towerGhost;

    public TowerGhost TowerGhost { get { return towerGhost; } set { towerGhost = value; } }

    private int numColliders = 0;
	
	// Update is called once per frame
	void Update () {
        towerGhost.Placeable = numColliders == 0;
	}

    void OnTriggerEnter(Collider coll) {
        numColliders++;
    }

    void OnTriggerExit(Collider coll) {
        numColliders--;
    }
}
