using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bortoló
public class PlayerMovement
{
    public Vector3 moveDirection;

    private Transform _transform;
    private Rigidbody _pRB;
    private float _playerSpeed;

    public PlayerMovement(Transform t, Vector3 mD, Rigidbody mRB, float pS)
    {
        _transform = t;
        moveDirection = mD;
        _pRB = mRB;
        _playerSpeed = pS;
    }

    public void Move(Vector3 lM, Vector3 aux)
    {
        _transform.forward = aux;

        _transform.position += (_transform.forward * lM.magnitude * _playerSpeed * Time.fixedDeltaTime * Time.timeScale);
    }
}
