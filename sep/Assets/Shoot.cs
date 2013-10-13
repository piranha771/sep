using UnityEngine;
using System.Collections;


using System.Collections;
using System.Collections.Generic;

public class Shoot : MonoBehaviour {

    private Transform endPoint;
    private Transform startPoint;
    private int next = 0;
    private int SPEED = 500;
    private float ROTATESPEED = 2000;
    private int reachTarget = 0;

    void Awake() {



    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (reachTarget == 1 || (endPoint == null && next == 1)) {
           
            Destroy(transform.gameObject);
        }
        else if (next == 1 && endPoint != null) {
            start_me();
            
        }


    }

    void start_me() {

        transform.LookAt(endPoint);
        walk();


    }
   
    void walk() {
        
        Vector3 targetPosition = endPoint.position;
        Vector3 velocity;
        Vector3 moveDirection = transform.TransformDirection(Vector3.forward);

        Vector3 delta = targetPosition - transform.position;

        velocity = moveDirection.normalized * SPEED * Time.deltaTime;
        if (delta.magnitude < 0.5) {

            reachTarget = 1;


        }
        else {

            rigidbody.velocity = velocity;

        }


    }

    public void set_start(Transform st, Transform en) {
        endPoint = en;
        startPoint = st;
        next = 1;
    }


}
