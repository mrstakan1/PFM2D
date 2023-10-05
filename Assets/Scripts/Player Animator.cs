using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    const string RunTrigger = "Run";
    const string IdleTrigger = "Idle";
    const string JumpTrigger = "Jump";

    [SerializeField] private Animator _animator;

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
}