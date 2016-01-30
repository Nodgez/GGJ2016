using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InputState : MonoBehaviour {

	private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();
	public Vector3 gesturePosition = Vector3.zero;
	public Direction direction = Direction.right;

	public float absX;
	public float absY;

	private Rigidbody2D body2D;

	void Awake()
	{
		body2D = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		gesturePosition = Input.mousePosition;
	}

	void FixedUpdate()
	{
		absX = Mathf.Abs (body2D.velocity.x);
		absY = Mathf.Abs (body2D.velocity.y);
	}

	public void SetButton(Buttons key,bool value)
	{
		if (!buttonStates.ContainsKey (key))
			buttonStates.Add (key, new ButtonState ());

		ButtonState buttonState = buttonStates [key];
		//Debug.Log("Button Val = " + buttonState.value);
		if (buttonState.value && !value)
			buttonState.holdTime = 0;
		else if (buttonState.value && value)
			buttonState.holdTime += Time.deltaTime;
		buttonState.value = value;
	}

	public void GetButtonValue(Buttons key, out bool value)
	{
		if (buttonStates.ContainsKey (key))
			value = buttonStates [key].value;
		else {
			Debug.Log(key + " Not Mapped");
			value = false;
		}
	}

	public float GetButtonHoldTime(Buttons key)
	{
		float holdTime;
		if (buttonStates.ContainsKey (key))
			holdTime = buttonStates [key].holdTime;
		else {
			Debug.Log("Not Mapped");
			holdTime = 0;
		}
		return holdTime;
	}
}

public class ButtonState
{
	public bool value;
	public float holdTime = 0;
}

public enum Direction
{
	left = -1,
	right = 1
}
