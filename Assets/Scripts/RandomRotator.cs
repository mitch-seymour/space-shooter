using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
	public float tumble;

	void Start() {
		Rigidbody asteroidRb = GetComponent<Rigidbody> ();
		asteroidRb.angularVelocity = Random.insideUnitCircle * tumble;
	}
}
