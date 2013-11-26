using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WayPointRunner : MonoBehaviour {

    [SerializeField]
    private bool doRun = false;
    [SerializeField]
    private bool dieAtReachedEnd = false;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private float reachedPointEpsilon = 0.2f; 
    [SerializeField]
    private List<GameObject> waypoints;
    [SerializeField]
    private float waitAtPointTimeSeconds = 0f;

    private GameObject currentPoint;
    private float waitTime;
    private int nextCounter = 1;
    private float lastDistance;

    public bool DoRun { get { return doRun; } set { doRun = value; } }
    public bool DieAtReachedEnd { get { return dieAtReachedEnd; } set { dieAtReachedEnd = value; } }
    public List<GameObject> Waypoints { get { return waypoints; } set { waypoints = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float WaitAtPointTimeSeconds { get { return waitAtPointTimeSeconds; } set { waitAtPointTimeSeconds = value; } }

	void Start () {
        this.waitTime = waitAtPointTimeSeconds;
        if (waypoints.Count == 0) {
            doRun = false;
            return;
        }
        currentPoint = waypoints[0].gameObject;
        lastDistance = float.MaxValue;
        transform.LookAt(currentPoint.transform.position); 
	}
	
	void Update () {
        if (!doRun) return;
        float distance = Vector3.Distance(transform.position, currentPoint.transform.position);
        if (distance < lastDistance) {
            moveToNext();
            lastDistance = distance;
        } else {
            reachedNext();
        }
	}

    private void moveToNext() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void reachedNext() {
        lastDistance = float.MinValue;
        transform.position = currentPoint.transform.position;
        waitTime = waitAtPointTimeSeconds;
        if (waitTime <= 0) {            
            if ( nextCounter >= waypoints.Count) {
                doRun = false;
                reachedEnd();
                return;
            }
            currentPoint = waypoints[nextCounter].gameObject;
            nextCounter++;
            transform.LookAt(currentPoint.transform.position);
            lastDistance = float.MaxValue;
        } else {
            waitTime -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Will be fired when runner hits the end
    /// </summary>
    private void reachedEnd() {
        if (dieAtReachedEnd) Destroy(gameObject);
    }
}
