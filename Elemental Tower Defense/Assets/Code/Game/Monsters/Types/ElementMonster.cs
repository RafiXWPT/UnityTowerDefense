using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementMonster : Monster {

    public ElementMonster(Element element, Ability ability, string name, float health, float mana, Reward reward) : base(element, ability, name, health, mana, reward) { }

    public override void CastAbility()
    {
        //throw new System.NotImplementedException();
    }
}
