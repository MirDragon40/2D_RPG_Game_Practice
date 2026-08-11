using UnityEngine;

public class Player_JumpState : Player_AiredState
{
    public Player_JumpState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        // 오브젝트가 위로 올라가도록하기
        // Y Velocity를 증가시키기

        player.SetVelocity(rb.linearVelocity.x, player.jumpForce);

    }

    public override void Update()
    {
        base.Update();

        if (rb.linearVelocity.y < 0)
            stateMachine.ChangeState(player.fallState);

        // Y velocity가 감소하면 캐릭터가 떨어지도록하기
        // FallState로 전환하기

    }

}
