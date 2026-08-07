using UnityEngine;

// [추상(abstract) 클래스로 만드는 이유]
// 1. 실수 방지: 단독으로 사용할 수 없도록 한다. 잘못된 사용을 컴파일 단계에서 차단.
// 2. 의도 전달: 이 클래스가 부모 전용이고 어딘가에 자식들이 있다는 것을 설명한다. 코드만 보고 설계 의도를 즉시 파악
public abstract class EntityState
{
    protected Player player;
    protected StateMachine stateMachine;
    protected string animBoolName;

    protected Animator anim;
    protected Rigidbody2D rb;

    public EntityState(Player player, StateMachine stateMachine, string animBoolName)
    {
        // 이 스크립트 내에서 변수를 참조하고 있음을 의미
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;

        // player 스크립트에서 Awake() 가 실행되는 순간 EntityState() 생성자가 호출되는데, 그때 이 anim이 여기에서 할당된다. 
        // 목적은 캐싱, 
        anim = player.anim;
        rb = player.rb;
    }

    public virtual void Enter()
    {
        // 상태가 변경될 때마다, 입력이 호출된다.

        Debug.Log("I enter " + animBoolName);

        player.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        // 현재 상태가 플레이어의 입력을 확인해야 하는 경우 필요한 함수

        Debug.Log("I run update of " + animBoolName);


    }

    public virtual void Exit()
    {
        // 이 함수는 상태를 종료하고 새 상태로 변경할 때마다 호출된다.

        Debug.Log("I exit " + animBoolName);

        player.anim.SetBool(animBoolName, false);
    }



}
