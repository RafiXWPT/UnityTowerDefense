using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {
	public Tower Tower;

	void Start() {
		Tower = new ArrowTower();
	}

	void Update() {
		Tower.Attack();
	}
}
