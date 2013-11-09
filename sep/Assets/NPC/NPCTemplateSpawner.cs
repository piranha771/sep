using UnityEngine;
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
        templateNPC = (GameObject) Resources.Load("NPC/NPCBit");
        if (null == templateNPC.GetComponent<WayPointRunner>()) {
            throw new InvalidOperationException("template is invalid! Missing component");
        }
        //waypoints = new ArrayList();
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
        WayPointRunner scriptWPR = currentNPC.GetComponent<WayPointRunner>();
        scriptWPR.Waypoints = waypoints;
        scriptWPR.DoRun = true;
    }
}
