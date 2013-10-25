using UnityEngine;
using System.Collections;

public class TraceGenerator : MonoBehaviour {
    
    [SerializeField]
    private float fieldLength = 4;
    [SerializeField]
    private Vector3 direction = Vector3.up;
    [SerializeField]
    private float waypointSpread = 1.0f;

    public float FieldLength { get { return fieldLength; } set { fieldLength = value; } }
    public Vector3 Direction { get { return direction; } set { direction = value; } }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
