using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower {
	public abstract GameObject Prefab {get;}
	public abstract string Name {get; }
	public abstract Element Element {get;}
	public abstract int Cost {get;}
	public abstract int Damage {get;}
	public abstract int Range {get;}
	public abstract double Speed {get;}
	public GameObject Target {get;set;}
	public double Cooldown {get;set;}

	public abstract void Attack();
	public abstract void Upgrade();
	public abstract void Select();
}
