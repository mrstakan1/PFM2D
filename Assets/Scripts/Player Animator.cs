using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    const string RunTrigger = "Run";
    const string IdleTrigger = "Idle";
    const string JumpTrigger = "Jump";
    const string HitTrigger = "Hit";

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _player;

    private void OnValidate()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_player.Velocity == 0)
            Idle();
        else
            Run();
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