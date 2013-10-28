using UnityEngine;
using System.Collections;

public class buttons : MonoBehaviour {


    Texture2D boxIcon;
    Texture2D sphereIcon;
    Texture2D cylinderIcon;
	GameObject building;
	bool isHoverGUI = false; 
	Rect rect =new Rect (10,10, 110, 50);

 
 
 
 
    void OnGUI () 
    {
        if (GUI.Button (new Rect (10,10, 50, 50),"1" )) 
        { building = GameObject.Find("TowerBullet");
		}
		
		if (GUI.Button (new Rect (60,10, 50, 50),"2" )) 
        { building = GameObject.Find("TowerLaser");
		}
 
     isHoverGUI = rect.Contains( Event.current.mousePosition );
    }
 
    void Update () {
 
 
    if(Input.GetMouseButtonDown(0)&& !isHoverGUI)
    {
 
 //   var hit = RaycastHit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	RaycastHit hit;
 
    if(Physics.Raycast(ray, out hit) && hit.collider.tag == "spawnarea")
    {
 	Instantiate(building,hit.point,Quaternion.identity);
 
 
    
           }
        }
}}