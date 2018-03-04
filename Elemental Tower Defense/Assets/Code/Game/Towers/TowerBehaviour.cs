using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {
	public Tower Tower;
	public Color normalColor;
	public Color selectedColor;

	public GameObject TowerRadius;

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
		GameManager.Instance.SelectedTower = this;
		TowerRadius.GetComponent<Canvas>().enabled = true;
		SetColor(selectedColor);
	}

	public void Unselect() {
		GameManager.Instance.SelectedTower = null;
		TowerRadius.GetComponent<Canvas>().enabled = false;
		SetColor(normalColor);
	}

	private void SetColor (Color color) {
		var childrenRenderers = this.GetComponentsInChildren<Renderer>();
		foreach(var renderer in childrenRenderers) {
			renderer.material.color = color;
		}
	}
}
