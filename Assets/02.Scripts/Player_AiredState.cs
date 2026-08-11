using UnityEngine;

public class Player_AiredState : EntityState
{
    public Player_AiredState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        // x는 유저가 움직이는 대로 움직이도록, y는 중력의 영향만 받도록
        if (player.moveInput.x != 0)
            player.SetVelocity(player.moveInput.x * player.moveSpeed, rb.linearVelocity.y);
    }


}
