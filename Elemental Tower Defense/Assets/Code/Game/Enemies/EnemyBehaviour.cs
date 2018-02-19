using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public Enemy Enemy {get;set;}
	void Start () {
		
	}
	
	void Update () {
		Enemy.CastAbility();
	}
}
