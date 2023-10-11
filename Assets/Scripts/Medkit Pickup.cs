using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitPickup : MonoBehaviour
{
    [SerializeField] private float _healthRestoreAmount = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            Fighter fighter = collision.GetComponent<Fighter>();
            fighter.AddHealth(_healthRestoreAmount);
            Destroy(gameObject);
        }
    }
}