using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster {

	public abstract Element Element {get;}
	public abstract Ability Ability {get;}
	public abstract string Name {get;}
	public abstract float Health {get;}
	public abstract float Mana {get;}
	public abstract int Reward {get;}

	public abstract void CastAbility();
	public abstract void GetDamage(int amount);
}
