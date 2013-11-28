using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCHealth : MonoBehaviour {

    [SerializeField]
    private int health = 100;

    private int currentHealth;
    private ParticleSystem npcParticle;

    private Dictionary<MeshRenderer, Color> rendererColors;
    private Dictionary<Light, Color> lightColors;

    //Colorisation
    public int Health { get { return Mathf.Max(currentHealth, 0); } set { currentHealth = value; } }
    public bool IsDead { get { return currentHealth == 0; } set { currentHealth = 0; } }
    public float Percentage { 
        get { return (float)currentHealth / (float)health; } 
        set { health = Mathf.FloorToInt(health * value * 100); } 
    }

	void Start () {
        currentHealth = health;
        npcParticle = transform.GetComponent<ParticleSystem>();
	}
	
	void Update () {     
        if (currentHealth == 0) {         
            Destroy(gameObject);
        }
	}

    public void TakeDamage(int damage) {
        if (npcParticle != null) {
            npcParticle.Play();
        }
   
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        if (!IsDead) {
            if (rendererColors == null) setupColoring();
            colorize();
        }
    }

    /// <summary>
    /// Creates Dictionarys of colors to change and saves the standard values
    /// </summary>
    private void setupColoring() {
        rendererColors = new Dictionary<MeshRenderer, Color>();
        lightColors = new Dictionary<Light, Color>();

        MeshRenderer[] renderer = GetComponentsInChildren<MeshRenderer>();
        foreach (var item in renderer) {
            rendererColors.Add(item, item.renderer.material.color);
        }
        Light[] lights = GetComponentsInChildren<Light>();
        foreach (var item in lights) {
            lightColors.Add(item, item.color);
        }
    }

    /// <summary>
    /// Colorizes based on the health
    /// </summary>
    private void colorize() {
        foreach (var item in rendererColors) {
            if (!item.Equals(null)) {
                item.Key.material.color = new Color(item.Value.r * Percentage + 0.1f, item.Value.g * Percentage, item.Value.b * Percentage);
            }
        }
        foreach (var item in lightColors) {
            if (!item.Equals(null)) {
            item.Key.color = new Color(item.Value.r * Percentage + 0.1f, item.Value.g * Percentage, item.Value.b * Percentage);
            }
        }
    }




}
