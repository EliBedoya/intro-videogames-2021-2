using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AIAgent : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private AIConfig _aiConfig;
    //[SerializeField]public NavMeshAgent NMA;
    private MovableAgent _movableAgent;
    private AIStateMachine _stateMachine;
    private PathContainer _pathContainer;

    public Transform Target => _player;
    public AIConfig AIConfig => _aiConfig;
    public MovableAgent MovableAgent => _movableAgent;
    public AIStateMachine StateMachine => _stateMachine;
    public PathContainer PathContainer => _pathContainer;

    void Start()
    {
        _movableAgent = GetComponent<MovableAgent>();
        _pathContainer = GetComponent<PathContainer>();
        
        _stateMachine = new AIStateMachine(this);
        
        _stateMachine.AddState(new AIIdleState());
        _stateMachine.AddState(new AIChaseTargetState());
        _stateMachine.AddState(new AIAttackState());
        _stateMachine.AddState(new AIPatrolState());
        
        _stateMachine.ChangeState(_aiConfig.initialState);
    }


    void Update()
    {
        _stateMachine.Update();
    }
    
    public bool IsLookingTarget()
    {
        //Definir un vector con la dirección a donde mira el enemigo
        Vector3 agentDirection = transform.forward;
        //Definir un vesctor de posición relativa del player visto por el enemigo
        Vector3 agentPlayer = _player.position - transform.position;
        //Producto punto entre estos dos vectores
        //El producto punto se define como la multiplicación de 2 vectores por el coseno del ángulo entre ellos
        //Por lo que si el producto punto es mayor o igual a 0 significa que está al frente
        //Para el cono simplemente se define un número mayor a cero, lo que restringe aún más el ángulo de visión
        if((Vector3.Dot(agentDirection, agentPlayer) > 0.8) && agentPlayer.magnitude < _aiConfig.detectionRange){
            return true;
        } else {
            return false;
        }
    }
  
}
