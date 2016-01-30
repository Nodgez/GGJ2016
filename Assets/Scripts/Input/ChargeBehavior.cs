using UnityEngine;
using System.Collections;

public class ChargeBehavior : AbstractBehavior {

	private bool _charging;
	private bool _waiting;
	private float _timer;

	public GameObject effect;
	public float chargePower;
	public float chargingTime = 3;
	public TrailRenderer trail;

	void Start () {
		trail.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		bool readyCharge = false;
		inputState.GetButtonValue (Buttons.Special, out readyCharge);

		if (readyCharge && !_waiting) {
			StartCoroutine (ReadyCharge ());
		}

		if (_charging) {
			body2D.AddForce(new Vector2((float)inputState.direction,0) * chargePower);
			_timer += Time.deltaTime;

			if (_timer >= chargingTime || collisionState.onWall) {
				_timer = 0;
				_charging = false;
				body2D.velocity = Vector2.zero;
				_waiting = false;
				ToggleScripts (true);
				trail.enabled = false;
				body2D.constraints = RigidbodyConstraints2D.FreezeRotation;
			}
				
		}
	}

	IEnumerator ReadyCharge()
	{
		ToggleScripts (false);
		_waiting = true;
		Instantiate (effect);
		body2D.velocity = Vector2.zero;
		body2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
		yield return new WaitForSeconds(0.5f);
		_charging = true;
		trail.enabled = true;
	}
}
