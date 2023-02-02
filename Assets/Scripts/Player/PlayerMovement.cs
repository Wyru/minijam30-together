using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed = 1f;
        Rigidbody2D m_rigidbody;
        PlayerAnimator m_playerAnimator;
        PlayerLife m_playerLife;
        float horizontalMovement;
        float verticalMovement;
        Vector2 movement;

        public bool isMoving{
            get;
            private set;
        }

        public enum State
        {
            UpIdle,
            UpWalk,
            DownIdle,
            DownWalk,
            RightIdle,
            RightWalk,
            LeftIdle,
            LeftWalk
        }

        public State state;
        State lastState;

        bool isDead;

        public bool IsDead{
            get{
                return isDead;
            }
        }

        public UnityEvent OnAttack;

        void Start()
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
            m_playerAnimator = GetComponent<PlayerAnimator>();
            m_playerLife = GetComponent<PlayerLife>();

            state = State.DownIdle;
            lastState = state;

            m_playerLife.OnDie += Dead;
        }

        private void Update()
        {
            UpdatePlayerState();
            UpdatePlayerAnimation();
        }

        void FixedUpdate()
        {
            if (isDead){
                m_rigidbody.velocity = Vector2.zero;
                return;
            }

            movement = new Vector2(horizontalMovement, verticalMovement).normalized * speed;
            if(m_playerAnimator.IsAttacking()){
                movement = Vector2.zero;
            }
            isMoving = movement.magnitude != 0;
            m_rigidbody.velocity = movement;
        }

        public void SetHorizontalMovement(float movement)
        {
            horizontalMovement = movement;
        }


        public void SetVerticalMovement(float movement)
        {
            verticalMovement = movement;
        }

        void UpdatePlayerState()
        {
            lastState = state;

            if (horizontalMovement == 1)
            {
                state = State.RightWalk;
            }
            else if (horizontalMovement == -1)
            {
                state = State.LeftWalk;
            }
            else if (verticalMovement == 1)
            {
                state = State.UpWalk;

            }
            else if (verticalMovement == -1)
            {
                state = State.DownWalk;
            }
            else
            {
                if (lastState == State.UpWalk)
                {
                    state = State.UpIdle;
                }
                else if (lastState == State.DownWalk)
                {
                    state = State.DownIdle;
                }
                else if (lastState == State.LeftWalk)
                {
                    state = State.LeftIdle;
                }
                else if (lastState == State.RightWalk)
                {
                    state = State.RightIdle;
                }
            }
        }
        
        void UpdatePlayerAnimation()
        {
            m_playerAnimator.SetState(state);
            m_playerAnimator.SetIntangible(m_playerLife.IsIntangible);
        }
        
        public virtual void Attack()
        {
            if(!isDead){
                m_playerAnimator.Attack();
                OnAttack?.Invoke();
            }
        }

        public void Dead(){
            isDead = true;
            m_playerAnimator.Dead();
        }

    }

}