using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject[] _spawnedEnemies;
    [SerializeField] private GameObject[] _spawnLocations;

    private bool canSpawn = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canSpawn)
        {
            for (int i = 0; i < _spawnLocations.Length; i++)
            {
                _spawnedEnemies[i] = Instantiate(_enemies[i], _spawnLocations[i].transform.position, _spawnLocations[i].transform.rotation);
            }

            canSpawn = false;
        }
    }

    public void Despawn()
    {
        if (_spawnedEnemies.Length > 0)
        {
            foreach(GameObject go in _spawnedEnemies)
            {
                Destroy(go);
            }
        }

        canSpawn = true;
    }
}
