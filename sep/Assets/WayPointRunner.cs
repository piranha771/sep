using UnityEngine;
using System.Collections;

public class WayPointRunner : MonoBehaviour {

    [SerializeField]
    private bool doRun = false;
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private float reachedPointEpsilon = 0.2f; 
    [SerializeField]
    private string startPoint = "invalid";
    [SerializeField]
    private float waitAtPointTimeSeconds = 0f;

    private GameObject currentPoint;
    private float waitTime;

    public bool DoRun { get { return doRun; } set { doRun = value; } }
    public string StartPoint { get { return startPoint; } set { startPoint = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float WaitAtPointTimeSeconds { get { return waitAtPointTimeSeconds; } set { waitAtPointTimeSeconds = value; } }

	void Start () {
        this.waitTime = waitAtPointTimeSeconds;
        if (startPoint == "invalid") {
            doRun = false;
            return;
        }
        currentPoint = GameObject.Find(startPoint);
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
            string next = currentPoint.GetComponent<WayPoint>().NextPoint;
            if (next == "invalid") {
                doRun = false;
                return;
            }
            currentPoint = GameObject.Find(next);
            transform.LookAt(currentPoint.transform.position);
        } else {
            waitTime -= Time.fixedDeltaTime;
        }
    }
}
