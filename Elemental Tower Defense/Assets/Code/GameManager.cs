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

	public int Gold;
	public int Essence;
	public int Wave;
	public int NetWorth;
	public Monster CurrentEnemy;
	public Monster NextEnemy;

	private Transform _towersContainer;

	void Awake() {
		_towersContainer = GameObject.FindGameObjectWithTag("Towers").transform;
	}

	void Start () {
		
	}
	
	void Update () {
		
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

		newTowerObject.GetComponent<TowerBehaviour>().Tower = tower;

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
}
