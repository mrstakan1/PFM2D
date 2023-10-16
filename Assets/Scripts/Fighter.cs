using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Fighter : MonoBehaviour
{
    const string PlayerTag = "Player";

    [SerializeField] private UnityEvent _hitted;
    [SerializeField] private float _damage;
    [SerializeField] private float _maxHealthPoints = 25;

    private float _healthPoints;

    public float Damage => _damage;
    public bool CanAttack { get; private set; } = true;

    private WaitForSeconds _cooldown;
    private float _cooldownTime = 3f;

    private void Awake()
    {
        _healthPoints = _maxHealthPoints;
        _cooldown = new WaitForSeconds(_cooldownTime);
    }

    public void AddHealth(float health)
    {
        _healthPoints += health;

        if (_healthPoints > _maxHealthPoints)
            _healthPoints = _maxHealthPoints;
    }

    public void TakeDamage(float damage)
    {
        _hitted?.Invoke();
        _healthPoints -= damage;

        if (_healthPoints <= 0)
        {
            if(gameObject.name == PlayerTag)
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

    public void StartCooldown()
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