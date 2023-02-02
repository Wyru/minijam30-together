using UnityEngine;
using UnityEngine.Events;

namespace WyruMenu
{
    public class Button : MonoBehaviour
    {
        public UnityEvent OnClick;
        Menu _menu;
        Animator _animator;
        
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Selected(bool selected)
        {
            _animator?.SetBool("selected", selected);
        }

        public void Click()
        {
            _animator?.SetTrigger("click");
            OnClick?.Invoke();
        }

    }
}

