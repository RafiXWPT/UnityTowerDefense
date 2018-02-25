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

	public int Gold;
	public int Essence;
	public int Wave;
	public int NetWorth;
	public Enemy CurrentEnemy;
	public Enemy NextEnemy;

	private Transform _towersContainer;

	void Awake() {
		_towersContainer = GameObject.FindGameObjectWithTag("Towers").transform;
	}

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void BuildTower(Tower tower, TowerNode[] nodes) {
		var newTower = GameObject.Instantiate(tower.Prefab, GetTowerPosition(nodes), Quaternion.identity);
		newTower.transform.SetParent(_towersContainer.transform);
	}

	private Vector3 GetTowerPosition(TowerNode[] nodes) {
		var bounds = new Bounds(nodes[0].transform.position, Vector3.zero);
		for(var i = 1; i < nodes.Length; i++) {
			bounds.Encapsulate(nodes[i].transform.position);
		}

		return bounds.center;
	}
}
