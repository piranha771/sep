using UnityEngine;
using System.Collections;

/// <summary>
/// Gives the NPC a specific state and changes the appereance to this state
/// </summary>
public class NPCStateController : MonoBehaviour {

    private const string tagUnknown = "unknown";
    private const string tagGood = "good";
    private const string tagEvil = "enemy";

    [SerializeField]
    private NPCState state = NPCState.Unknown;

    public NPCState State { 
        get { return state; } 
        set { state = value;
            switch (value) {
                case NPCState.Unknown:
                    setLights(Color.white);
                    setModel("goodmodel");
                    tag = tagUnknown;
                    break;
                case NPCState.Good:
                    setLights(new Color(0f, 202f / 255f, 1.0f));
                    setModel("goodmodel");
                    tag = tagGood;
                    break;
                case NPCState.Evil:
                    setLights(Color.red);
                    setModel("evilmodel");
                    tag = tagEvil;
                    break;
                case NPCState.SuperGood:
                    setLights(new Color(0f, 202f / 255f, 1.0f));
                    setModel("goodmodel");
                    tag = tagGood;
                    break;
                case NPCState.SuperEvil:
                    setLights(Color.red);
                    setModel("evilmodel");
                    tag = tagEvil;
                    break;
                default:
                    setLights(Color.white);
                    setModel("goodmodel");
                    tag = tagUnknown;
                    break;
            }
        } 
    }

    public void Start() {
        // Initiallize state
        State = state;
    }

    /// <summary>
    /// Sets all child lights to a specific color
    /// </summary>
    /// <param name="color">The color to change to</param>
    private void setLights(Color color) {
        Light[] lights = GetComponentsInChildren<Light>();
        foreach (var light in lights) {
		    light.color = color;
	    }
    }

    /// <summary>
    /// Enables a child model by tag, while all others will be disabled
    /// </summary>
    /// <param name="tag">The tag of the model to enable</param>
    private void setModel(string tag) {
        MeshRenderer[] renderer = GetComponentsInChildren<MeshRenderer>();
        foreach (var render in renderer) {
            render.enabled =  render.gameObject.tag == tag;
        }
    }
}
