using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
public abstract class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] public Creature creature;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private Transform target;

    [SerializeField] private Animator animator;
    [SerializeField] private SO_Sound moveSound;

    public bool canMove = false;

    private AudioSource source;

    public enum EnemyState
    {
        follow,
        attack
    }

    public EnemyState state;

    public void Interact()
    {
    }

    protected virtual void Awake()
    {
        if (target == null)
        {
            target = FindObjectOfType<Player>().transform;
        }

        source = GetComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        agent.isStopped = true;
        canMove = false;
    }

    protected virtual void Update()
    {
        if (canMove)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            animator.SetBool("IsAttacking", true);
            //if (!source.isPlaying) moveSound.PlaySound(source);
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("IsAttacking", false);
        }
    }

    public void ChangeState(EnemyState state)
    {
        this.state = state;
        switch (state)
        {
            case EnemyState.follow:
                Follow();
                break;
            case EnemyState.attack:
                break;
            default:
                break;
        }
    }

    private void Follow()
    {
        animator.SetBool("IsAttacking", true);
        canMove = true;
    }

    public void Attack(IDamageable damageable)
    {
        canMove = false;
        animator.SetBool("IsAttacking", false);
        damageable.TakeDamage(creature.damage);
    }
}
