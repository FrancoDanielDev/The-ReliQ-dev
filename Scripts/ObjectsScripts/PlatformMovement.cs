using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco && Bortoló
public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] _waypoints;
    [SerializeField] private float _platformSpeed;

    private int _currentWP;

    void Update()
    {
        if (Vector3.Distance(transform.position, _waypoints[_currentWP].transform.position) < 0.1f)
        {
            _currentWP++;

            if (_currentWP >= _waypoints.Length)
            {
                _currentWP = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWP].transform.position, _platformSpeed * Time.deltaTime);
    }
}
