using UnityEngine;

public class StateMachine
{ 
    // 상태 머신에서는 현재 활성 상태(이 클래스에서 가장 중요)에 대한 참조가 있어야 한다. 

    // 캡슐화: 아무도 이 변수를 변경할 수 없음
    public EntityState currentState { get; private set; }


    // 위에서 선언한 변수는 null이기 때문에 처음에 상태를 지정해주는 코드가 있어야 함.
    // 초기화를 사용하여 플레이어가 사용할 첫 번째 활성 상태를 할당
    // 오브젝트가 시작될 때 사용할 첫 번째 상태 할당
    public void Initialize(EntityState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(EntityState newState)
    {
        if (currentState == newState)
        {
            return;
        }

        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void UpdateActiveState()
    {
        currentState.Update();
    }



}
