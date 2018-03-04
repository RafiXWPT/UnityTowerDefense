using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MonstersLibrary {
	private class MonsterLevelParameters {
		public string Name {get; set;}
		public float Health {get;set;}
		public float Mana {get;set;}
		public Reward Reward {get;set;}
		public Element Element {get;set;}

		public MonsterLevelParameters(string name, float health, float mana, Reward reward) : this(name, health, mana, reward, Element.ARMOUR) {}

		public MonsterLevelParameters(string name, float health, float mana, Reward reward, Element element) {
			Name = name;
			Health = health;
			Mana = mana;
			Reward = reward;
			Element = element;
		}
	}

	private static System.Random _random = new System.Random();

	private static Dictionary<int, MonsterLevelParameters> _levelLibrary = new Dictionary<int, MonsterLevelParameters>() {
		{1, new MonsterLevelParameters("Rat", 10, 0, Reward.GoldReward(1))},
		{2, new MonsterLevelParameters("Wolf", 15, 0, Reward.GoldReward(1))},
		{3, new MonsterLevelParameters("Larva", 20, 0, Reward.GoldReward(2))},
		{4, new MonsterLevelParameters("Tortoise", 30, 0, Reward.GoldReward(2))},
		{5, new MonsterLevelParameters("Panter", 40, 0, Reward.GoldReward(3))},
		{6, new MonsterLevelParameters("Khazax", 50, 10, Reward.GoldReward(3))},
		{7, new MonsterLevelParameters("Re'dim", 70, 20, Reward.GoldReward(5))},
		{8, new MonsterLevelParameters("Galapagos", 100, 30, Reward.GoldReward(5))},
		{9, new MonsterLevelParameters("Tourvil", 150, 40, Reward.GoldReward(7))},
		{10, new MonsterLevelParameters("Theleth", 300, 50, Reward.GoldReward(7))},
		{11, new MonsterLevelParameters("Um'Drix", 500, 60, Reward.GoldReward(10))},
		{12, new MonsterLevelParameters("Scouter", 800, 70, Reward.GoldReward(10))}
	};

	public static Dictionary<int, Func<Monster>> LevelLibrary = new Dictionary<int, Func<Monster>>();

	public static void RandomInitializer() {
		if(LevelLibrary.Any())
			return;

		foreach(var monsterLevelParameter in _levelLibrary) {
			LevelLibrary.Add(monsterLevelParameter.Key, () => GenerateRandomMonster(monsterLevelParameter.Value));
		}
	}

	public static void CircleInitializer() {
		if(LevelLibrary.Any())
			return;
		
		var elementArray = Enum.GetValues(typeof(Element));
		foreach(var monsterLevelParameter in _levelLibrary) {
			LevelLibrary.Add(monsterLevelParameter.Key, () => GenerateMonster(monsterLevelParameter.Value, (Element)(elementArray.GetValue(monsterLevelParameter.Key%elementArray.Length))));
		}
	}

	private static Monster GenerateRandomMonster(MonsterLevelParameters parameters) {
		var elementArray = Enum.GetValues(typeof(Element));
		return GenerateMonster(parameters,(Element)(elementArray.GetValue(_random.Next(elementArray.Length))));
	}

	private static Monster GenerateMonster(MonsterLevelParameters parameters, Element element) {
		if(element == Element.ARMOUR) {
				return new ArmourMonster(Ability.NONE, parameters.Name, parameters.Health, parameters.Mana, parameters.Reward);
		} else {
				return new ElementMonster(element, Ability.NONE, parameters.Name, parameters.Health, parameters.Mana, parameters.Reward);
		}
	}
}
