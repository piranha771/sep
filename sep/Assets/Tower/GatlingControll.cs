using UnityEngine;
using System.Collections;

public class GatlingControll : MonoBehaviour {
    [SerializeField]
    private float rotateSpeed;

    public float RotateSpeed { get { return rotateSpeed; } set { rotateSpeed = value;} }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,rotateSpeed);
	}

}
