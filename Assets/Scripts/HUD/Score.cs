using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HUD
{
    public class Score : MonoBehaviour
    {
        public TextMeshProUGUI score;
        // Start is called before the first frame update
        void Start()
        {
            ScoreSystem.Instance.OnGainScore += UpdateScore;
        }
        void UpdateScore(int amount, int score)
        {
            this.score.SetText(score.ToString());
        }
    }
}