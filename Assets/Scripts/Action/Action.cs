
using System;
using System.Collections;
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
