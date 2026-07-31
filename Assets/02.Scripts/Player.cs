using UnityEngine;

public class Player : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }

    private EntityState idleState;

    private void Awake()
    {
        //  StateMachine이 MonoBehaviour가 없는 스크립트이기 때문에 직접 할당해주는 과정이 필요 
        stateMachine = new StateMachine();

        idleState = new EntityState(stateMachine, "idle State");
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}
