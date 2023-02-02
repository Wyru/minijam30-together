using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HUD
{
    public class PlayerLife : MonoBehaviour
    {
        public GameObject heartContainer;
        public GameObject heartPrefab;

        public Player.PlayerLife player;

        int numberOfHearts;

        List<Heart> hearts;

        private void Start() {

            numberOfHearts = player.MaxLife/2;
            hearts = new List<Heart>();

            for (int i = 0; i < numberOfHearts; i++)
            {
                Heart heart = Instantiate(heartPrefab, heartContainer.transform).GetComponent<Heart>();
                heart.SetState(2);
                hearts.Add(heart);
            }

            player.OnTakeDamage += UpdateHUD;
            player.OnRecoverLife += UpdateHUD;
        }

        private void UpdateHUD()
        {
            for (int i = 0; i < numberOfHearts; i++)
            {
                if((i+1)*2 <= player.Life)
                {
                    hearts[i].SetState(2);
                }
                else if((i+1)*2-1 <= player.Life)
                {
                    hearts[i].SetState(1);
                }
                else{
                     hearts[i].SetState(0);
                }
            }
        }
    }
}

