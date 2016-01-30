using UnityEngine;
using System.Collections;

public class MeeseeksTimer : MonoBehaviour {

	public float lifetime;
	public GameObject target;
	private float _timer;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime;

		if (_timer > lifetime) {
			target.SetActive (false);
		}
	}

	void OnDisable()
	{
		_timer = 0;
	}
}
