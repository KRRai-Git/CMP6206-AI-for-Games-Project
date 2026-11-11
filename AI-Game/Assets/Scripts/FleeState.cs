using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : State
{
    Agent owner;

    public FleeState(Agent owner) { this.owner = owner; }

    public override void Enter()
    {
        Debug.Log("Entered Flee State");
    }

    public override void Execute()
    {
        Debug.Log("Executing Flee State");
    }

    public override void Exit()
    {
        Debug.Log("Exited Flee State");
    }
}
