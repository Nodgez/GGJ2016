using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private MoveBehavior movement;
	private AttackBehavior attack;
	private Animator animator;

	void Awake () {
		inputState = GetComponent<InputState> ();
		movement = GetComponent<MoveBehavior> ();
		attack = GetComponent<AttackBehavior> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inputState.absY > 0)
			ChangeAnimation (3);
		else {
			if (inputState.absX == 0)
				ChangeAnimation (0);

			if (inputState.absX > 0)
				ChangeAnimation (1);
		}
			
		if (attack.hitBox.activeSelf) {
			ChangeAnimation (2);
		}
	}

	void ChangeAnimation(int val)
	{
		animator.SetInteger ("AnimState", val);
	}
}
