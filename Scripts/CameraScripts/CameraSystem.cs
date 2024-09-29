using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco
public class CameraSystem : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _yAxis, _zAxis;

    [HideInInspector] public static bool shake = false;

    private void Start()
    {
        gameObject.transform.parent = null;      
    }

    void Update()
    {
        if (shake == false)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + _yAxis, _player.transform.position.z + _zAxis);
        }        
    }
}
