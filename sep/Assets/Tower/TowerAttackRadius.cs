using UnityEngine;
using System.Collections;

public class TowerAttackRadius : MonoBehaviour {

    private LineRenderer attackRadius;
    private BoxCollider colliderTower;

	// Use this for initialization
	void Start () {
        attackRadius = transform.GetComponent<LineRenderer>();
        colliderTower = transform.GetComponent<BoxCollider>();
        updateRadius();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateRadius() {

        Vector3 maxPointOfCollider = colliderTower.bounds.max;
        Vector3 sizeOfCollider = colliderTower.size/2;
        maxPointOfCollider.y = maxPointOfCollider.y - (sizeOfCollider.y/2);
        attackRadius.SetPosition(0,maxPointOfCollider);
        maxPointOfCollider.z = maxPointOfCollider.z - sizeOfCollider.z;
        attackRadius.SetPosition(1,  maxPointOfCollider);
        maxPointOfCollider.x = maxPointOfCollider.x - sizeOfCollider.x;
        attackRadius.SetPosition(2,  maxPointOfCollider);
        maxPointOfCollider.z = maxPointOfCollider.z + sizeOfCollider.z;
        attackRadius.SetPosition(3, maxPointOfCollider);
        maxPointOfCollider.x = maxPointOfCollider.x + sizeOfCollider.x;
        attackRadius.SetPosition(4,  maxPointOfCollider);
    }
}
