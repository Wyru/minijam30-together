using UnityEngine;
using System;

namespace Player
{


    public class PlayerLife : MonoBehaviour
    {
        [SerializeField] int maxLife = 3;
        [SerializeField] int life = 3;

        [SerializeField] float intangibleTime = 1f;

        bool dead;

        bool isIntangible;

        public bool IsIntangible{
            get{
                return isIntangible;
            }
        }

        float timer;

        public event Action OnDie;
        public event Action OnTakeDamage;
        public event Action OnRecoverLife;

        public int MaxLife
        {
            get
            {
                return maxLife;
            }
        }

        public int Life
        {
            get
            {
                return life;
            }
        }

        public void TakeDamage(float amount)
        {
            if(isIntangible || dead) return;
            
            life = (int)Mathf.Max(life - amount, 0);

            timer = intangibleTime;
            isIntangible = true;

            if (OnTakeDamage != null)
            {
                OnTakeDamage.Invoke();
            }

            if (life == 0)
            {
                if (!dead)
                {
                    if (OnDie != null)
                    {
                        OnDie.Invoke();
                    }

                    dead = true;
                }
            }
        }

        public void RecoveryLife(float amount)
        {
            life = (int)Mathf.Min(life + amount, maxLife);

            if (OnRecoverLife != null)
            {
                OnRecoverLife.Invoke();
            }
        }

        private void Update() {
            if(isIntangible)
            {
                timer -= Time.deltaTime;
                if(timer < 0)
                {
                    isIntangible = false;
                }
            }
        }


        public bool IsDead()
        {
            return dead;
        }
    }
}