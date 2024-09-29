using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco
public class SentryVisionRange : MonoBehaviour
{
    [SerializeField] private Sentry _mainScript;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _mainScript.LookAt();
            _mainScript.Shoot();
        }
    }
}
