using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionController : MonoBehaviour {
	private Collider[] selectedColliders = new Collider[] {};	
	void Update () {
		if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
			ResetCurrentSelection();
			RaycastHit hit;
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				Debug.Log(hit.transform.tag);
				if(hit.transform.tag == "Tower") {
					GameManager.Instance.SelectedTower = hit.transform.gameObject.GetComponent<TowerBehaviour>();
					GameManager.Instance.SelectedTower.Select();
				}
				else if(hit.transform.tag == "TowerNode") {
					var towerNode = hit.transform.gameObject.GetComponent<TowerNode>();	
					if(towerNode.Tower != null)
					{
						towerNode.Select();
					}
					else {
						ListNodes(hit.point);
					}
				}
				else if(hit.transform.tag == "Platform") {
					ListNodes(hit.point);
				}
			}
		}
	}

	private void ListNodes(Vector3 position) {
		Debug.ClearDeveloperConsole();
		Debug.Log(position);
		var closestColliders = Physics.OverlapSphere(position, 1.2F).Where(c => c.tag == "TowerNode" && c.gameObject.GetComponent<TowerNode>().Tower == null).ToArray();
		Debug.Log(closestColliders.Count().ToString() + " in range");
		var hitColliders = GetClosest(closestColliders, position);
		if(hitColliders == null)
			return;

		selectedColliders = hitColliders;

		foreach(var collider in hitColliders) {
			SelectTiles();
			GuiController.Instance.ShowBuildWindow(null);
		}
	}

	private Collider[] GetClosest(Collider[] colliders, Vector3 position) {
		var closestColliders = new List<Collider>();
		
		while(closestColliders.Count() < 4 && colliders.Length >= 4) {
			var fromPosition = GetCenter(closestColliders.ToArray(), position);

			var rangeDictionary = new Dictionary<int, float>();
			for(var i = 0; i < colliders.Count(); i++) {
				if(closestColliders.Contains(colliders[i]))
					continue;

				rangeDictionary.Add(i, Vector3.Distance(colliders[i].transform.position, fromPosition));
			}

			closestColliders.Add(rangeDictionary.OrderBy(r => r.Value).Take(1).Select(rk => colliders[rk.Key]).First());

			if(closestColliders.Count() == 4) {

				if(IsSquareConnection(closestColliders)) {
					return closestColliders.ToArray();
				}
				else {
					colliders = RemoveFarestCollider(colliders, rangeDictionary);
					closestColliders.Clear();
				}
			}
		}

		return null;
	}

	private bool IsSquareConnection(IEnumerable<Collider> colliders) {
		foreach(var collider in colliders)
		{
			var localDistances = new List<float>();
			foreach(var other in colliders.Except(new List<Collider> {collider}))
			{
				localDistances.Add(Vector3.Distance(collider.transform.position, other.transform.position));
 			}

			if(localDistances.Count(d => d == 1) != 2)
				return false;			
		}

		return true;
	}

	private Collider[] RemoveFarestCollider(Collider[] colliders, Dictionary<int, float> rangeDictionary)
	{
		var newCollection = colliders.ToList();
		newCollection.Remove(rangeDictionary.OrderByDescending(r => r.Value).Take(1).Select(rk => colliders[rk.Key]).First());
		return newCollection.ToArray();
	}

	private Vector3 GetCenter(Collider[] colliders, Vector3 initialPosition)
	{
		var center = new Vector3(0,0,0);
		foreach(var collider in colliders)
		{
			center += collider.transform.position;
		}

		center += initialPosition;

		return (center/=(colliders.Length+1));
	}

	private void SelectTiles() {
		foreach(var collider in selectedColliders)
		{
			collider.GetComponent<TowerNode>().Select();
		}

		GameManager.Instance.SelectedNodes = selectedColliders.Select(c => c.GetComponent<TowerNode>()).ToArray();
	}

	private void ResetCurrentSelection() {
		GuiController.Instance.HideBuildWindow();
		if(GameManager.Instance.SelectedTower != null)
			GameManager.Instance.SelectedTower.Unselect();

		foreach(var collider in selectedColliders)
		{
			collider.GetComponent<TowerNode>().Reset();
		}
	}
}
