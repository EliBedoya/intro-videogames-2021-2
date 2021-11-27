using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AIPatrolState : AIState
{
    private NavMeshAgent agentEnemy;
    private PathContainer path;
    
    public AIStateID GetID()
    {
        return AIStateID.Patrol;
    }

    public void Enter(AIAgent agent)
    {
        agentEnemy = agent.gameObject.GetComponent<NavMeshAgent>();
        path = agent.gameObject.GetComponent<PathContainer>();
        agent.MovableAgent.Move();
    }

    public void Update(AIAgent agent)
    {
        if (agent.IsLookingTarget())
        {
            agent.StateMachine.ChangeState(AIStateID.ChaseTarget);
        }
        if (!agentEnemy.pathPending && agentEnemy.remainingDistance<0.5f)
        {
            agentEnemy.destination = path.NextPoint();
        }
    }

    public void Exit(AIAgent agent)
    {
        agent.MovableAgent.Stop();
    }
}
