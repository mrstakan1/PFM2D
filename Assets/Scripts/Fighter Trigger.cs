using UnityEngine;

public class FighterTrigger : MonoBehaviour
{
    private Fighter _fighter;

    private void Awake()
    {
        _fighter = GetComponent<Fighter>();
    }

    protected void Attack(Fighter enemy)
    {
        if (_fighter.CanAttack == true)
        {
            enemy.TakeDamage(_fighter.Damage);
            _fighter.Cooldown();
        }
        else
        {
            Debug.Log(gameObject.name + "`s attack on cooldown!");
        }
    }
}
