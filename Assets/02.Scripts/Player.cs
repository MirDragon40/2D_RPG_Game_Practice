using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }


    private PlayerInputSet input;
    private StateMachine stateMachine;

    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }

    // get, priavte set을 사용하면 인스펙터창에서 보이지 않는다. 
    public Vector2 moveInput { get; private set; }

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //  StateMachine이 MonoBehaviour가 없는 스크립트이기 때문에 직접 할당해주는 과정이 필요 (PlayerInputSet도 마찬가지)
        stateMachine = new StateMachine();
        input = new PlayerInputSet();

        idleState = new Player_IdleState(this, stateMachine, "idle");
        moveState = new Player_MoveState(this, stateMachine, "move");
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); // ctx: context
        input.Player.Movement.canceled += ctx => moveInput = Vector2.zero;

    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.UpdateActiveState();
    }

    // 해당 메서드를 만드는 이유 - 단일 진입점(통로를 하나로), 캡슐화, 관심사 분리 등등
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
    }
}
