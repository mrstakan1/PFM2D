using UnityEngine;

public class Enemy : FighterTrigger
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Fighter player) == true && collision.TryGetComponent(out Player _) == true)
        {
            Attack(player);
        }
    }
}
