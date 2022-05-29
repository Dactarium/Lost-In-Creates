using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PlayerInputs : MonoBehaviour
{
	[Header("Character Input Values")]
	public Vector2 move;
	public Vector2 look;
	public bool jump;
	public bool sprint;
	public bool attack;
	public bool select;


	[Header("Movement Settings")]
	public bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
	[Header("Mouse Cursor Settings")]
	public bool cursorLocked = true;
	public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM
	public void OnMove(InputValue value)
	{
		MoveInput(value.Get<Vector2>());
	}

	public void OnSelect(InputValue value)
	{
		SelectInput(value.isPressed);
	}

	public void OnLook(InputValue value)
	{
		if (cursorInputForLook)
		{
			LookInput(value.Get<Vector2>());
		}
	}

	public void OnJump(InputValue value)
	{
		JumpInput(value.isPressed);
	}

	public void OnSprint(InputValue value)
	{
		SprintInput(value.isPressed);
	}

	public void OnAttack(InputValue value)
	{
		AttackInput(value.isPressed);
	}
#endif

	public void MoveInput(Vector2 newMoveDirection)
	{
		move = newMoveDirection;

		if (newMoveDirection.x > 0)
		{
			GameManager.Instance.blue.canMove = true;
		}
		else if (newMoveDirection.x < 0)
		{
			GameManager.Instance.green.canMove = true;
		}
		else
		{
			GameManager.Instance.green.canMove = false;
			GameManager.Instance.blue.canMove = false;
		}


		if (newMoveDirection.y > 0)
		{
			GameManager.Instance.orange.canMove = true;
		}
		else if (newMoveDirection.y < 0)
		{
			GameManager.Instance.purple.canMove = true;
		}
		else
		{
			GameManager.Instance.purple.canMove = false;
			GameManager.Instance.orange.canMove = false;
		}

	}

	public void LookInput(Vector2 newLookDirection)
	{
		look = newLookDirection;
	}

	public void JumpInput(bool newJumpState)
	{
		jump = newJumpState;
	}

	public void SprintInput(bool newSprintState)
	{
		sprint = newSprintState;
	}

	private void AttackInput(bool newAttackState)
	{
		attack = newAttackState;
	}
	private void SelectInput(bool newSelectInput)
	{
		select = newSelectInput;
	}

#if !UNITY_IOS || !UNITY_ANDROID

	private void OnApplicationFocus(bool hasFocus)
	{
		SetCursorState(cursorLocked);
	}

	private void SetCursorState(bool newState)
	{
		Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
	}
#endif
}
