using UnityEngine;
using System;

public class ScoreSystem : MonoBehaviour
{
    int highScore;
    int score;
    public event Action<int, int> OnGainScore;
    static ScoreSystem  _instance;
    public static ScoreSystem Instance{
        get {
             return _instance;
        }
    }

    public int Score{
        get{
            return score;
        }
    }

    private void Awake() {
        _instance = this;
    }

    void Start()
    {
        score = 0;
        highScore = GetHighScore();
    }

    void OnGameEnd()
    {
        if(score > highScore)
        {
            UpdateHighscore(score);
            highScore = score;
        }
    }

    void UpdateHighscore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public void AddScore(int amount)
    {
        score += amount;

        OnGainScore?.Invoke(amount, score);

    }
}
