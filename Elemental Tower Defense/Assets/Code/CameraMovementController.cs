using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour {
	public GameObject Camera;

	void Update () {
		if (Input.GetKey (KeyCode.W))
			Move (Vector3.left);

		if (Input.GetKey (KeyCode.S))
			Move (Vector3.right);

		if (Input.GetKey (KeyCode.A))
			Move (-Vector3.forward);

		if (Input.GetKey (KeyCode.D))
			Move (Vector3.forward);
	}

	void Move (Vector3 direction) {
		Camera.transform.Translate (direction * 10 * Time.deltaTime, Space.World);
	}
}