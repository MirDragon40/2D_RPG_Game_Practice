using UnityEngine;

public class Player_IdleState : Player_GroundedState

{
    // stateName은 애니메이터에서 애니메이션 파라미터의 이름으로 사용 
    public Player_IdleState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        // 벽에붙었다가 방향키를 이용해서 벽슬라이드(wallSlideState) 상태를 벗어난 후, 바닥에 닿아 idleState가 되었을 때, 다시 속도를 지정해줘야함  
        player.SetVelocity(0, rb.linearVelocity.y);
    }

    public override void Update()
    {
        // 부모 클래스의 Update() 메서드도 실행.
        base.Update();

        if (player.moveInput.x != 0)
            stateMachine.ChangeState(player.moveState);

    }

}
