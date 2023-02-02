using UnityEngine;

namespace HUD
{
    public class PlayerStamina : MonoBehaviour
    {
        public Transform staminaBar;
        public Player.PlayerStamina stamina;
        
        void Update()
        {
            float scale = stamina.Value / stamina.MaxValue;
            staminaBar.localScale = new Vector3(scale,1,1);
        }
    }

}
