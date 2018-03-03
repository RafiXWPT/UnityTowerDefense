using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBehaviour : MonoBehaviour {
	public Monster Monster {get;set;}
	private Transform _healthBarCanvas;
	private Image _healthBar;

	void Awake() {
		Monster = new SlowNigga();
		_healthBarCanvas = this.GetComponentInChildren<Canvas>().transform;
		_healthBar = this.GetComponentsInChildren<Image>().Where(o => o.tag == "HealthBar").First();
	}

	void Start () {
		
	}
	
	void Update () {
		UpdateHealthBarRotation();
	}

	private void UpdateHealthBarRotation() {
		var toCameraRotation = Camera.main.transform.rotation;
		_healthBarCanvas.LookAt(_healthBarCanvas.position + toCameraRotation * Vector3.back, toCameraRotation * Vector3.up);
	}

	public void GetDamage(int amount) {
		Monster.GetDamage(amount);
		if(Monster.CurrentHealth <= 0) {
			GameObject.Destroy(this.gameObject);
			return;
		}

		_healthBar.fillAmount = Monster.CurrentHealth / Monster.Health;
	}
}
