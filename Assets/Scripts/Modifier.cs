using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modifier
{
    private int duration;

    public abstract void Elapse();

    public abstract void Begin();

    public abstract void End();

    public abstract void Dispel();

    public static Modifier createModifier(UnitManager unit, string modifier)
    {
        if (modifier == "stunned")
        {
            return new Stunned(unit);
        }
        else
        {
            throw new System.Exception("Modifier does not exist");
        }
    }
}

public class Stunned : Modifier
{
    private UnitManager unitManager;

    public Stunned(UnitManager unit)
    {
        unitManager = unit;
    }

    public override void Elapse()
    {
        throw new System.NotImplementedException();
    }

    public override void Begin()
    {
        throw new System.NotImplementedException();
    }

    public override void End()
    {
        throw new System.NotImplementedException();
    }

    public override void Dispel()
    {
        throw new System.NotImplementedException();
    }
}
