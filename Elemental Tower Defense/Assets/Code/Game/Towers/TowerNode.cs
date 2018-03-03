using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNode : MonoBehaviour {

	public Color baseColor;
	public Color selectedColor;
	public Tower Tower { get; private set; }

	public void Select () {
		SetColor (selectedColor);
	}

	public void Reset () {
		SetColor (baseColor);
	}

	public void SetTower (Tower tower) {
		Tower = tower;
	}

	private void SetColor (Color color) {
		this.GetComponent<Renderer> ().material.color = color;
	}
}