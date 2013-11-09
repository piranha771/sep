using UnityEngine;
using System.Collections;

public class buttons : MonoBehaviour {


    Texture2D boxIcon;
    Texture2D sphereIcon;
    Texture2D cylinderIcon;
	GameObject building;
	bool isHoverGUI = false; 
	Rect rect =new Rect (10,10, 110, 50);

 
 
 
 
    void OnGUI (){
        if (GUI.Button (new Rect (10,10, 50, 50),"TB" )) 
        { building = (GameObject)Resources.Load("Towers/TowerBullet");
		}
		
		if (GUI.Button (new Rect (60,10, 50, 50),"TL" )) {
            building = (GameObject)Resources.Load("Towers/TowerLaser");
		}

        if (GUI.Button(new Rect(110, 10, 50, 50), "TG")) {
            building = (GameObject)Resources.Load("Towers/TowerGatling");
        }

        if (GUI.Button(new Rect(160, 10, 50, 50), "T4B")) {
            building = (GameObject)Resources.Load("Towers/TowerFourBurrelGun");
        }

        if (GUI.Button(new Rect(210, 10, 50, 50), "TN")) {
            building = (GameObject)Resources.Load("Towers/TowerNova");
        }
 
     isHoverGUI = rect.Contains( Event.current.mousePosition );
    }
 
    void Update () {
 
 
    if(Input.GetMouseButtonDown(0)&& !isHoverGUI){
 
 //   var hit = RaycastHit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	RaycastHit hit;
 
    if(Physics.Raycast(ray, out hit) && hit.collider.tag == "spawnarea"){
 	if(building != null)Instantiate(building,hit.point,Quaternion.identity);
    building = null;
         }
        }
}}