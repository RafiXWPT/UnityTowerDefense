using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy {

	public abstract Element Element {get;}
	public abstract Ability Ability {get;}
	public abstract string Name {get;}
	public abstract int Health {get;}
	public abstract int Mana {get;}
	public abstract int Reward {get;}

	public abstract void CastAbility();
	public abstract void GetDamage(int amount);
}
