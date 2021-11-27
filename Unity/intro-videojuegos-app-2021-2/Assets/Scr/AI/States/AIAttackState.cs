using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIState
{
    private float _timer = 0;
    
    public AIStateID GetID()
    {
        return AIStateID.Attack;
    }

    public void Enter(AIAgent agent)
    {
        Debug.LogError("Attacking the player!!!!!");
        _timer = agent.AIConfig.attackDuration;
    }

    public void Update(AIAgent agent)
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Debug.Log("Going to idle");
            agent.StateMachine.ChangeState(AIStateID.Idle);
        }
    }

    public void Exit(AIAgent agent)
    {
        
    }
}
