using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class Player : MonoBehaviour, IInteractable, IDamageable
{
	[SerializeField] public Creature Creature;
	public PlayerInputs PlayerInput;
	public PlayerInput PlayerInputAsset;
	public CharacterController Controller;

	[SerializeField] private int health;

	[HideInInspector]
	public bool Grounded;
	private float GroundedOffset = -0.14f;
	private float GroundedRadius = 0.5f;
	[SerializeField] private LayerMask GroundLayers;

	private void Start()
	{
		health = Creature.health;
	}

	private void Update()
	{
		GroundedCheck();
	}

	private void GroundedCheck()
	{
		Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
		Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
	}

	public void Interact()
	{
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Events.OnDead.Invoke();
		}
	}
}
