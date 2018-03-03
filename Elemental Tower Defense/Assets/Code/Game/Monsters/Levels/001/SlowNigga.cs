using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowNigga : Monster
{
    public override Element Element { get { return Element.ARMOUR; }}

    public override Ability Ability  { get { return Ability.NONE; }}

    public override string Name  { get { return "Slow Nigga"; }}

    public override float Health  { get { return 10; }}

    public override float Mana  { get { return 10; }}

    public override int Reward  { get { return 10; }}

    public override void CastAbility()
    {
        //throw new System.NotImplementedException();
    }
}
