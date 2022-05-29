using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IInteractable
{
	[SerializeField] public Creature creature;
	[SerializeField] NavMeshAgent agent;
	[SerializeField] private Transform target;

	[SerializeField] private Animator animator;

	public bool canMove = false;

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
	}

	protected virtual void Update()
	{
		if (canMove)
		{
			agent.isStopped = false;
			agent.SetDestination(target.position);
		}
		else
		{
			agent.isStopped = true;
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
