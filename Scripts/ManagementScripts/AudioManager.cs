using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    [SerializeField] private EndSequence _endSequence;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;

        foreach (var S in sounds)
        {
            S.source = gameObject.AddComponent<AudioSource>();
            S.source.clip = S.clip;
            S.source.volume = S.volume;
            S.source.pitch = S.pitch;
            S.source.playOnAwake = S.playOnAwake;
            S.source.loop = S.loop;

            if (S.source.playOnAwake)
                S.source.Play();
        }
    }

    private void Start()
    {
        if(_endSequence != null)
        {
            _endSequence.startEndingEvent += endSection;
        }
    }

    public void Play(string names)
    {
        Sound S = Array.Find(sounds, sound => sound.name == names);

        if (S != null)
            S.source.Play();
        else
            Debug.Log("No Sound");
    }

    public void Stop(string names)
    {
        Sound S = Array.Find(sounds, sound => sound.name == names);

        if (S != null)
            S.source.Stop();
        else
            Debug.Log("No Sound");
    }

    public void endSection()
    {
        Stop("PuzzleTime");
        Play("WaveLVL1");

        _endSequence.startEndingEvent -= endSection;
    }
}
