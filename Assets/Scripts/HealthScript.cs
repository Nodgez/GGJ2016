using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public float health = 100;

	public void ModifyHealth(float amount)
	{
		health += amount;
	}
}
