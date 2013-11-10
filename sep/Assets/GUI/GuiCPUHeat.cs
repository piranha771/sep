using UnityEngine;
using System.Collections;

public class GuiCPUHeat : MonoBehaviour {
	
	void OnGUI (){
		CPUHeatController controller = GameObject.Find("CPU").GetComponent<CPUHeatController>();
		string heat = controller.getCurrentTemp().ToString("0.0");
		string displayText = "CPU Heat\r\n" + heat + " C°";
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		GUI.Label (new Rect (Screen.width-100, 10, 100, 50), displayText, centeredStyle);
    }
	
	void Start () {}
 
    void Update () {}
}
