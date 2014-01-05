using UnityEngine;
using System.Collections;

public class GuiScore : MonoBehaviour {
    // Just a lazy copy of GuiIncome 
    // TODO: Make this clean

    public float scaleInPercent;
    private float scale;
    public float xPositionInPercent;
    public float yPositionInPercent;
    private int fontSize;

    private float xPositionModifier;
    private float yPositionModifier;

    public Texture oktagon;

    ScoreController controller;

    void OnGUI() {
        int xSize = (int)(Screen.width / 13.75f * scale);
        int ySize = (int)(Screen.width / 20.625f * scale);
        int xPosition = (int)(Screen.width * xPositionModifier);
        int yPosition = (int)(Screen.height * yPositionModifier);
        yPosition = Screen.height - (yPosition + ySize);
        string displayText = "Score\r\n"  + controller.Score;
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.MiddleCenter;
        GUI.DrawTexture(new Rect(xPosition, yPosition, xSize, ySize), oktagon);
        GUI.Label(new Rect(xPosition, yPosition, xSize, ySize), displayText, centeredStyle);
    }

    void Start() {
        controller = GetComponent<ScoreController>();
        scale = scaleInPercent / 100.0f;
        yPositionModifier = yPositionInPercent / 100.0f;
        xPositionModifier = xPositionInPercent / 100.0f;
        fontSize = (int)(11.0f * scale) / 1024 * Screen.width;
    }
}
