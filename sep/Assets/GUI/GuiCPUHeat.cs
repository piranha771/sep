﻿using UnityEngine;
using System.Collections;

public class GuiCPUHeat : MonoBehaviour {
	
	public float Scale;
	public float xPositionInPercent;
	public float yPositionInPercent;
	
	private int minBars = 10; //This Variable will set the number of Bars that are representing the minimun heat of the CPU.
							  //These will always be visible, even if the current heat is lower than the minimum.
	private float xPositionModifier;
	private float yPositionModifier;
	
	public Texture TempDisplayContainer;
	public Texture[] bars;
	
	void OnGUI (){
		int currentHeight = Screen.height;
		int currentWidth = Screen.width;
		int xPosition = (int)(currentWidth*xPositionModifier);
		int yPosition = (int)(currentHeight*yPositionModifier);
		
		CPUHeatController controller = GameObject.Find("CPU").GetComponent<CPUHeatController>();
		string heat = controller.CurrentTemp.ToString("0.0");//Current Heat with one fractional digit.
		float normalHeat = controller.NormalHeat;
		float maxHeat = controller.MeltdownTemp;
		
		float heatPerBar = (maxHeat-normalHeat)/(float)(bars.Length-minBars);
		
		string displayText = "CPU Heat\r\n" + heat + " C°";
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		
		GUI.Label (new Rect (Screen.width-100, 10, 100, 50), displayText, centeredStyle);
		GUI.DrawTexture(new Rect(xPosition,yPosition,60*Scale,60*Scale),TempDisplayContainer, ScaleMode.StretchToFill);
		for (int i = 0; i<minBars;i++){
			GUI.DrawTexture(new Rect(xPosition,yPosition,60*Scale,60*Scale),bars[i], ScaleMode.StretchToFill);
		}
		
		for (int i = minBars; i<bars.Length;i++){
			if(controller.CurrentTemp-normalHeat>=heatPerBar*(i-minBars+1)){
				GUI.DrawTexture(new Rect(xPosition,yPosition,60*Scale,60*Scale),bars[i], ScaleMode.StretchToFill);
			}
		}
    }
	
	void Start () {
		yPositionModifier = yPositionInPercent/100.0f;
		xPositionModifier = xPositionInPercent/100.0f;
	}
 
    void Update () {}
}