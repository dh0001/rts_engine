using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAction : Action
{
    Vector3 dest;
    float offset = 0.1f;
    NavMeshPath path;
    Rigidbody unit;
    NavMeshAgent agent;

    public MoveAction(UnitManager u, Vector3 destination) : base(u) {
        
        dest = destination;
        //agent = u.model.GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        unit = actingUnit.model.GetComponent<Rigidbody>();
    }

    public override void Elapse()
    {

        // void Move(Vector3 a) { unit.MovePosition(unit.position + a.normalized * 0.4f * actingUnit.movementSpeed); }

        // // checking when to end the movement action
        // if (path.corners.Length > 0)
        // {
        //     Move(path.corners[0]);
        // } else {
        //     Move(dest);
        // }
        
    }

    protected override void Start()
    {
        agent = actingUnit.model.GetComponent<NavMeshAgent>();
        agent.SetDestination(dest);
        agent.speed = 20 * actingUnit.movementSpeed;
        agent.acceleration = 10000;
        agent.angularSpeed = 10000;
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
        //agent.autoBraking = false;
        NavMesh.CalculatePath(actingUnit.model.transform.position, dest, 0, path);
    }

    public override void Cancel()
    {
        // stop all movement, then remove action from list of actions within unit manager
        actingUnit.actions.Remove(this);
    }
}