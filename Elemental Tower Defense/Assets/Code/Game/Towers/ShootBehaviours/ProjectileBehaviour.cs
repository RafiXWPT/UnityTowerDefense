using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {
	public Tower Shooter {get;set;}
	public Transform Target {get;set;}
	public float ProjectileSpeed {get;set;}
	private bool Ready = false;
	public void Initialize (Tower shooter, Transform target, float projectileSpeed) {
		Shooter = shooter;
		Target = target;
		ProjectileSpeed = projectileSpeed;
		Ready = true;
	}

	void Update () {
		if(!CanShootAndTargetValid())
			return;

		transform.position = Vector3.MoveTowards (transform.position, Target.position, ProjectileSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Monster") {
			var monsterBehaviour = other.gameObject.GetComponent<MonsterBehaviour>();
			monsterBehaviour.GetDamage(Shooter.Damage);
			Destroy (gameObject);
		}
	}

	private bool CanShootAndTargetValid() {
		if (!Ready)
			return false;

		if(Target == null) {
			Destroy(gameObject);
			return false;
		}

		return true;
	}
}