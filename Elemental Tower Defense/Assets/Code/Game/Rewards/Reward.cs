using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward  {
	public int Gold {get;set;}
	public ElementEssence ElementEssence {get;set;}

	private Reward(int gold) : this(gold, Element.ARMOUR) {}

	private Reward(Element element) : this(0, element) {}

	private Reward(int gold, Element element) {
		Gold = gold;
		ElementEssence = ElementEssence.FromElement(element);
	}

	public static Reward GoldReward(int amount) {
		return new Reward(amount);
	}

	public static Reward EssenceReward(Element element) {
		return new Reward(element);
	}

	public static Reward MixedReward(int amount, Element element) {
		return new Reward(amount, element);
	}
}
