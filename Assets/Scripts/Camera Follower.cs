using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollowPosition;


    private float zOffset = -2f;
    private Vector3 _position;

    private void Awake()
    {
        _position = new Vector3(0, 0, zOffset);
    }

    private void LateUpdate()
    {

        float currentXPosition = _position.x + _objectToFollowPosition.transform.position.x;

        transform.position = new Vector3(currentXPosition, _position.y, _position.z);
    }
}
