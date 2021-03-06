﻿using UnityEngine;
using System.Collections;

public class PrefabSource : MonoBehaviour {
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject radiusRenderer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Return a gameobject what should be bullet.
    /// </summary>
    /// <returns>Return a gameobject</returns>
    public GameObject Bullet() {
        return bullet;
    }
    /// <summary>
    /// Return a gameobject what should be radius renderer of tower
    /// </summary>
    /// <returns>Return a gameobject</returns>
    public GameObject RadiusRenderer() {
        return radiusRenderer;    
    }
}
