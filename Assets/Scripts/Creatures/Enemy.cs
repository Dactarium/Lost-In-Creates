using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IInteractable
{
	[SerializeField] public Creature creature;
	[SerializeField] NavMeshAgent agent;
	[SerializeField] private Transform target;

	[SerializeField] private Animator animator;

	[HideInInspector]
	public bool canMove = true;

	public enum EnemyState
	{
		follow,
		attack
	}

	public EnemyState state = EnemyState.follow;

	public void Interact()
	{
	}

	private void Update()
	{
		if (canMove)
		{
			agent.SetDestination(target.position);
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
