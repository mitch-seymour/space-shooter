using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public float speed;

	// this will be executed on the first frame the object is instantiated
	void Start () {
		Rigidbody boltRb = GetComponent<Rigidbody> ();
		boltRb.velocity = transform.forward * speed;
	}

}
