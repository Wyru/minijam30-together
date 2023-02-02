using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    bool pressStart;
    [SerializeField] string playerAction = "";

    public Animator backgroundAnimator;
    public Animator pressStartButtonAnimator;

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!pressStart){

            if(Input.GetButtonDown(playerAction)){
                pressStartButtonAnimator.SetTrigger("start");
                backgroundAnimator.SetTrigger("start");

                pressStart = true;
            }
        }
        else{
            if(pressStartButtonAnimator.gameObject.activeSelf){
                if(pressStartButtonAnimator.GetCurrentAnimatorStateInfo(0).IsName("PressStart@Start") && pressStartButtonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9){
                    pressStartButtonAnimator.gameObject.SetActive(false);
                }
            }

            if(backgroundAnimator.GetCurrentAnimatorStateInfo(0).IsName("MenuBackgroung@Menu") && backgroundAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9){
                SceneManager.LoadScene(1);
            }
        }
    }
}
