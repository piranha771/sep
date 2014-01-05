using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

    [SerializeField]
    private int score;

    public int Score { get { return score; } set { score = value; } }

    public void AddScore(int scoreToAdd) {
        score += scoreToAdd;
    }
    
}
