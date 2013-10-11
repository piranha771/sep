using UnityEngine;
using System.Collections;
using System;

public class CreatMonster : MonoBehaviour {

    [SerializeField]
    private GameObject preFab;
    private GameObject workMonster;
    [SerializeField]
    private float spawnDelay;
    private float delay;
    [SerializeField]
    private string startWapoint;



    public GameObject PreFab {
        get { return preFab; }
        set {
            if (null == preFab.GetComponent<WayPointRunner>()) {
                throw new InvalidOperationException("preFab is invalid");
            }
            preFab = value;
        }
    }

    public float SpawnDelay { get { return spawnDelay; } set { spawnDelay = value; } }

    public string StartWaipoint { get { return startWapoint; } set { startWapoint = value; } }

	// Use this for initialization
	void Start () {

        if (null == preFab.GetComponent<WayPointRunner>()) {
            throw new InvalidOperationException("preFab is invalid");
        }
        preFab.SetActive(false);
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

        workMonster = (GameObject)Instantiate(preFab);
        workMonster.SetActive(true);
        WayPointRunner scriptWPR = workMonster.GetComponent<WayPointRunner>();
        scriptWPR.StartPoint = startWapoint;
        scriptWPR.DoRun = true;

    }
    
    
}
