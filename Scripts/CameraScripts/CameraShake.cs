using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    // Camera data

    [SerializeField] private Transform _cameraTransform;
    private Vector3 _originalCameraPosition;

    // Shake data

    private float _actualShakeDuration;
    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _shakeAmount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (_actualShakeDuration > 0)
        {
            _originalCameraPosition = _cameraTransform.localPosition;
            _cameraTransform.localPosition = _originalCameraPosition + Random.insideUnitSphere * _shakeAmount;
            _actualShakeDuration -= Time.deltaTime;
        }
        else
        {
            _actualShakeDuration = 0;
            _cameraTransform.position = _originalCameraPosition;
            CameraSystem.shake = false;
        }
    }

    public void ShakeCamera()
    {
        CameraSystem.shake = true;
        _actualShakeDuration = _shakeDuration;
    }
}
