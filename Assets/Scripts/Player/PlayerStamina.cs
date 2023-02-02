
using UnityEngine;


namespace Player
{
    public class PlayerStamina : MonoBehaviour
    {
        [SerializeField] float maxValue = 10f;
        [SerializeField] float value = 10f;

        [SerializeField] float idleRegenRate = 1;
        [SerializeField] float walkingRegenRate = 1;

        public float MaxValue
        {
            get
            {
                return maxValue;
            }
        }

        public float Value
        {
            get
            {
                return value;
            }
        }

        public PlayerMovement[] players;

        void Update()
        {
            bool idle = true;

            for (int i = 0; i < players.Length; i++)
            {
                if (!players[i].isMoving)
                {
                    idle = true;
                    break;
                }
                else
                {
                    idle = false;
                }
            }

            value = Mathf.Min(value + (idle ? idleRegenRate : walkingRegenRate) * Time.deltaTime, maxValue);
        }

        public bool Use(float amount)
        {
            if (value > amount)
            {
                value -= amount;
                return true;
            }

            return false;
        }
    }
}

