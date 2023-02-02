using UnityEngine;
using UnityEngine.Events;
using System;

public class SlimeBehavior : MonoBehaviour
{
    [SerializeField] float maxLife;
    [SerializeField] float life;
    [SerializeField] float minDistance = 1f;
    [SerializeField] int attack = 1;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float attackCoolDown = 1f;
    public LayerMask whatIsPlayer;
    [SerializeField] float damageStun = 1f;
    [SerializeField] float damagePushback = 1f;
    [SerializeField, Range(0, 1)] float pushBackTime = 1f;

    public ParticleSystem blood;

    public enum State
    {
        Walking,
        Attacking,
        TakingDamage,
        Dying
    }

    public State state;

    public float speed;


    public UnityEvent OnDead;

    Transform target;

    Rigidbody2D m_Rigidbody;
    Animator m_Animator;


    bool dead;

    public bool Dead{
        get{
            return dead;
        }
    }

    float timer;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();

        Player.PlayerMovement[] players = FindObjectsOfType<Player.PlayerMovement>();
        Player.PlayerMovement playerTarget = players[UnityEngine.Random.Range(0, players.Length)];

        if(playerTarget.IsDead){
            foreach (Player.PlayerMovement player in players)
            {
                if(!player.IsDead){
                    playerTarget = player;
                }
            }
        }
        
        target = playerTarget.transform;
    }

    void Update()
    {

        switch (state)
        {
            case State.Walking:
                UpdateMovement();
                break;

            case State.Attacking:
                Attaking();
                break;

            case State.TakingDamage:
                TakingDamage();
                break;

            case State.Dying:
                Dying();
                break;

        }
    }

    void UpdateMovement()
    {
        float distance = (transform.position - target.position).magnitude;

        if (distance > minDistance * minDistance)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            timer = 0;
        }
        else
        {
            state = State.Attacking;
        }

        m_Rigidbody.velocity = Vector2.zero;

    }

    public void TakeDamage()
    {
        life -= 1;
        state = State.TakingDamage;
        timer = 0;
        blood.Play();
        m_Animator.SetBool("TakingDamage", true);
        if (life <= 0)
        {
            if (!dead)
            {
                // on dead
                OnDead?.Invoke();
                m_Animator.SetTrigger("Die");
                Destroy(GetComponent<BoxCollider2D>());
                dead = true;
                state = State.Dying;
            }
        }
    }

    void TakingDamage()
    {
        timer += Time.deltaTime;
        if (timer / damageStun > pushBackTime)
        {
            m_Rigidbody.velocity = Vector2.zero;
        }
        if (timer > damageStun)
        {
            m_Animator.SetBool("TakingDamage", false);
            state = State.Walking;
        }
    }

    public void Attaking()
    {
        if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Slime@Attack"))
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                m_Animator.SetTrigger("Attack");
                timer = attackCoolDown;
            }
            else
            {
                float distance = (transform.position - target.position).magnitude;

                if (distance > minDistance * minDistance)
                    state = State.Walking;
            }
        }
        else
        {
            Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, attackRange, whatIsPlayer);

            foreach (Collider2D player in players)
            {
                player.GetComponent<Player.PlayerLife>().TakeDamage(attack);
            }
        }
    }


    public void Dying()
    {
        if(m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Slime@Death"))
        {
            m_Rigidbody.velocity = Vector2.zero;

            // if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9)
            // {
            //     Destroy(this.gameObject);
            // }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (state != State.TakingDamage && state != State.Dying)
            {
                TakeDamage();
                DamagePushback(other.gameObject);
            }
        }
    }


    void DamagePushback(GameObject other)
    {
        Player.PlayerMovement player = other.transform.parent.parent.GetComponent<Player.PlayerMovement>();

        Vector3 dir = Vector3.zero;

        if (player.state.ToString().Contains("Up"))
        {
            dir = new Vector2(0, 1);
        }
        else if (player.state.ToString().Contains("Down"))
        {
            dir = new Vector2(0, -1);
        }
        else if (player.state.ToString().Contains("Left"))
        {
            dir = new Vector2(-1, 0);
        }
        else if (player.state.ToString().Contains("Right"))
        {
            dir = new Vector2(1, 0);
        }

        m_Rigidbody.AddForce(damagePushback * dir, ForceMode2D.Impulse);
    }


    private void OnDrawGizmosSelected() {
        Color color = Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
