using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] string getHeartSound = "";
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<Player.PlayerLife>().RecoveryLife(1f);
            AudioManager.Instance.Play(getHeartSound);
            Destroy(gameObject);
        }
    }
}
