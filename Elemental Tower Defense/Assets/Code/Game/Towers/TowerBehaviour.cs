using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {
	public Tower Tower;
	public Color normalColor;
	public Color selectedColor;

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
		SetColor(selectedColor);
	}

	public void Unselect() {
		SetColor(normalColor);
	}

	private void SetColor (Color color) {
		var childrenRenderers = this.GetComponentsInChildren<Renderer>();
		foreach(var renderer in childrenRenderers) {
			renderer.material.color = color;
		}
	}
}
