using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco && Bortoló
public class NewDoor : MonoBehaviour
{
    [SerializeField] private int _platesRequired;
    [SerializeField] private int _counter;
    [SerializeField] private PushableBox[] _boxes;
    [SerializeField] private EndSequence _endSequence;
    [SerializeField] private ParticleSystem _torchParticle;
     
    private void Start()
    {
        if(_endSequence != null)
        _endSequence.startEndingEvent += ReturnDoor;
    }

    public void Active()
    {
        _counter++;

        if (_counter >= _platesRequired)
        {
            ActivateDoor();
        }
    }

    public void Inactive()
    {
        _counter--;
    }

    private void ActivateDoor()
    {
        AudioManager.instance.Play("MagicDoorOpens");
        this.gameObject.SetActive(false);

        if(_torchParticle != null)
        {
            _torchParticle.Play();
        }
    }

    private void ReturnDoor()
    {
        this.gameObject.SetActive(true);
        _endSequence.startEndingEvent -= ReturnDoor;
    }
}
