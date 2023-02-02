using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public List<Player.PlayerLife> players;
    public UnityEvent OnGameOver;

    static LevelController _instance;

    public static LevelController Instance{
        get{
            return _instance;
        }
    }

    bool gameOver;


    public GameObject OverScreen;

    private void Awake() {
        _instance = this;
    }

    void Update()
    {
        if (!gameOver)
        {
            if (players.TrueForAll((Player.PlayerLife player) =>
            {
                return player.IsDead();
            }))
            {
                OnGameOver?.Invoke();
                OverScreen.SetActive(true);
                gameOver = true;
            }
        }

    }
}
