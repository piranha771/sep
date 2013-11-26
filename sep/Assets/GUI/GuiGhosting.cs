using UnityEngine;
using System.Collections;

public class GuiGhosting : MonoBehaviour {

    bool ghostStatus;

    public bool GhostStatus { get { return ghostStatus; } set { ghostStatus = value; } }
	// Use this for initialization
	void Start () {
        ghostStatus = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (ghostStatus) GhostInAction();
        if (!ghostStatus) {
            Vector3 startPos = new Vector3(0, 0, 0);
            transform.position = startPos;
        }

	}

    void GhostInAction() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "spawnarea") {
            Vector3 towerPosition = hit.point;
            towerPosition.y += 0.4f;
            transform.position = towerPosition;
        }
    }
}
