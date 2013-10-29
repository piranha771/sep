using UnityEngine;
using System.Collections;

public class PrefabSource : MonoBehaviour {
    private GameObject bullet;

	// Use this for initialization
	void Start () {
        bullet = GameObject.Find("Bullet");
        bullet.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// Return a gameobject what should be bullet.
    /// </summary>
    /// <returns>Return a gameobject</returns>
    public GameObject getBullet() {
        return bullet;
    }
}
