using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private static GameManager _instance;
	public static GameManager Instance {
		get {
			if(_instance == null) {
				_instance = GameObject.Find("_GameManager").GetComponent<GameManager>();
			}
			return _instance;
		}
	}

	public TowerNode[] SelectedNodes {get;set;}
	public TowerBehaviour SelectedTower {get;set;}

	public int Gold {get;set;}
	public int Essence {get;set;}
	public int Wave {get;set;}
	public int NetWorth {get;set;}
	public float WaveTimer {get; private set;}
	public float InterestTimer {get; private set;}
	public bool WaveCleared {get; private set;}
	public Monster CurrentEnemy {
		get {
			return MonstersLibrary.LevelLibrary[Wave]();
		}
	}
	public Monster NextEnemy {
		get {
			return MonstersLibrary.LevelLibrary[Wave+1]();
		}
	}
	private Transform _towersContainer;
	private Transform _spawn;

	void Awake() {
		Wave = 1;
		MonstersLibrary.CircleInitializer();
		_towersContainer = GameObject.FindGameObjectWithTag("Towers").transform;
		_spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
		WaveTimer = 30f;
		InterestTimer = 5f;
		WaveCleared = true;
	}

	void Start() {
		GuiController.Instance.UpdateWave();
	}
	
	void Update () {
		UpdateCounters();
		CheckLivingEnemy();
	}

	void FixedUpdate() {
		UpdateGui();
	}

	private void UpdateCounters() {
		UpdateNextWaveCounter();
		UpdateInterestCounter();
	}

	private void UpdateGui() {
		GuiController.Instance.UpdateNextWaveTimer();
		GuiController.Instance.UpdateInterestTimer();
		GuiController.Instance.UpdateGoldCount();
	}

	private void UpdateNextWaveCounter() {
		WaveTimer -= Time.deltaTime;

		if(WaveCleared && WaveTimer <= 0) {
			StartCoroutine("StartNextLevel");
			WaveCleared = false;
		}
	}

	private void UpdateInterestCounter() {
		InterestTimer -= Time.deltaTime;
		if(InterestTimer <= 0) {
			InterestPayout();
			InterestTimer = 15f;
		}
	}

	private void CheckLivingEnemy() {
		if(!WaveCleared && !GameObject.FindGameObjectsWithTag("Monster").Any()) {
			Wave += 1;
			WaveCleared = true;
			WaveTimer = 15f;
			GuiController.Instance.UpdateWave();
		}
	}

	IEnumerator StartNextLevel() {
		for(var i = 0; i < 10; i++) {
			var monsterObject = GameObject.Instantiate(CurrentEnemy.Prefab, _spawn.position, Quaternion.identity);
			monsterObject.GetComponent<MonsterBehaviour>().SetMonster(CurrentEnemy);
			yield return new WaitForSeconds(1.0f);
		}
	}

	private void InterestPayout() {
		Gold += (int)(Gold*0.15f);
	}

	public void BuildTower(Tower tower, TowerNode[] nodes = null) {
		if(nodes == null)
		{
			nodes = SelectedNodes;
		}

		var towerPosition = GetTowerPosition(nodes);

		var newTowerObject = GameObject.Instantiate(tower.Prefab, towerPosition, Quaternion.identity);
		tower.Position = towerPosition;
		newTowerObject.transform.SetParent(_towersContainer.transform);

		var newTowerBehaviour = newTowerObject.GetComponent<TowerBehaviour>();
		newTowerBehaviour.Tower = tower;
		InstantiateTowerRadiusObject(newTowerObject, newTowerBehaviour);
		newTowerBehaviour.Select();
		
		foreach(var node in nodes)
			node.SetTower(tower);
	}

	private Vector3 GetTowerPosition(TowerNode[] nodes) {
		var bounds = new Bounds(nodes[0].transform.position, Vector3.zero);
		for(var i = 1; i < nodes.Length; i++) {
			bounds.Encapsulate(nodes[i].transform.position);
		}

		return new Vector3(bounds.center.x, 1.6f, bounds.center.z);
	}

	private void InstantiateTowerRadiusObject(GameObject newTowerObject, TowerBehaviour newTowerBehaviour) {
		var towerRadiusObject = GameObject.Instantiate(GuiController.Instance.TowerRadius, newTowerObject.transform.position, Quaternion.Euler(new Vector3(90,0,0)));
		towerRadiusObject.transform.SetParent(newTowerObject.transform);	
		towerRadiusObject.GetComponent<RectTransform>().sizeDelta = new Vector2(newTowerBehaviour.Tower.Range*2, newTowerBehaviour.Tower.Range*2);
		newTowerBehaviour.TowerRadius = towerRadiusObject;
	}
}
