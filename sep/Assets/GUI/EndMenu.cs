using UnityEngine;
using System.Collections;
/// <summary>
/// End menu.
/// Pops up when Temp is too high, allows user to start a new game
/// </summary>

public class EndMenu : MonoBehaviour {

	void OnLevelWasLoaded() {
		Time.timeScale = 1.0f;
	}




	void OnGUI() {
		CPUHeatController controller = GameObject.Find("CPU").GetComponent<CPUHeatController>();
		GuiTowerSpawnMenu guiMenu = GameObject.Find("CPU").GetComponent<GuiTowerSpawnMenu>();

		if(controller.CurrentTemp == controller.MeltdownTemp) {
			Rect windowRect = GUI.Window(0, new Rect(200, 200, 250, 150), DoMyWindow, "Game Over");
			guiMenu.upMode = false;
			guiMenu.buyMode = false;
			Time.timeScale = 0.0f;
			//todo Ghost ausblenden

			                        }}


	void DoMyWindow(int windowID) {

		if (GUI.Button(new Rect(50, 50, 150, 40), "Start a new Game")){		
			Application.LoadLevel("game2");
			}
		
	}
}