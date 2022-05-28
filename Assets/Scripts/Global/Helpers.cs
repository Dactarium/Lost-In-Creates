using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Helpers
{
	private static Camera _camera;

	public static Camera Camera
	{
		get
		{
			if (_camera == null) 
				_camera = Camera.main;
			return _camera;
		}
	}

	public static Transform Camera_p
	{
		get
		{
			if (_camera == null)
				_camera = Camera.main;
			return _camera.transform.parent;
		}
	}

	private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();

	public static WaitForSeconds GetWait(float time)
	{
		if (WaitDictionary.TryGetValue(time, out var wait)) return wait;
		WaitDictionary[time] = new WaitForSeconds(time);
		return WaitDictionary[time];
	}

	private static PointerEventData _eventDataCurrentPosition;
	private static List<RaycastResult> _results;

	public static bool IsOverUI()
	{
		_eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
		_results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
		return _results.Count > 0;
	}

	public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element)
	{
		RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, Camera, out var result);
		return result;
	}

	public static T RandomEnumValue<T>()
	{
		var values = Enum.GetValues(typeof(T));
		int random = UnityEngine.Random.Range(0, values.Length);
		return (T)values.GetValue(random);
	}

	public static Vector2 ClampMaxVector(Vector2 current, float maxHorizontal, float maxVertical)
	{
		Vector2 clampedVector = new Vector2(Mathf.Clamp(current.x, -maxHorizontal, maxHorizontal), Mathf.Clamp(current.y, -maxVertical, maxVertical));
		return clampedVector;
	}

	public static Vector2 ClampMaxVector(Vector2 current, Vector2 maxSpeed)
	{
		Vector2 clampedVector = new Vector2(Mathf.Clamp(current.x, -maxSpeed.x, maxSpeed.x), Mathf.Clamp(current.y, -maxSpeed.y, maxSpeed.y));
		return clampedVector;
	}

	public static float ClampFloat(float current, float min, float max)
	{
		float clampedFloat = Mathf.Clamp(current, min, max);
		if (Mathf.Sign(current) == -1)
			return -clampedFloat;
		return clampedFloat;
	}

	public static float ClampAngle(float lfAngle, float lfMin, float lfMax)
	{
		if (lfAngle < -360f) lfAngle += 360f;
		if (lfAngle > 360f) lfAngle -= 360f;
		return Mathf.Clamp(lfAngle, lfMin, lfMax);
	}

	public static float MinMaxClamp(float current, float min, float max)
	{
		if (current < 0)
		{
			float x = Mathf.Clamp(current, -max, -min);
			return x;
		}
		else if (current > 0)
		{
			float x = Mathf.Clamp(current, min, max);
			return x;
		}
		else
		{
			return min;
		}
	}

	public static float Clamp(float f, float min, float max)
	{
		if (Mathf.Sign(f) == -1)
		{
			f = Mathf.Clamp(f, max, min);
			return f;
		}
		else if (Mathf.Sign(f) == 1)
		{
			f = Mathf.Clamp(f, min, max);
			return f;
		}
		return f;
	}

	public static Vector2 GetScreenBoundary()
	{
		float halfHeight = Camera.orthographicSize;
		float halfWidth = Camera.aspect * halfHeight;
		return new Vector2(halfWidth, halfHeight);
		//Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		//Vector3 screenBounds = Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
	}

	public static int ConvertRange(
	int originalStart, int originalEnd, // original range
	int newStart, int newEnd, // desired range
	int value) // value to convert
	{
		double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
		return (int)(newStart + ((value - originalStart) * scale));
	}
}