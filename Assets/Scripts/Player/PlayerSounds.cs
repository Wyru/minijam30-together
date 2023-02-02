using UnityEngine;

namespace Player
{
    public class PlayerSounds : MonoBehaviour
    {
        [SerializeField] string attack = "player_attack";

        public void Attack(){
            AudioManager.Instance.Play(attack);
        }
    }
}