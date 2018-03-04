using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster {
	protected string ResourcesLocalizationPrefix {get {return "Models/Monsters/Levels/{0}/Monster" ;}}
	public Element Element {get;}
	public Ability Ability {get;}
	public string Name {get;}
	public float Health {get;}
	public float CurrentHealth {get; set;}
	public float Mana {get;}
	public float CurrentMana {get;set;}
	public Reward Reward {get;}

    public GameObject Prefab {get {
        return GetMonsterPrefab();
    }}

	public Monster(Element element, Ability ability, string name, float health, float mana, Reward reward) {
		Element = element;
		Ability = ability;
		Name = name;
		Health = health;
		Mana = mana;
		Reward = reward;
		
		CurrentHealth = Health;
		CurrentMana = Mana;
	}

	public abstract void CastAbility();
	public virtual void GetDamage(float amount) {
		CurrentHealth -= amount;
	}

	protected virtual GameObject GetMonsterPrefab() {
		return Resources.Load (GetPrefabResourcesPath(), typeof (GameObject)) as GameObject;
	}

	private string GetPrefabResourcesPath() {
		return string.Format(ResourcesLocalizationPrefix, GameManager.Instance.Wave);
	}
}
