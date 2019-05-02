using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

///<summary>Manages in game properties of a unit. Knowledge about the unit should be stored in the Unit class.</summary>
public class UnitManager
{
    public GameObject model;
    private int health;
    public List<Action> actions = new List<Action>();
    private List<Modifier> modifiers = new List<Modifier>();
    private Unit unit;

    /// <summary>
    /// Constructs a unit based on the name of the unit being passed in.
    /// </summary>
    /// <param name="s"></param>
    public UnitManager(string s, UIManager uiManager)
    {
        // Alternative to using Resources.Load: https://unity3d.com/learn/tutorials/topics/best-practices/assetbundle-usage-patterns
        // It is actually the recommended way of loading resources without a public reference to them, but a bit complex.

        Vector3 spawnPosition = new Vector3(0, 0, 0);

        // load model
        model = Resources.Load("Units/Sphere") as GameObject; // loading game object
        model = Object.Instantiate(model, spawnPosition, new Quaternion(0, 0, 0, 0)) as GameObject; // instantiating game object
        model.GetComponent<UnitScript>().SetReferences(this, uiManager); // setting unit manager
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

        // then add to list of actions
        actions.Add(a);
    }
}
