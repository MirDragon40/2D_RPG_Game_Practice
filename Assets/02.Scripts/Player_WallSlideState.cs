using UnityEngine;

public class Player_WallSlideState : EntityState
{
    public Player_WallSlideState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }


    public override void Update()
    {
        base.Update();

        // 상태가 바뀐 후에는 실행될 필요가 없으므로 메서드 안에서 위쪽에 위치한다.
        HandleWallSlide();


        if (input.Player.Jump.WasPressedThisFrame())
        {
            stateMachine.ChangeState(player.wallJumpState);
            // 혹시 모를 오류 예방을 위해 return 추가 (코드 순서에 따라 오류가 발생할 수 있으므로)
            return;
        }


        if (player.wallDetected == false)
            stateMachine.ChangeState(player.fallState);


        // 플레이어가 땅위에 서 있을때 idleState로 전환
        // 플레이어 벽 슬라이드 애니메이션이 벽의 반대방향을 바라보고 있으므로 idle로 상태 전환 시 자연스럽게 하기 위해 Flip사용 
        if (player.groundDetected)
        {
            stateMachine.ChangeState(player.idleState);
            player.Flip();
        }

    }

    // player.moveInput.x 를 넣어서 플레이어가 벽에 붙어있는 도중 x축 이동을 시도하면 벽에서 떨어짐.
    private void HandleWallSlide()
    {
        if (player.moveInput.y < 0)
            player.SetVelocity(player.moveInput.x, rb.linearVelocity.y);
        else
            player.SetVelocity(player.moveInput.x, rb.linearVelocity.y * player.wallSlideSlowMultiplier);  // 플레이어가 벽에 붙어있는 상태일 때, 속도가 더 느려짐
    }


  
}
