using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;

	void Update () {
		if (Input.GetButton("Jump") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource> ().Play ();
		}
	}

	// for all physics actions
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// apply movement
		Rigidbody playerRb = GetComponent<Rigidbody> ();
		playerRb.velocity = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;

		// make sure the player's position is within the play area
		playerRb.position = new Vector3(
			Mathf.Clamp(playerRb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(playerRb.position.z, boundary.zMin, boundary.zMax)
		);

		playerRb.rotation = Quaternion.Euler (0.0f, 0.0f, playerRb.velocity.x * -tilt);
	}
}
