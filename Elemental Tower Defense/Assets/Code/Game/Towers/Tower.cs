using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower {
	public abstract string Name {get; }
	public abstract Element Element {get;}
	public abstract int Cost {get;}
	public abstract int Damage {get;}
	public abstract int Range {get;}
	public abstract double Speed {get;}
	public abstract void Attack();
}
