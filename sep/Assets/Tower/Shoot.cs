using UnityEngine;
using System.Collections;


using System.Collections;

public class Shoot : MonoBehaviour {

    private Transform endPoint;
    private Transform startPoint;
    private GameObject towerWeapon;
    private int next = 0;
    private int SPEED = 1500;
    private float ROTATESPEED = 2000;
    private int reachTarget = 0;

    void Awake() {



    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    /// <summary>
    /// If other gameobject is reached tower make damage on it.
    /// </summary>
    void Update() {

        if (reachTarget == 1 || (endPoint == null && next == 1)) {
            IMakeDamage scriptIMD  = (IMakeDamage) towerWeapon.GetComponent(typeof(IMakeDamage));
            scriptIMD.MakeDamage();
            Destroy(transform.gameObject);
        }
        else if (next == 1 && endPoint != null) {
            StartMe();
            
        }


    }

    void StartMe() {

        transform.LookAt(endPoint);
        Walk();


    }
   /// <summary>
   /// Self tried to reach other gameobject.
   /// </summary>
    void Walk() {
        Vector3 targetPosition = endPoint.position;
        Vector3 velocity;
        Vector3 moveDirection = transform.TransformDirection(Vector3.forward);

        Vector3 delta = targetPosition - transform.position;

        velocity = moveDirection.normalized * SPEED * Time.deltaTime;
        if (delta.magnitude < 1) {

            reachTarget = 1;


        }
        else {

            rigidbody.velocity = velocity;

        }


    }

    /// <summary>
    /// Transfer startponit and endpoint for bulletflight
    /// </summary>
    /// <param name="st">startpoint</param>
    /// <param name="en">endpont</param>
    public void SetStart(Transform st, Transform en, GameObject towerWeapon) {
        endPoint = en;
        startPoint = st;
        next = 1;
        this.towerWeapon = towerWeapon;
    }


}
