using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private Player player;

	[Space(10)]
	[SerializeField] float JumpTimeout = 0.1f;
	[SerializeField] float FallTimeout = 0.15f;

	[SerializeField] private float SpeedChangeRate = 10.0f;

	private float _speed;
	private float _verticalVelocity;
	private float _terminalVelocity = 53.0f;

	private float _jumpTimeoutDelta;
	private float _fallTimeoutDelta;

	private float gravity;

	private void Start()
	{
		_jumpTimeoutDelta = JumpTimeout;
		_fallTimeoutDelta = FallTimeout;
		gravity = player.Creature.gravity;
	}

	private void Update()
	{
		JumpAndGravity();
		Move();
	}

	private void Move()
	{
		float targetSpeed = player.PlayerInput.sprint ? player.Creature.runSpeed : player.Creature.moveSpeed;


		if (player.PlayerInput.move == Vector2.zero) targetSpeed = 0.0f;

		float currentHorizontalSpeed = new Vector3(player.Controller.velocity.x, 0.0f, player.Controller.velocity.z).magnitude;

		float speedOffset = 0.1f;
		float inputMagnitude = player.PlayerInput.analogMovement ? player.PlayerInput.move.magnitude : 1f;

		if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
		{
			_speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

			_speed = Mathf.Round(_speed * 1000f) / 1000f;
		}
		else
		{
			_speed = targetSpeed;
		}

		Vector3 inputDirection = new Vector3(player.PlayerInput.move.x, 0.0f, player.PlayerInput.move.y).normalized;

		if (player.PlayerInput.move != Vector2.zero)
		{
			inputDirection = transform.right * player.PlayerInput.move.x + transform.forward * player.PlayerInput.move.y;
		}
		player.Controller.Move(inputDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
	}

	private void JumpAndGravity()
	{
		if (player.Grounded)
		{
			_fallTimeoutDelta = FallTimeout;

			if (_verticalVelocity < 0.0f)
			{
				_verticalVelocity = -2f;
			}

			if (player.PlayerInput.jump && _jumpTimeoutDelta <= 0.0f)
			{
				_verticalVelocity = Mathf.Sqrt(player.Creature.jumpHeight * -2f * gravity);
			}

			if (_jumpTimeoutDelta >= 0.0f)
			{
				_jumpTimeoutDelta -= Time.deltaTime;
			}
		}
		else
		{
			_jumpTimeoutDelta = JumpTimeout;

			if (_fallTimeoutDelta >= 0.0f)
			{
				_fallTimeoutDelta -= Time.deltaTime;
			}

			player.PlayerInput.jump = false;
		}

		if (_verticalVelocity < _terminalVelocity)
		{
			_verticalVelocity += gravity * Time.deltaTime;
		}
	}
}
