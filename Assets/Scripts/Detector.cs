using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private Patrolling _patroll;

    private void Awake()
    {
        _patroll = GetComponentInParent<Patrolling>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player) == true)
        {
            _patroll.FollowPlayer(player);
        }
    }
}
