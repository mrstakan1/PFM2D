using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Spawnpoint[] _spawnpoints;
    [SerializeField] private Transform[] _endPoints;

    private float _delay = 2f;
    private WaitForSeconds _timeToSpawn;
    private int _amountOfEnemies = 1;

    private void Awake()
    {
        _timeToSpawn = new WaitForSeconds(_delay);
        _spawnpoints = GetComponentsInChildren<Spawnpoint>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void CreateEnemy()
    {
        Spawnpoint spawnpoint = _spawnpoints[Random.Range(0, _spawnpoints.Length)];
        Enemy enemy = Instantiate(spawnpoint.GetPrefab(), spawnpoint.transform.position, Quaternion.identity);
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