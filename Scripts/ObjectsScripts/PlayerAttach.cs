using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bortoló
public class PlayerAttach : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _player)
            _player.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == _player)
            _player.transform.SetParent(null);
    }
}
