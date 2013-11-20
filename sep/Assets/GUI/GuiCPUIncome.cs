using UnityEngine;
using System.Collections;

public class GuiCPUIncome : MonoBehaviour {

    void OnGUI() {
        CPUComputeTimeController controller = GetComponent<CPUComputeTimeController>();
        string displayText = "Computing time\r\n" + controller.CPUTime + " ms";
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;
        GUI.Label(new Rect(Screen.width-100, 40, 100, 50), displayText, centeredStyle);
    }
}
