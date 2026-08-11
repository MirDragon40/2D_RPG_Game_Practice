using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public PlayerInputSet input { get; private set; }

    private StateMachine stateMachine;



    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }
    public Player_JumpState jumpState { get; private set; }
    public Player_FallState fallState { get; private set; }


    [Header("Movement Details")]
    public float moveSpeed;
    public float jumpForce = 5;

    [Range(0,1)] // 슬라이더로 작동
    public float inAirMoveMultiplier = .7f; // 0~1 사이여야 함
    // 처음엔 오른쪽을 향하고 있으므로 true
    private bool facingRight = true;
    // get, priavte set을 사용하면 인스펙터창에서 보이지 않는다. 
    public Vector2 moveInput { get; private set; }


    [Header("Collision detection")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    public bool groundDetected { get; private set; }

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();


        //  StateMachine이 MonoBehaviour가 없는 스크립트이기 때문에 직접 할당해주는 과정이 필요 (PlayerInputSet도 마찬가지)
        stateMachine = new StateMachine();
        //아래의 idleState, moveState 코드 두 줄 보다 먼저 실행되어야 한다.
        input = new PlayerInputSet();


        idleState = new Player_IdleState(this, stateMachine, "idle");
        moveState = new Player_MoveState(this, stateMachine, "move");
        jumpState = new Player_JumpState(this, stateMachine, "jumpFall");
        fallState = new Player_FallState(this, stateMachine, "jumpFall");
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
        HandleCollisionDetection();
        stateMachine.UpdateActiveState();
    }


    // 해당 메서드를 만드는 이유 - 단일 진입점(통로를 하나로), 캡슐화, 관심사 분리 등등
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip(xVelocity);
    }


    private void HandleFlip(float xVelocity)
    {
        // 오른쪽으로 이동 시 캐릭터가 왼쪽을 향하고 있는 경우
        // 오른쪽을 향하도록 캐릭터 방향 뒤집기
        // 왼쪽으로 이동 시, 캐릭터가 오른쪽을 향하고 있는 경우
        // 왼쪽을 향하도록 캐릭터 방향 뒤집기

        if (xVelocity > 0 && facingRight == false)
            Flip();
        else if (xVelocity < 0 && facingRight == true)
            Flip();
    }


    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        // 현재상태를 반대 상태로 변경 - true이면 false, false이면 true
        facingRight = !facingRight;
    }

    private void HandleCollisionDetection()
    {
        // 플레이어 위치에서 아래로 groundCheckDistance만큼 보이지 않는 선을 쏴서, 뭔가 맞았으면 groundDetected에 true, 아무것도 안 맞았으면 false를 넣는다.
        // whatIsGround로 걸러내지 않는다면 자기 자신이 감지된다. 
        groundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }


    private void OnDrawGizmos()
    {
        // 오브젝트로부터 지면방향으로 groundCheckDistance 만큼의 라인을 그린다.
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
    }


}
