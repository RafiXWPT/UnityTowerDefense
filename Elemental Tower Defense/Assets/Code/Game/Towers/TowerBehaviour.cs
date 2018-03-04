using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {
	public Tower Tower;
	public Color normalColor;
	public Color selectedColor;

	private GameObject _towerRadius;

	void Start() {
	}

	void Update() {
		if(Tower.Cooldown > 0f) {
			Tower.Cooldown -= Time.deltaTime;
		} else {
			Tower.Attack();
		}
	}

	public void Select() {
		_towerRadius = GameObject.Instantiate(GuiController.Instance.TowerRadius, this.transform.position, Quaternion.identity);
		//_towerRadius.transform.localRotation = new Vector3(90,0,0);
		_towerRadius.transform.SetParent(this.transform);
		_towerRadius.GetComponent<Canvas>().enabled = true;
		SetColor(selectedColor);
	}

	public void Unselect() {
		_towerRadius.GetComponent<Canvas>().enabled = false;
		SetColor(normalColor);
	}

	private void SetColor (Color color) {
		var childrenRenderers = this.GetComponentsInChildren<Renderer>();
		foreach(var renderer in childrenRenderers) {
			renderer.material.color = color;
		}
	}
}
