using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourMonster : Monster
{
    public ArmourMonster(Ability ability, string name, float health, float mana, Reward reward) : base(Element.ARMOUR, ability, name, health, mana, reward) { }

    public override void CastAbility()
    {
        //throw new System.NotImplementedException();
    }
}
