using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        Debug.Log("Entered Idle State");
    }

    public override void Execute()
    {
        Debug.Log("Executing Idle");
    }

    public override void Exit()
    {
        Debug.Log("Exited Idle State");
    }
}
