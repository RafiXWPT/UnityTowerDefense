using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementEssence  {
	public Element Element {get; set;}

	private ElementEssence() {

	}

	public static ElementEssence FromElement(Element element) {
		return new ElementEssence {Element = element};
	}
}
