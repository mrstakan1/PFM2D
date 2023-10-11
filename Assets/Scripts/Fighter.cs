using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Fighter : MonoBehaviour
{
    [SerializeField] private UnityEvent _hitted;
    [SerializeField] private float _damage;
    [SerializeField] private float _healthPoints = 10;

    public float Damage => _damage;
    public bool CanAttack { get; private set; } = true;

    private WaitForSeconds _cooldown;
    private float _cooldownTime = 3f;

    private void Awake()
    {
        _cooldown = new WaitForSeconds(_cooldownTime);
    }

    public void AddHealth(float health)
    {
        _healthPoints += health;
    }

    public void TakeDamage(float damage)
    {
        _hitted?.Invoke();
        _healthPoints -= damage;

        if (_healthPoints <= 0)
        {
            if(gameObject.name == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Debug.Log("You died! Level restarted.");
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("HE IS DEAD.");
            }
        }
    }

    public void Cooldown()
    {
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        CanAttack = false;

        yield return _cooldown;

        CanAttack = true;
    }
}