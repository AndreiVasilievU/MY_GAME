using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] State startingState;
    State currentState;

    public State CurrentState
    {
        get { return currentState; }
    }

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        Transit(startingState);
    }

    private void Update()
    {
        if (currentState == null)
        {
            return;
        }

        var next = currentState.GetNext();
        if (next != null)
        {
            Transit(next);
        }
    }

    void Transit(State next)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = next;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }
}
