using UnityEngine;
using Player;

public class MovementInputController : MonoBehaviour
{
    public PlayerMovement player;
    [SerializeField] string up = "";
    [SerializeField] string down = "";
    [SerializeField] string left = "";
    [SerializeField] string right = "";

    bool running = true;


    void Update()
    {
        if(!running)
            return;
        
        if (Input.GetButton(up))
        {
            player.SetVerticalMovement(1);
        }
        else if (Input.GetButton(down))
        {
            player.SetVerticalMovement(-1);
        }
        else
        {
            player.SetVerticalMovement(0);
        }

        if (Input.GetButton(left))
        {
            player.SetHorizontalMovement(-1);
        }
        else if (Input.GetButton(right))
        {
            player.SetHorizontalMovement(1);
        }
        else
        {
            player.SetHorizontalMovement(0);
        }
    }


    public void SetRunning(bool b)
    {
        running = b;
    }
}
