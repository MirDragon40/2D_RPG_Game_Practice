using UnityEngine;

public class Player_FallState : Player_AiredState
{
    public Player_FallState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {


    }

    public override void Update()
    {
        base.Update();

        if (player.groundDetected)
            stateMachine.ChangeState(player.idleState);

        // 만약 플레이어가 땅 위를 딛고있다면, Idle State로 변환 

    }


}
