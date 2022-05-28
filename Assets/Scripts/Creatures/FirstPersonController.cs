using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class FirstPersonController : MonoBehaviour
{
	[SerializeField] private Player player;
	public GameObject CinemachineCameraTarget;
	public float TopClamp = 90.0f;
	public float BottomClamp = -90.0f;

	private float _cinemachineTargetPitch;

	public float RotationSpeed = 1.0f;

	private float _rotationVelocity;

	private const float _threshold = 0.01f;

	private bool IsCurrentDeviceMouse => player.PlayerInputAsset.currentControlScheme == "KeyboardMouse";


	private void LateUpdate()
	{
		CameraRotation();
	}

	private void CameraRotation()
	{
		if (player.PlayerInput.look.sqrMagnitude >= _threshold)
		{
			float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

			_cinemachineTargetPitch += player.PlayerInput.look.y * RotationSpeed * deltaTimeMultiplier;
			_rotationVelocity = player.PlayerInput.look.x * RotationSpeed * deltaTimeMultiplier;

			_cinemachineTargetPitch = Helpers.ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

			CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

			transform.Rotate(Vector3.up * _rotationVelocity);
		}
	}
}
