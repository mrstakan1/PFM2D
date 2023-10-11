using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Transform _target;

    public bool ArrivedPoint { get; private set; } = false;

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        ArrivedPoint = false;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (_target.position.x - transform.position.x < Mathf.Epsilon)
            ArrivedPoint = true;
    }
}
