using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCannonTower : Tower
{
    public override string Name {get {return "Basic Cannon Tower";}}

    public override Element Element {get {return Element.ARMOUR;}}

    public override int Cost {get {return 1;}}

    public override int Damage {get {return 1;}}

    public override int Range {get {return 1;}}

    public override double Speed {get {return 1;}}

    public override GameObject Prefab {get {return Resources.Load("SimpleTower", typeof(GameObject)) as GameObject;}}
    public override GameObject Shoot {
        get {
            return GetShootPrefab();
        }
    }

    public override DamageType DamageType {get {return DamageType.SPLASH;}}
    protected override string ResourcesLocalizationPrefix {get {return "Models/Towers/Common/Arrow/Basic/";}}

    public override void Attack()
    {
		  return;
	}

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
