using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trace : MonoBehaviour {

    [SerializeField]
    private bool online;
    [SerializeField]
    private Material onlineMaterialStraight;
    [SerializeField]
    private Material onlineMaterialCorner;
    [SerializeField]
    private Material offlineMaterialStraight;
    [SerializeField]
    private Material offlineMaterialCorner;
    [SerializeField]
    private List<GameObject> waypoints;

    public bool Online { 
        get { return online; } 
        set { 
            ChangeMaterial(transform, value);
            online = value; 
        } 
    }

    public Material OnlineMaterialStraight { get { return onlineMaterialStraight; } set { onlineMaterialStraight = value; } }
    public Material OnlineMaterialCorner { get { return onlineMaterialCorner; } set { onlineMaterialCorner = value; } }
    public Material OfflineMaterialStraight { get { return offlineMaterialStraight; } set { offlineMaterialStraight = value; } }
    public Material OfflineMaterialCorner { get { return offlineMaterialCorner; } set { offlineMaterialCorner = value; } }

    void Start() {
        ChangeMaterial(transform, online);
    }

    private void ChangeMaterial(Transform trans, bool isOnline) {
        TraceMarker marker = trans.GetComponent<TraceMarker>();
        if (marker != null) {
            if (isOnline) {
                switch (marker.Type) {
                    case TraceChunkType.Straight:
                        trans.renderer.material = onlineMaterialStraight;
                        break;
                    case TraceChunkType.Corner:
                        trans.renderer.material = onlineMaterialCorner;
                        break;
                }
            } else {
                switch (marker.Type) {
                    case TraceChunkType.Straight:
                        trans.renderer.material = offlineMaterialStraight;
                        break;
                    case TraceChunkType.Corner:
                        trans.renderer.material = offlineMaterialCorner;
                        break;
                }
            }
        }
        
        if (trans.childCount > 0) {
            foreach (Transform child in trans) {
                ChangeMaterial(child, isOnline);
            }
        }        
    }

    public List<GameObject> Waypoints { get { return waypoints; } }
}
