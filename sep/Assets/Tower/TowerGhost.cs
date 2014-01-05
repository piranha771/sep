using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Makes the tower start as a ghost
/// </summary>
public class TowerGhost : MonoBehaviour {

    [SerializeField]
    private Material ghostMaterial;
    [SerializeField]
    private LayerMask placeableOnLayer;

    private Dictionary<GameObject, Material> stdMaterials;
    
    private bool placeable = false;

    public Material GhostMaterial { get { return ghostMaterial; } set { ghostMaterial = value; } }
    public bool Placeable { get { return placeable; } set { placeable = value; } }
    
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
        GetComponentInChildren<TowerSelect>().Selectable = false;
	}

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue, placeableOnLayer)) {
            Vector3 towerPosition = hit.point;
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
        GetComponentInChildren<TowerSelect>().Selectable = true;
        // Disable this script
        this.enabled = false;
    }
}
