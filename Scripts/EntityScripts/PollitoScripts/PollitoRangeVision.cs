using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco
public class PollitoRangeVision : MonoBehaviour
{
    [SerializeField] private Pollito _pollitoScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _pollitoScript.Follow();
        }
    }
}
