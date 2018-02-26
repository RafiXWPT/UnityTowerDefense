using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour {
	public Monster Monster {get;set;}
	void Start () {
		
	}
	
	void Update () {
		//Monster.CastAbility();
	}

	private void OnCollisionEnter(Collision other) {
		Debug.Log(other.transform.name);
		Destroy(other.gameObject);
	}
}
