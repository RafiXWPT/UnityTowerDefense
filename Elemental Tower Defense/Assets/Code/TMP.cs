using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TMP : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				if(hit.transform.tag == "TowerNode" || hit.transform.tag == "Platform") {
					ListNodes(hit.point);
				}
			}
		}
	}

	private void ListNodes(Vector3 position) {
		Debug.ClearDeveloperConsole();
		Debug.Log(position);
		var hitColliders = Physics.OverlapSphere(position, 1.2F).Where(c => c.tag == "TowerNode").ToArray();
		if(hitColliders.Count() > 4) {
			hitColliders = GetClosest(hitColliders, position);
		} else{
			return;
		}

		Debug.Log(hitColliders.Count().ToString() + " in range");
		foreach(var collider in hitColliders) {
			Debug.Log(collider.name);
		}
	}

	private Collider[] GetClosest(Collider[] colliders, Vector3 position) {
		var rangeDictionary = new Dictionary<int, float>();

		for(var i = 0; i < colliders.Count(); i++) {
			rangeDictionary.Add(i, Vector3.Distance(colliders[i].transform.position, position));
		}
		
		return rangeDictionary.OrderBy(r => r.Value).Take(4).Select(rk => colliders[rk.Key]).ToArray();
	}
}
