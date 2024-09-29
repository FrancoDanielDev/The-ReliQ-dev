using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco && Bortoló
public class CheckpointBehavior : MonoBehaviour
{
    public GameObject lastCheckpoint;

    [SerializeField] private GameObject[] _boxes;
    [SerializeField] private Vector3[] _boxesPosition;
    [SerializeField] private Rigidbody _player;

    public CheckpointSub _cpSub;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && (_cpSub != null))
        {
            _cpSub.BackToCheckpoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cpSub = new CheckpointSub(_boxes, _boxesPosition, _player, gameObject);

            if (lastCheckpoint != null)
            {
                lastCheckpoint.SetActive(false);
            }

            AudioManager.instance.Play("Checkpoint");

            if (other.GetComponent<Entity>().life != 3)
            {
                other.GetComponent<Entity>().life = 3;
                UIManager.instance.HealthUpdate(other.GetComponent<Entity>().life);
                other.GetComponent<Player>().healingParticle.Play();
            }
            
            PauseMenu.instance.check = this;
        }
    }
}
