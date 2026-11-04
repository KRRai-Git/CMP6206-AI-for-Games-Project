using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
    State currState;
    public void ChangeState(State newState)
    {
        currState.Exit();
        currState = newState;
        newState.Enter();
    }
    public void Update()
    {
        currState.Execute();
    }
}
