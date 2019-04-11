using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unit
{
    public int MaxHealth;
    public int VisionRange;

    public Unit(int maxHealth, int visionRange)
    {
        MaxHealth = maxHealth;
        VisionRange = visionRange;
    }
}

public abstract class Action
{
    public abstract void Update();
}

public class MoveAction : Action
{
    public override void Update()
    {
    }
}


public class Modifiers
{

}

public class ExampleHero : Unit
{
    ExampleHero(int visionRange, int maxHealth) : base(visionRange, maxHealth)
    {
    }
}



public class UnitManager
{
    private GameObject model;
    private int health;
    private Action action;
    private List<Modifiers> modifiers;
    private Unit unit;

    // Alternative to using Resources.Load: https://unity3d.com/learn/tutorials/topics/best-practices/assetbundle-usage-patterns
    // It is actually the recommended way of loading resources without a public reference to them, but a bit complex.
    public UnitManager(string s)
    {
        model = Resources.Load("Units/Tank") as GameObject;
        Object.Instantiate(model, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }
}
