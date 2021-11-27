using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    [SerializeField] float _timer;
    public AIStateID GetID()
    {
        return AIStateID.Idle;
    }

    public void Enter(AIAgent agent)
    {
        _timer = 5;
    }

    public void Update(AIAgent agent)
    {
        //Debug.Log("Idle timer: " + _timer);
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            agent.StateMachine.ChangeState(AIStateID.Patrol);
        }
        
        //Si esta viendo al player
        if (agent.IsLookingTarget())
        {
            agent.StateMachine.ChangeState(AIStateID.ChaseTarget);
        }
    }

    public void Exit(AIAgent agent)
    {
    }
}
