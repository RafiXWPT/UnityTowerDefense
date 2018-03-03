using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster {

	public abstract Element Element {get;}
	public abstract Ability Ability {get;}
	public abstract string Name {get;}
	public abstract float Health {get;}
	public float CurrentHealth {get; set;}
	public abstract float Mana {get;}
	public float CurrentMana {get;set;}
	public abstract int Reward {get;}

	protected Monster() {
		CurrentHealth = Health;
		CurrentMana = Mana;
	}

	public abstract void CastAbility();
	public virtual void GetDamage(float amount) {
		CurrentHealth -= amount;
	}
}
