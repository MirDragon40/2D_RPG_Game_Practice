using UnityEngine;

public class Player_IdleState : Player_GroundedState

{
    // stateName은 애니메이터에서 애니메이션 파라미터의 이름으로 사용 
    public Player_IdleState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {

    }

    public override void Update()
    {
        base.Update();

        if (player.moveInput.x != 0)
            stateMachine.ChangeState(player.moveState);

    }

}
