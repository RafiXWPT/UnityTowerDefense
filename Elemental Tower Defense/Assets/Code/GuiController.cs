using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour {
	private static GuiController _instance;
	public static GuiController Instance {
		get {
			if(_instance == null) {
				_instance = GameObject.Find("GuiController").GetComponent<GuiController>();
			}
			return _instance;
		}
	}

	public GameObject TowerRadius;
	public GameObject BuildWindow;
	public GameObject TowerSelectorNode;
	private GameObject _towersContainer;

	void  Awake() {
		_towersContainer = GameObject.Find("TowersContainer");
	}

	void Start () {
		
	}
	
	public void ShowBuildWindow(Tower tower) {
		DestroyChilds(_towersContainer.transform);

		if(tower == null) {
			ShowAvailableNewTowers();
		} else {
			ShowAwailableTowerUpgrades(tower);
		}

		BuildWindow.SetActive(true);
		for(var i = 0; i < 9; i++) {
			var towerSelectorNode = GameObject.Instantiate(TowerSelectorNode, Vector3.zero, Quaternion.identity);
			towerSelectorNode.transform.SetParent(_towersContainer.transform);
		}
	}

	public void HideBuildWindow() {
		BuildWindow.SetActive(false);
	}

	private void DestroyChilds(Transform parent) {
		foreach(Transform child in parent) {
			GameObject.Destroy(child.gameObject);
		}
	}

	private void ShowAwailableTowerUpgrades(Tower tower) {

	}

	private void ShowAvailableNewTowers() {
		
	}
}
