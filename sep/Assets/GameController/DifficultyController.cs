using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DifficultyController : MonoBehaviour {

    [SerializeField]
    private NPCTemplateSpawner spawner;
    [SerializeField]
    private int scoreToNextTrace = 3000;
    [SerializeField]
    private int scoreToHarderNpc = 1000;
    [SerializeField]
    private float harderNpcMultiplier = 1.2f;
    [SerializeField]
    private int scoreHigherNpcFrequency = 2000;
    [SerializeField]
    private float npcFrequencyMultiplier = 1.05f;

    // These values just contain current states of scores
    private int traceCounter;
    private int healthCounter;
    private int freqCounter;

    void Start() {
        
    }
    
    public void ScoreChanged(int newScore) {
        traceCounter += newScore;
        healthCounter += newScore;
        freqCounter += newScore;
        
        // Next Trace check
        if (traceCounter >= scoreToNextTrace) {
            traceCounter = 0;
            spawner.OpenRandomTrace();
        }

        // Harder NPC check
        if (healthCounter >= scoreToHarderNpc) {
            healthCounter = 0;
            var npch = spawner.TemplateNPC.GetComponent<NPCHealth>();
            npch.Health = (int)(npch.Health * harderNpcMultiplier);
        }

        // Higher NPC Frequency check
        if (freqCounter >= scoreHigherNpcFrequency) {
            freqCounter = 0;
            spawner.SpawnDelay = spawner.SpawnDelay * npcFrequencyMultiplier;
        }
    }
	
	
}
