using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private EnemyMover _enemyMover;
    private int _pointIndex = 0;
    private Transform _currentPoint;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Start()
    {
        _enemyMover.SetTarget(_points[_pointIndex]);
    }

    private void Update()
    {
        _currentPoint = _points[_pointIndex];

        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.1f)
        {
            _pointIndex = (_pointIndex + 1) % _points.Length;
            _enemyMover.SetTarget(_points[_pointIndex]);
        }
    }

    public void FollowPlayer(Player player)
    {
        this.enabled = false;
        _enemyMover.SetTarget(player.transform);
    }
}