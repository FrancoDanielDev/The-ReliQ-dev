using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlate : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _timeToStayOn, _timeToReset;
    [SerializeField] private Vector3 _initialPos;
    [SerializeField] private ParticleSystem _breakingParti;
    [SerializeField] private ParticleSystem _smokeParti;

    private delegate void MyDelegate();
    private MyDelegate _myDelegate = delegate { };

    private float _time = 0;

    private void Update()
    {
        _myDelegate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _myDelegate = FallingApart;
            _smokeParti.Play();
            AudioManager.instance.Play("PlatformBreaking");
        }
    }

    private void FallingApart()
    {
        _time += Time.deltaTime;
        
        if (_time >= _timeToStayOn)
        {
            StartCoroutine(Fall());
            _time = 0;
            _myDelegate = delegate { };
        }
    }

    private IEnumerator Fall()
    {
        _breakingParti.Play();
        _rb.useGravity = true;
        _rb.isKinematic = false;
        AudioManager.instance.Stop("PlatformBreaking");
        AudioManager.instance.Play("PlatformFall");

        yield return new WaitForSeconds(2);

        _rb.useGravity = false;
        _rb.isKinematic = true;

        yield return new WaitForSeconds(_timeToReset);

        GetComponentInChildren<FallingPlate2>().ResetPos(_initialPos);
    }
}
