using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WayPointRunner : MonoBehaviour {

    [SerializeField]
    private bool doRun = false;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private float reachedPointEpsilon = 0.2f; 
    [SerializeField]
    private List<Transform> waypoints;
    [SerializeField]
    private float waitAtPointTimeSeconds = 0f;

    private GameObject currentPoint;
    private float waitTime;
    private int nextCounter = 1;

    public bool DoRun { get { return doRun; } set { doRun = value; } }
    public List<Transform> Waypoints { get { return waypoints; } set { waypoints = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float WaitAtPointTimeSeconds { get { return waitAtPointTimeSeconds; } set { waitAtPointTimeSeconds = value; } }

	void Start () {
        this.waitTime = waitAtPointTimeSeconds;
        if (waypoints.Count == 0) {
            doRun = false;
            return;
        }
        currentPoint = waypoints[0].gameObject;
        transform.LookAt(currentPoint.transform.position); 
	}
	
	void Update () {
        if (!doRun) return;
        float distance = Vector3.Distance(transform.position, currentPoint.transform.position);
        if (distance > reachedPointEpsilon)
            moveToNext(distance);
        else
            reachedNext();
	}

    private void moveToNext(float distance) {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void reachedNext() {
        if (waitTime <= 0) {
            waitTime = waitAtPointTimeSeconds;
            
            if ( nextCounter >= waypoints.Count) {
                doRun = false;
                return;
            }
            currentPoint = waypoints[nextCounter].gameObject;
            nextCounter++;
            transform.LookAt(currentPoint.transform.position);
        } else {
            waitTime -= Time.fixedDeltaTime;
        }
    }
}
