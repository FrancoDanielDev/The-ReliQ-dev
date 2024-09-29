using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco && Bortoló
public class PressurePlate : MonoBehaviour
{
    [SerializeField] private NewDoor[] _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            for (int i = 0; i < _door.Length; i++)
            {
                _door[i].Active();
                AudioManager.instance.Play("PlateActive");
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            for (int i = 0; i < _door.Length; i++)
            {
                _door[i].Inactive();
            }
        }
    }
}
