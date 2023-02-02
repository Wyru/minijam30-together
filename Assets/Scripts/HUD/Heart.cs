using UnityEngine;

namespace HUD
{
    public class Heart : MonoBehaviour
    {
        Animator m_animator;
        
        public void SetState(int state)
        {
            if(m_animator == null)
            {
                m_animator = GetComponent<Animator>();
            }
            m_animator.SetInteger("State", state);
        }
    }
}

