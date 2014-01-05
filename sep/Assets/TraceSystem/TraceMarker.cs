using UnityEngine;
using System.Collections;

public enum TraceChunkType {
    Straight,
    Corner,
}

public class TraceMarker : MonoBehaviour {

    [SerializeField]
    private TraceChunkType type;

    public TraceChunkType Type { get { return type; } set { type = value; } }


	
}
