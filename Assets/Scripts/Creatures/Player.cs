using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class Player : MonoBehaviour
{
	[SerializeField] public Creature Creature;
	public PlayerInputs PlayerInput;
	public PlayerInput PlayerInputAsset;
	public CharacterController Controller;

	[HideInInspector]
	public bool Grounded;
	private float GroundedOffset = -0.14f;
	private float GroundedRadius = 0.5f;
	[SerializeField] private LayerMask GroundLayers;

	private void Update()
	{
		GroundedCheck();
	}

	private void GroundedCheck()
	{
		Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
		Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
	}
}
