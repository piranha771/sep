using UnityEngine;
using System.Collections;
/// <summary>
/// End menu.
/// Pops up when Temp is too high, allows user to start a new game
/// </summary>

public class MenuScreens : MonoBehaviour {
	bool started = false;

	public float scaleInPercent;
	private float scaleNumber;

	private int fontSize;

	private int windowWidth = 200;
	private int windowHeight = 120;
	private int xPosition;
	private int yPosition;

	void OnLevelWasLoaded() {
		Time.timeScale = 1.0f;
	}




	void OnGUI() {
		yPosition = scale((Screen.height-windowHeight)/2);
		xPosition = scale((Screen.width-windowWidth)/2);
		CPUHeatController controller = GameObject.Find("CPU").GetComponent<CPUHeatController>();
		GuiTowerSpawnMenu guiMenu = GameObject.Find("CPU").GetComponent<GuiTowerSpawnMenu>();
		
		if(!started) {
			Rect windowRect = GUI.Window(0, new Rect(xPosition, yPosition, scale(windowWidth), scale(windowHeight)), StartMenu, "New Game");
			guiMenu.upMode = false;
			guiMenu.buyMode = false;
		}
		
		if(controller.CurrentTemp == controller.MeltdownTemp) {
			Rect windowRect = GUI.Window(0, new Rect(xPosition, yPosition, scale(windowWidth), scale(windowHeight)), EndMenu, "Game Over");
			guiMenu.upMode = false;
			guiMenu.buyMode = false;
			Time.timeScale = 0.0f;
			//todo Ghost ausblenden
			
		}}
			


	void EndMenu(int windowID) {
		int size = scale(windowWidth);
		GUI.skin.button.fontSize = fontSize;
		if (GUI.Button(new Rect(size/4, size/4, size/2, size/5), "Start a new Game")){		
			Application.LoadLevel("game2");
			}
		
	}

	void Start () {
		scaleNumber = scaleInPercent/100.0f;
		fontSize =(int)(10.0f*scaleNumber);
	}

	private int scale(int number){
		return (int)(number*scaleNumber);
	}

	void StartMenu(int windowID) {
		int size = scale(windowWidth);
		GuiTowerSpawnMenu guiMenu = GameObject.Find("CPU").GetComponent<GuiTowerSpawnMenu>();
		Time.timeScale = 0.0f;
		GUI.skin.button.fontSize = fontSize;
		if (GUI.Button(new Rect(size/4, size/4, size/2, size/5), "Start a new Game")){
			guiMenu.buyMode = true;
			started = true;
			Time.timeScale = 1.0f;
		}
	}
}