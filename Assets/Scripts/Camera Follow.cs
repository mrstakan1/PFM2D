using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _objectToFollow;

    private float _cameraXPosition;
    private float _cameraYPosition;
    private float _cameraZPosition = -2f;

    private void Awake()
    {
        _cameraXPosition = gameObject.transform.position.x;
        _cameraYPosition = gameObject.transform.position.y;
    }

    private void LateUpdate()
    {

        float cameraCurrentXPosition = _cameraXPosition + _objectToFollow.transform.position.x;

        transform.position = new Vector3(cameraCurrentXPosition, _cameraYPosition, _cameraZPosition);
    }
}
