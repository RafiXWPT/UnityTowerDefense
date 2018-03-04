using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	private Text _nextWaveTimer;
	private Text _nextInterestInTimer;
	private Text _goldCount;
	private Text _wave;
	private Text _currentMonster;
	private Text _nextMonster;

	void  Awake() {
		_towersContainer = GameObject.Find("TowersContainer");
		_nextWaveTimer = GameObject.Find("NextWaveTimer").GetComponent<Text>();
		_nextInterestInTimer = GameObject.Find("NextInterestTimer").GetComponent<Text>();
		_goldCount = GameObject.Find("GoldCount").GetComponent<Text>();
		_wave = GameObject.Find("Wave").GetComponent<Text>();
		_currentMonster = GameObject.Find("CurrentMonster").GetComponent<Text>();
		_nextMonster = GameObject.Find("NextMonster").GetComponent<Text>();
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

	public void UpdateNextWaveTimer() {
		_nextWaveTimer.text = string.Format("Next wave at: {0}", GameManager.Instance.WaveCleared ? GameManager.Instance.WaveTimer : 0);
	}

	public void UpdateInterestTimer() {
		_nextInterestInTimer.text = string.Format("Next interest at: {0}", GameManager.Instance.InterestTimer);
	}

	public void UpdateGoldCount() {
		_goldCount.text = string.Format("Gold: {0}", GameManager.Instance.Gold);
	}

	public void UpdateWave() {
		_wave.text = string.Format("Current Wave: {0}", GameManager.Instance.Wave);
		_currentMonster.text = string.Format("Current Monster: {0} ({1})", GameManager.Instance.CurrentEnemy.Name, GameManager.Instance.CurrentEnemy.Element);
		_nextMonster.text = string.Format("Next Monster: {0} ({1})", GameManager.Instance.NextEnemy.Name, GameManager.Instance.NextEnemy.Element);
	}
}