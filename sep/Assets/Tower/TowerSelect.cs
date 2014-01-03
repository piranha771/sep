using UnityEngine;
using System.Collections;

public class TowerSelect : MonoBehaviour, ISelectable {

    [SerializeField]
    private GameObject towerRadius;
    [SerializeField]
    private BoxCollider radiusCollider;
    [SerializeField]
    private string selecterGameObjectName = "GameController";
    [SerializeField]
    private bool selectable = true;

    private Selecter selecter;
    private bool isSelected;
	private GuiTowerSpawnMenu gui;

    public GameObject TowerRadius { get { return towerRadius; } set { towerRadius = value; } }
    public bool Selectable {  get { return selectable; }  set {  selectable = value; } }
    public bool IsSelected { get { return isSelected; } set { isSelected = value; } }

	void Start () {
        selecter = GameObject.Find(selecterGameObjectName).GetComponent<Selecter>();
        selecter.register(this);
	}
	
	void Update () {

	}

    public void OnSelect() {
        if (!selectable) return;
		gui = GameObject.Find("CPU").GetComponent<GuiTowerSpawnMenu>();
	
		gui.currentTower = this.transform.parent.gameObject;
	
        isSelected = true;
        towerRadius.SetActive(true);
        UpdateRadius();
		gui.upMode = true;
	

    }

    public void OnDeselect() {
		gui = GameObject.Find("CPU").GetComponent<GuiTowerSpawnMenu>();	
	
        isSelected = false;
        towerRadius.SetActive(false);
		//gui.upMode = false;
	
	

    }

    public void OnDrestroy() {
        selecter.unregister(this);
    }

    /// <summary>
    /// Update radius renderer. Is equal to colliderbox size
    /// </summary>
    private void UpdateRadius() {
        Vector3 workScale = new Vector3(0, 0, 0);
        workScale.y = radiusCollider.size.z;
        workScale.x = radiusCollider.size.x;
        towerRadius.transform.localScale = (workScale);
    }
}
