using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WyruMenu
{
    public class Menu : MonoBehaviour
    {
        public bool active;
        public GameObject menu;
        [SerializeField] string up = "";
        [SerializeField] string down = "";
        [SerializeField] string action = "";

        Button[] buttons;

        int numButtons;
        int currentButton;

        void Start()
        {
            buttons = menu.GetComponentsInChildren<Button>();
            numButtons = buttons.Length;
            currentButton = 0;
            buttons[currentButton].Selected(true);
        }


        void Update()
        {
            if(!active)
                return;

            if (Input.GetButtonDown(up))
            {
                NextButton(currentButton-1);
            }
            else if (Input.GetButtonDown(down))
            {
                NextButton(currentButton+1);
            }
            else if (Input.GetButtonDown(action))
            {
                buttons[currentButton].Click();
                AudioManager.Instance.Play("menu_click");
            }
            else
            {
                buttons[currentButton].Selected(true);
            }
        }


        void NextButton(int nextButton){

            if(currentButton > nextButton){
                if(nextButton < 0){
                    nextButton = buttons.Length-1;
                }
            }
            else {
                if(nextButton >= buttons.Length){
                    nextButton = 0;
                }
            }

            AudioManager.Instance.Play("menu_select");
            buttons[currentButton].Selected(false);
            currentButton = nextButton;


        }
    }
}

