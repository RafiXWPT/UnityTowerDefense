using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasicArrowTower : Tower {
    public override string Name { get { return "Basic Arrow Tower"; } }

    public override Element Element { get { return Element.ARMOUR; } }
    public override int Cost { get { return 1; } }

    public override int Damage { get { return 1; } }

    public override int Range { get { return 10; } }

    public override double Speed { get { return 1.3f; } }

    public override DamageType DamageType { get { return DamageType.PROJECTILE; } }

    protected override string ResourcesLocalizationPrefix { get { return "Models/Towers/Common/Arrow/Basic/"; } }

    public override GameObject Shoot {
        get {
            return GetShootPrefab ();
        }
    }

    public override GameObject Prefab {
        get {
            return GetTowerPrefab ();
        }
    }

    public override void Attack () {
        if (Target == null) {
            Target = Physics.OverlapSphere (Position, Range).Where (o => o.GetComponent<MonsterBehaviour> () != null).Select (o => o.gameObject).FirstOrDefault ();

            if (Target == null)
                return;
            else {
                Debug.Log (Target.name);
            }
        }

        var shoot = GameObject.Instantiate (Shoot, Position, Quaternion.identity);
        var shootBehaviour = shoot.GetComponent<ProjectileBehaviour> ();
        shootBehaviour.Initialize(this, Target.transform, 10f);
        Cooldown = Speed;
    }

    public override void Upgrade () {
        throw new System.NotImplementedException ();
    }
}