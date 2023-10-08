using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;

    private float _delay = 2f;
    private WaitForSeconds _timeToSpawn;
    private int _amountOfEnemies = 1;

    private void Awake()
    {
        _timeToSpawn = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void CreateEnemy()
    {
        Instantiate(_prefab,transform.position, Quaternion.identity);
    }

    private IEnumerator Spawn()
    {
        while(_amountOfEnemies != 0)
        {
            CreateEnemy();
            _amountOfEnemies--;

            yield return _timeToSpawn;
        }
    }
}