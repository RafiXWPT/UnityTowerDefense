using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNode : MonoBehaviour {

	public Color baseColor;
	public Color selectedColor;

	public void Select() {
		SetColor(selectedColor);
	}

	public void Reset() {
		SetColor(baseColor);
	}

	private void SetColor(Color color) {
		this.GetComponent<Renderer>().material.color = color;
	}
}
