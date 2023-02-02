using UnityEngine;
using Player;
public class AttackInputController : MonoBehaviour
{
    public PlayerMovement player01;
    public PlayerMovement player02;
    public PlayerStamina playerStamina;
    [SerializeField] float attackCost = 20f;
    [SerializeField] string attackButton = "";
    
    bool running = true;
    void Update()
    {
        if(!running)
            return;

        if (Input.GetButtonDown(attackButton))
        {
            if(playerStamina.Use(attackCost)){
                player01.Attack();
                player02.Attack();
            }
        }
    }

    public void SetRunning(bool b)
    {
        running = b;
    }
}
