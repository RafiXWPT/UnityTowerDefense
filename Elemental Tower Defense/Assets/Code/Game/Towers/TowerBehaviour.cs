using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {
	public Tower Tower;

	void Start() {
	}

	void Update() {
		if(Tower.Cooldown > 0f) {
			Tower.Cooldown -= Time.deltaTime;
		} else {
			Tower.Attack();
		}
	}
}
