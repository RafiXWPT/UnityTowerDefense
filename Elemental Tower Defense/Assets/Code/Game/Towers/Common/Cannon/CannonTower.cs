using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
{
    public override string Name {get {return "Cannon Tower";}}

    public override Element Element {get {return Element.ARMOUR;}}

    public override int Cost {get {return 1;}}

    public override int Damage {get {return 1;}}

    public override int Range {get {return 1;}}

    public override double Speed {get {return 1;}}

    public override void Attack()
    {
		  return;
	  }

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
