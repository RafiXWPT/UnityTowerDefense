using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : Monster {

    public FireMonster(Ability ability, string name, float health, float mana, Reward reward) : base(Element.FIRE, ability, name, health, mana, reward) { }

    public override void CastAbility()
    {
        //throw new System.NotImplementedException();
    }
}
