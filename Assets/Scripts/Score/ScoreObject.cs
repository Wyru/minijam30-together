using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [SerializeField] int score = 0;

    public void Gain()
    {
        ScoreSystem.Instance.AddScore(score);
    }
}
