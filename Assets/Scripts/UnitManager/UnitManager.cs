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

    // Alternative to using Resources.Load: https://unity3d.com/learn/tutorials/topics/best-practices/assetbundle-usage-patterns
    // It is actually the recommended way of loading resources without a public reference to them, but a bit complex.
    public UnitManager(string s)
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);

        // load model
        model = Resources.Load("Units/Sphere") as GameObject;
        model = Object.Instantiate(model, spawnPosition, new Quaternion(0, 0, 0, 0)) as GameObject;

        // set position to be something on navMesh
        NavMeshAgent agent = model.GetComponent<NavMeshAgent>();
        agent.Warp(spawnPosition);
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
