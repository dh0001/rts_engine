
using System;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Thrown when an action cannot be made.</summary>
public class ActionException : Exception {

    public string ErrorMessage;

    public ActionException(string errMsg){
        ErrorMessage = errMsg;
    }
}



public abstract class Action
{
    protected UnitManager actingUnit;

    public Action(UnitManager u){
        actingUnit = u;
    }

    public abstract void Elapse();
    public abstract void Cancel();

    ///<summary>Check if it is okay to execute the action.</summary>
    protected abstract void Start();

    public void TryExecuteAction(){
        Start();
        actingUnit.ExecuteAction(this);
    }
}


public class MoveAction : Action
{
    Vector3 dest;
    NavMeshAgent agent;
    float offset = 0.1f;

    public MoveAction(UnitManager u, Vector3 destination) : base(u) {
        
        dest = destination;
        agent = u.model.GetComponent<NavMeshAgent>();
    }

    public override void Elapse()
    {
        agent.SetDestination(dest);
        agent.speed = 5;

        // checking when to end the movement action
        if (Math.Abs(agent.transform.position.x - dest.x) < offset && Math.Abs(agent.transform.position.z - dest.z) < offset)
            Cancel();
    }

    protected override void Start()
    {

    }

    public override void Cancel()
    {
        // stop all movement, then remove action from list of actions within unit manager
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        actingUnit.actions.Remove(this);
    }
}