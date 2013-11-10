using UnityEngine;
using System.Collections;

public class CPUHeatController : MonoBehaviour {

    public readonly float NPCHealthMultiplier = 2f; 

    [SerializeField]
    private float normalTemp = 40;
    [SerializeField]
    private float meltdownTemp = 120;
    [SerializeField]
    private float cooldownRatePerSecond = 1f;
    [SerializeField]
    private float currentTemp;
    [SerializeField]
    private Color coolColor;
    [SerializeField]
    private Color heatColor;

    private float deltaTime = 0;
    private Color currentColor;

    public float NormalHeat { get { return normalTemp; } set { normalTemp = value; } }
    public float MeltdownTemp { get { return meltdownTemp; } set { meltdownTemp = value; } }
    public float CooldownRatePerSecond { get { return cooldownRatePerSecond; } set { cooldownRatePerSecond = value; } }
    public float CurrentTemp { get { return currentTemp; } set { currentTemp = value; } }
    public Color CoolColor { get { return coolColor; } set { coolColor = value; } }
    public Color HeatColor { get { return heatColor; } set { heatColor = value; } }

	void Start () {
        currentTemp = normalTemp;
	}
	
	void Update () {
        deltaTime += Time.deltaTime;
        if (deltaTime >= 1.0) {
            deltaTime = 0;

            currentTemp -= cooldownRatePerSecond;
            currentTemp = Mathf.Max(currentTemp, normalTemp);
        }
	}

    /// <summary>
    /// Called when a evil NPC bit hits the cpu
    /// </summary>
    /// <param name="npcEvilBit"></param>
    public void Impact(GameObject npcEvilBit) {
        Health health = npcEvilBit.GetComponent<Health>();
        currentTemp += 10;//(health.CurrentHealth * NPCHealthMultiplier);



        GameObject[] go = GameObject.FindGameObjectsWithTag("cpuglowmodel");
        
        foreach (var obj in go) {
            Color oldCol = obj.renderer.material.color;
            Color newCol =  new Color(oldCol.r * 1.1f, oldCol.g * 0.9f, oldCol.b * 0.9f);
            obj.renderer.material.color = newCol;
        
        }
        go = GameObject.FindGameObjectsWithTag("cpuglowparticle");
        foreach (var obj in go) {
            Color oldCol = obj.renderer.material.GetColor("_TintColor");
            Color newCol = new Color(oldCol.r * 1.1f, oldCol.g * 0.9f, oldCol.b * 0.9f);
            obj.renderer.material.SetColor("_TintColor", newCol);
        }

        Color oldCol2 = GetComponentInChildren<Light>().color;
        GetComponentInChildren<Light>().color =  new Color(oldCol2.r + 0.1f, oldCol2.g * 0.9f, oldCol2.b * 0.9f);
    }
	
	public float getCurrentTemp(){
		return currentTemp;
	}
}
