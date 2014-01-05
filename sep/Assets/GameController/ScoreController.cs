using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

    [SerializeField]
    private int score;
    [SerializeField]
    private DifficultyController difficultyController;

    public DifficultyController DifficultyController { get { return difficultyController; } set { difficultyController = value; } }

    public int Score { get { return score; } }

    public void AddScore(int scoreToAdd) {
        score += scoreToAdd;
        difficultyController.ScoreChanged(scoreToAdd);
    }
    
}
