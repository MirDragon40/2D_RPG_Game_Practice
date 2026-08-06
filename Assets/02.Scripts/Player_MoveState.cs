using UnityEngine;

public class Player_MoveState : EntityState
{
    public Player_MoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();


            // F를 눌러서 moveState로 전환한다. (테스트용 )
            if (Input.GetKeyDown(KeyCode.F))
                stateMachine.ChangeState(player.moveState);
    }

}
