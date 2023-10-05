using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    const string Run = "RunRight";

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _lastXPosition;
    private bool _isRunning = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _lastXPosition = gameObject.transform.position.x;

        if (_isRunning == true) return;
    }
}