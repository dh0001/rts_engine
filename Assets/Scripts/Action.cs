
using System;

/// <summary>Thrown when an action cannot be made.</summary>
public class ActionException : Exception {

    public string ErrorMessage;

    public ActionException(string errMsg){
        ErrorMessage = errMsg;
    }
}



public abstract class Action
{
    UnitManager actingUnit;

    public Action(UnitManager u){
        actingUnit = u;
    }

    public abstract void Elapse();
    public abstract void Cancel();

    ///<summary>Check if it is okay to execute the action.</summary>
    protected abstract void ExecuteAction();
    public void TryExecuteAction(){
        ExecuteAction();
        actingUnit.ExecuteAction(this);
    }
}


public class MoveAction : Action
{
    public MoveAction(UnitManager u, int x, int y) : base(u) {}

    public override void Elapse()
    {
    }

    protected override void ExecuteAction(){

    }

    public override void Cancel(){

    }
}