using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco & Bortoló
public class PlayerControl
{
    private PlayerMovement _movement;
    private PlayerDash _dash;
    private PlayerAttack _attack;
    private Animator _animator;
    private Transform _camera;
    private MonoBehaviour _monoB;

    private Vector3 _inputVector, _auxVector;

    private float _dashTime = 0;
    private float _dashCD = 1;
    private float _time = 0;
    private float _length = .55f;

    private bool canDash;

    public PlayerControl(PlayerMovement m, PlayerAttack a, PlayerDash d, Animator anim, Transform charCam, MonoBehaviour mono)
    {
        _movement = m;
        _attack = a;
        _dash = d;
        _animator = anim;
        _camera = charCam;
        _monoB = mono;
    }

    public void ArtificialUpdate()
    {
        _inputVector.x = Input.GetAxisRaw("Horizontal");
        _inputVector.z = Input.GetAxisRaw("Vertical");
        _inputVector.y = 0;
        _inputVector.Normalize();

        _auxVector = _inputVector.z * _camera.transform.forward;
        _auxVector.y = 0;
        _auxVector += _inputVector.x * _camera.transform.right;
        _auxVector.Normalize();

        _animator.SetFloat("Movement", _inputVector.magnitude);
        _time += Time.deltaTime;
        _dashTime += Time.deltaTime;

        if (_inputVector.magnitude >= 0.01f)
        {
            _movement.Move(_inputVector, _auxVector);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _time >= _length)
        {
            _attack.Attack();
            _time = 0;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && _dashTime >= _dashCD)
        {
            _monoB.StartCoroutine(_dash.Dash());
            _dashTime = 0;
            canDash = false;
            UIManager.instance.DashUpdate(canDash);
        }

        if(_dashTime >= _dashCD)
        {
            canDash = true;
            UIManager.instance.DashUpdate(canDash);
        }
    }
}
