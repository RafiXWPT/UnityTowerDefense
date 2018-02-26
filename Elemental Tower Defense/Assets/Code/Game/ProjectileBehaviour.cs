using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

	public Transform Target;
	public float ProjectileSpeed;

	public bool Ready = false;
	public ProjectileBehaviour (Transform target, float projectileSpeed) {
		Target = target;
		ProjectileSpeed = projectileSpeed;
	}

	// Update is called once per frame
	void Update () {
		if (!Ready)
			return;

		transform.position = Vector3.MoveTowards (transform.position, Target.position, ProjectileSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Monster") {
			Debug.Log (other.transform.name);
			Destroy (gameObject);
		}
	}
}