using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour {
	Transform[] destinations;
    NavMeshAgent _navMeshAgent;
	int _currentDestinationIndex = 0;
	void Start () {
		destinations = GetCheckpoints();
		_navMeshAgent = this.GetComponent<NavMeshAgent>();
		if(_navMeshAgent == null) {
			return;
		}

		_navMeshAgent.SetDestination(GetCurrentDestination());
	}
	
	void Update () {
		var distanceToDestination = Vector3.Distance(GetCurrentDestination(), transform.position);
		if(distanceToDestination <= 1 && _currentDestinationIndex < destinations.Length-1) {
			_currentDestinationIndex++;
			_navMeshAgent.SetDestination(GetCurrentDestination());
		}
	}

	private Vector3 GetCurrentDestination() {
		return destinations[_currentDestinationIndex].transform.position;
	}

	private Transform[] GetCheckpoints() {
		var checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint").Select(go => go.transform);
		var checkpointDictionary = new Dictionary<Transform, int>();
		foreach(var checkpoint in checkpoints) {
			checkpointDictionary.Add(checkpoint, Convert.ToInt32(checkpoint.name));
		}

		return checkpointDictionary.OrderBy(cd => cd.Value).Select(cd => cd.Key).ToArray();
	}
}
