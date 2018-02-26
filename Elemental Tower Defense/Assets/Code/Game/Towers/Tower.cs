using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower {
	protected abstract string ResourcesLocalizationPrefix {get;}
	public abstract GameObject Prefab {get;}
	public abstract GameObject Shoot {get;}
	public abstract string Name {get; }
	public abstract Element Element {get;}
	public abstract int Cost {get;}
	public abstract int Damage {get;}
	public abstract DamageType DamageType {get;}
	public abstract int Range {get;}
	public abstract double Speed {get;}
	public Vector3 Position {get;set;}
	public GameObject Target {get;set;}
	public double Cooldown {get;set;}

	public abstract void Attack();
	public abstract void Upgrade();
	public abstract void Select();
	protected virtual GameObject GetTowerPrefab() {
		return Resources.Load (GetPrefabResourcesPath(), typeof (GameObject)) as GameObject;
	}

	protected virtual GameObject GetShootPrefab() {
		return Resources.Load (GetShootResourcesPath(), typeof (GameObject)) as GameObject;
	}

	private string GetPrefabResourcesPath() {
		return ResourcesLocalizationPrefix + this.GetType().Name;
	}

	private string GetShootResourcesPath() {
		return ResourcesLocalizationPrefix + this.GetType().Name + "Shoot";
	}
}
