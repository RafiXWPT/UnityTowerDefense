using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSelectorNode : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.BuildTower(new BasicArrowTower());
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
