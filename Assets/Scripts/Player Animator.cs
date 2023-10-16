using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    const string RunTrigger = "Run";
    const string IdleTrigger = "Idle";
    const string JumpTrigger = "Jump";
    const string HitTrigger = "Hit";

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _player;

    private bool _isRunning = false;

    private void OnValidate()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    public void Idle()
    {
        _animator.SetTrigger(IdleTrigger);
    }

    public void Run()
    {
        _animator.SetTrigger(RunTrigger);
    }

    public void Jump()
    {
        _animator.SetTrigger(JumpTrigger);
    }

    public void Hit()
    {
        _animator.SetTrigger(HitTrigger);
    }
}