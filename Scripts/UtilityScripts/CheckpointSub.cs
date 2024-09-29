using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bortoló
public class CheckpointSub
{
    GameObject[] _boxes;
    Vector3[] _boxesPos;
    GameObject _currentCheckpoint;
    Rigidbody _player;

    public CheckpointSub(GameObject[] b, Vector3[] bP, Rigidbody p, GameObject cC)
    {
        _currentCheckpoint = cC;
        _boxes = b;
        _boxesPos = bP;
        _player = p;
    }

    public void BackToCheckpoint()
    {
        for (int i = 0; i < _boxes.Length; i++)
        {
            _boxes[i].transform.position = new Vector3 (_boxesPos[i].x, _boxesPos[i].y, _boxesPos[i].z);
        }

        _player.transform.position = _currentCheckpoint.transform.position;
    }
}
