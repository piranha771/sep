using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trace : MonoBehaviour {

    [SerializeField]
    private bool online;
    [SerializeField]
    private List<GameObject> waypoints;

    public bool Online { 
        get { return online; } 
        set { 
            //TODO: Changes for online/offline traces here!
            online = value; 
        } 
    }

    public List<GameObject> Waypoints { get { return waypoints; } }
}
