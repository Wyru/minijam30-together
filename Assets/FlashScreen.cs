using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScreen : MonoBehaviour
{
    public Player.PlayerLife playerOne;
    public Player.PlayerLife playerTwo;

    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        playerOne.OnTakeDamage += Flash;
        playerTwo.OnTakeDamage += Flash;
    }   

    void Flash()
    {
        _animator.SetTrigger("Play");
    }
}
