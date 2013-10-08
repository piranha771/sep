using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

    [SerializeField]
    private string previousPoint = "invalid";
    [SerializeField]
    private string nextPoint = "invalid";

    public string PreviousPoint { get { return previousPoint; } set { previousPoint = value; } }
    public string NextPoint { get { return nextPoint; } set { nextPoint = value; } }
	
}
