using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bortoló
public class EndEnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesToEnable, _enemiesToDisable;
    [SerializeField] private EndSequence _endSequence;

    private void Start()
    {
        _endSequence.startEndingEvent += EnemySpawn;
    }

    void EnemySpawn()
    {
        for (int i = 0; i < _enemiesToEnable.Length; i++)
        {
            _enemiesToEnable[i].SetActive(true);
        }

        _endSequence.startEndingEvent -= EnemySpawn;
    }
}
