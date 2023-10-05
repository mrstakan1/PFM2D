using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpForce = 5f;

    public bool IsJumping { get; private set; }
    public bool IsOnGround { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PlayerAnimator>(); // onvalidate
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsOnGround = true;
        IsJumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsOnGround = false;
    }

    private void Move()
    {
        if(_rigidbody2D.velocity.x == 0 && IsOnGround == false) { _playerAnimator.Idle(); }

        float xValue = Input.GetAxis("Horizontal");

        if(xValue != 0)
            _playerAnimator.Run();

        _rigidbody2D.velocity = new Vector2(xValue * _moveSpeed * Time.deltaTime, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (IsJumping == true || IsOnGround == false) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _playerAnimator.Jump();

            IsJumping = true;
        }
    }
}