using UnityEngine;

public class EntityState
{
    protected StateMachine stateMachine;

    public EntityState(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        // 상태가 변경될 때마다, 입력이 호출된다.
    }

    public virtual void Update()
    {
        // 현재 상태가 업데이트에서 플레이어의 입력을 확인해야 하는 경우 필요한 함수
    }

    public virtual void Exit()
    {
        // 이 함수는 상태를 종료하고 새 상태로 변경할 때마다 호출된다.
    }



}
