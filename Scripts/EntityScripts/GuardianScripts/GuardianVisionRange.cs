using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Franco
public class GuardianVisionRange : MonoBehaviour
{
    [SerializeField] private Animator _animator; 
    [SerializeField] private NavMeshAgent _enemy;
    [SerializeField] private SphereCollider _visionCollider;

    public delegate void MyDelegate();
    public MyDelegate followDelegate = delegate { };

    private void Update()
    {
        followDelegate();
    }

    public void Follow()
    {
        _enemy.isStopped = false;
        _animator.SetBool("Walking", true);

        _enemy.destination = GameObject.FindWithTag("Player").transform.position;
    }

    public void StopFollowing()
    {
        _enemy.isStopped = true;
        _animator.SetBool("Walking", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            followDelegate = Follow;           
            _visionCollider.enabled = false;
        }
    }
}
