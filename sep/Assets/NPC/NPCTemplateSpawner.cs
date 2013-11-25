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
    private List<Trace> traces;

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

    public List<Trace> Traces { get { return traces; } }

    // Use this for initialization
    void Start() {
        if (null == templateNPC.GetComponent<WayPointRunner>()) {
            throw new InvalidOperationException("template is invalid! Missing component");
        }
        templateNPC.SetActive(false);
        delay = spawnDelay;
    }

    // Update is called once per frame
    void Update() {
        if (delay <= 0) {
            delay = spawnDelay;
            spawn();
        } else {
            delay -= Time.deltaTime;
        }
    }

    private void spawn() {
        currentNPC = (GameObject)Instantiate(templateNPC);
        currentNPC.SetActive(true);

        Trace currentTrace = GetRandomTrace();

        currentNPC.transform.position = currentTrace.Waypoints[0].transform.position;
        WayPointRunner wpr = currentNPC.GetComponent<WayPointRunner>();
        wpr.Waypoints = currentTrace.Waypoints;
        wpr.DoRun = true;
    }

    /// <summary>
    /// Selects a random trace that is online
    /// </summary>
    /// <returns>The selected trace</returns>
    private Trace GetRandomTrace() {
        List<Trace> onlineTraces = new List<Trace>();
        foreach (var item in traces) {
            if (item.Online) onlineTraces.Add(item);
        }

        return onlineTraces[UnityEngine.Random.Range(0, onlineTraces.Count)];
    }
}
