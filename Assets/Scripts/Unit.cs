
using System.Collections.Generic;


public abstract class Ability{

}

public abstract class Unit
{
    ///<summary>Maximum possible health the unit can have.</summary>
    public int MaxHealth;

    public int VisionRange;

    List<Ability> abilities;


    public Unit(int maxHealth, int visionRange)
    {
        MaxHealth = maxHealth;
        VisionRange = visionRange;
    }

    ///<summary>Check if it is okay to execute an action.</summary>
    protected abstract bool CheckAction();
}


// public abstract class Hero : Unit{

// }


// public class ExampleHero : Unit
// {
//     ExampleHero(int visionRange, int maxHealth) : base(visionRange, maxHealth)
//     {
//     }
// }