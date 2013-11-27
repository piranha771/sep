using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Makes the tower start as a ghost
/// </summary>
public class TowerGhost : MonoBehaviour {

    [SerializeField]
    private Material ghostMaterial;

    private Dictionary<GameObject, Material> stdMaterials;
    private LayerMask layermask = 1 << 10;
    private bool placeable = false;

    public Material GhostMaterial { get { return ghostMaterial; } set { ghostMaterial = value; } }
    public bool Placeable { get { return placeable; } set { placeable = value; } }
    

	// Use this for initialization
	void Start () {
        stdMaterials = new Dictionary<GameObject, Material>();
        // Save all normal Materials and replace them with ghost material
        Transform[] allTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform transform in allTransforms) {
            if (transform.renderer != null) {
                stdMaterials.Add(transform.gameObject, transform.renderer.material);
                transform.renderer.material = ghostMaterial;
            }
        }
        // Deny shooting
        GetComponent<NPCShooter>().enabled = false;
        // Disable selecting
        GetComponentInChildren<TowerAttackRadius>().enabled = false;
	}

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue, layermask)) {
            Vector3 towerPosition = hit.point;
            towerPosition.y += 0.25f;
            transform.position = towerPosition;
        }

        if (placeable && Input.GetMouseButtonDown(0)) {
            MakeSolid();
        }
    }

    /// <summary>
    /// The tower becomes solid
    /// </summary>
    public void MakeSolid() {
        // Restore all normal materials
        foreach (var item in stdMaterials) {
            item.Key.renderer.material = item.Value;
        }
        // Allow shooting
        GetComponent<NPCShooter>().enabled = true;
        // Enable selecting
        GetComponentInChildren<TowerAttackRadius>().enabled = true;
        // Disable this script
        this.enabled = false;
    }
}
