using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Selecter : MonoBehaviour {

    [SerializeField]
    private LayerMask selectLayer;
    [SerializeField]
    private int listenOnMouseButtonNr = 0;
    
    private List<ISelectable> selectables = new List<ISelectable>();

    public int SelectLayer { get { return selectLayer; } set { selectLayer = value; } }
    public int ListenOnMouseButtonNr { get { return listenOnMouseButtonNr; } set { listenOnMouseButtonNr = value; } }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(listenOnMouseButtonNr)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, selectLayer)) {
                ISelectable selected = (ISelectable)hit.collider.GetComponent(typeof(ISelectable));
                if (selected != null) {
                    selectSingle(selected);
                } else deselectAll();
            } else deselectAll();
        }
    }

    /// <summary>
    /// Adds an object as listener for selection
    /// </summary>
    /// <param name="selectable"></param>
    public void register(ISelectable selectable) {
        selectables.Add(selectable);
    }

    /// <summary>
    /// Removes a listener
    /// </summary>
    /// <param name="selectable"></param>
    public void unregister(ISelectable selectable) {
        selectables.Remove(selectable);
    }

    /// <summary>
    /// Selects an object an unselects all other
    /// </summary>
    private void selectSingle(ISelectable selected) {
        foreach (var item in selectables) {
            if (item == selected) { 
                if (!item.IsSelected) item.OnSelect(); 
            } else item.OnDeselect();
        }
    }

    /// <summary>
    /// Deselects all objects
    /// </summary>
    private void deselectAll() {
        foreach (var item in selectables) {
            if (item.IsSelected) item.OnDeselect();
        }
    }
}
