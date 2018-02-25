using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSelectorNode : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler {
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("mleko");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mleko2");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
