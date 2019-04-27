using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Manages in game properties of a unit. Knowledge about the unit should be stored in the Unit class.</summary>
public class UnitManager
{
    private GameObject model;
    private int health;
    private List<Action> actions;
    private List<Modifier> modifiers;
    private Unit unit;

    // Alternative to using Resources.Load: https://unity3d.com/learn/tutorials/topics/best-practices/assetbundle-usage-patterns
    // It is actually the recommended way of loading resources without a public reference to them, but a bit complex.
    public UnitManager(string s)
    {
        // load model
        model = Resources.Load("Units/Tank") as GameObject;
        Object.Instantiate(model, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        // set stats
    }

    public void Elapse()
    {
        foreach (var action in actions){
            action.Elapse();
        }

        foreach (var modifier in modifiers){
            modifier.Elapse();
        }
    }



    ///<summary>Attempt to execute an action.</summary>
    public void ExecuteAction(Action a){
        // check to see if doing the action is possible

    }
}
