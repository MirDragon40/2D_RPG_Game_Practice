using UnityEngine;

public class StateMachine
{ 
    // 상태 머신에서는 현재 활성 상태(이 클래스에서 가장 중요)에 대한 참조가 있어야 한다. 

    // 캡슐화 
    public EntityState currentState { get; private set; }


    // 위에서 선언한 변수는 null이기 때문에 처음에 상태를 지정해주는 코드가 있어야 함.
    public void Initialize(EntityState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(EntityState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

}
