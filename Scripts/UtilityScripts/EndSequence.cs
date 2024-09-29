using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bortoló
public class EndSequence : MonoBehaviour
{
    public delegate void endingEvent();

    public event endingEvent startEndingEvent;

    public void StartEnding()
    {
        if(startEndingEvent != null)
        {
            startEndingEvent();
        }
    }
}
