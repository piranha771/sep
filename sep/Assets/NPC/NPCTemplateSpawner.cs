﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class NPCTemplateSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject templateNPC;
    private GameObject currentNPC;
    [SerializeField]
    private float spawnDelay;
    private float delay;
    [SerializeField]
    private List<Transform> waypoints;

    public GameObject TemplateNPC {
        get { return templateNPC; }
        set {
            if (null == templateNPC.GetComponent<WayPointRunner>()) {
                throw new InvalidOperationException("template is invalid! Missing component");
            }
            templateNPC = value;
        }
    }

    public float SpawnDelay { get { return spawnDelay; } set { spawnDelay = value; } }

    public List<Transform> Waypoints { get { return waypoints; } set { waypoints = value; } }

	// Use this for initialization
	void Start () {
        if (null == templateNPC.GetComponent<WayPointRunner>()) {
            throw new InvalidOperationException("template is invalid! Missing component");
        }
        templateNPC.SetActive(false);
        delay = spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
        if (delay <= 0) {
            delay = spawnDelay;
            spawn();
        }
        else {
            delay -= Time.deltaTime;
        }
	}

    private void spawn() {
        currentNPC = (GameObject)Instantiate(templateNPC);
        currentNPC.SetActive(true);
        currentNPC.transform.position = waypoints[0].position;
        WayPointRunner wpr = currentNPC.GetComponent<WayPointRunner>();
        wpr.Waypoints = waypoints;
        wpr.DoRun = true;
    }

    /* SAVED Code from GuiTowerSpawnMenu
     *         Rect box = new Rect(Screen.width / 2f - (Screen.width * 0.25f) / 2f, Screen.height * 0.85f, Screen.width * 0.22f, Screen.height * 0.10f);
        GUI.Box(box, "Towers");

        Rect lastButton = new Rect(box.xMin + box.width * 0.05f, box.yMin + box.height * 0.30f, box.height * 0.60f, box.height * 0.60f);
        if (GUI.Button(lastButton, "TB")) {
            selectedTower = towerBullet;
		}

        lastButton = new Rect(lastButton.xMax + box.width * 0.05f, lastButton.yMin, lastButton.width, lastButton.height);
		if (GUI.Button (lastButton,"TL" )) {
            selectedTower = towerLaser;
		}

        lastButton = new Rect(lastButton.xMax + box.width * 0.05f, lastButton.yMin, lastButton.width, lastButton.height);
        if (GUI.Button(lastButton, "TG")) {
            selectedTower = towerGatling;
        }

        lastButton = new Rect(lastButton.xMax + box.width * 0.05f, lastButton.yMin, lastButton.width, lastButton.height);
        if (GUI.Button(lastButton, "T4B")) {
            selectedTower = towerFourBurrelGun;
        }

        lastButton = new Rect(lastButton.xMax + box.width * 0.05f, lastButton.yMin, lastButton.width, lastButton.height);
        if (GUI.Button(lastButton, "TN")) {
            selectedTower = towerNova;
        }
 
        isHoverGUI = rect.Contains( Event.current.mousePosition );
     * */
}
