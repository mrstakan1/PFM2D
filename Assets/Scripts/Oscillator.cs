using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private float _period = 2f;

    private Vector2 _startingPosition;
    private float _movementFactor;

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        if (_period <= Mathf.Epsilon) { return; }

        float pingPong = Mathf.PingPong(Time.time / _period, 1f);

        Vector2 offset = _moveDirection * pingPong;
        transform.position = _startingPosition + offset;
    }
}