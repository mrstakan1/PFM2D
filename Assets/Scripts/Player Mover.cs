using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private UnityEvent _jumpStarted;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpForce = 5f;

    public bool IsJumping { get; private set; }
    public bool IsOnGround { get; private set; }
    public float Velocity => _rigidbody2D.velocity.x;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { 
            IsOnGround = true;
            IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            IsOnGround = false;
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(horizontalInput != 0)
        {
            transform.localScale = new Vector3(horizontalInput, transform.localScale.y, transform.localScale.z);
        }
        
        _rigidbody2D.velocity = new Vector2(horizontalInput * _moveSpeed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (IsJumping == true || IsOnGround == false) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            _jumpStarted?.Invoke();

            IsJumping = true;
        }
    }
}