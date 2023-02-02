using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {

        Animator m_Animator;
        Animator weaponAnimator;

        PlayerMovement.State state;

        

        private void Start()
        {
            m_Animator = GetComponent<Animator>();
            m_Animator = GetComponentInChildren<Animator>();
        }

        void Update()
        {
            switch (state)
            {
                case PlayerMovement.State.UpIdle:
                    m_Animator.SetBool("IsWalking", false);
                    m_Animator.SetInteger("Direction", 8);
                break;

                case PlayerMovement.State.UpWalk:
                    m_Animator.SetBool("IsWalking", true);
                    m_Animator.SetInteger("Direction", 8);
                break;

                case PlayerMovement.State.DownIdle:
                    m_Animator.SetBool("IsWalking", false);
                    m_Animator.SetInteger("Direction", 2);
                break;

                case PlayerMovement.State.DownWalk:
                    m_Animator.SetBool("IsWalking", true);
                    m_Animator.SetInteger("Direction", 2);
                break;

                case PlayerMovement.State.RightIdle:
                    m_Animator.SetBool("IsWalking", false);
                    m_Animator.SetInteger("Direction", 6);
                break;

                case PlayerMovement.State.RightWalk:
                    m_Animator.SetBool("IsWalking", true);
                    m_Animator.SetInteger("Direction", 6);
                break;

                case PlayerMovement.State.LeftIdle:
                    m_Animator.SetBool("IsWalking", false);
                    m_Animator.SetInteger("Direction", 4);
                break;

                case PlayerMovement.State.LeftWalk:
                    m_Animator.SetBool("IsWalking", true);
                    m_Animator.SetInteger("Direction", 4);
                break;
            }
        }

        public bool Attack()
        {
            m_Animator.SetTrigger("Attack");
            return true;
        }

        public void SetState(PlayerMovement.State state)
        {
            this.state = state;
        }

        public void SetIntangible(bool isIntangible)
        {
            m_Animator.SetBool("IsIntangible", isIntangible);
        }

        public void Dead()
        {
            m_Animator.SetTrigger("Dead");
        }

        public bool IsAttacking()
        {
            return m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack");
        }
    }

}
