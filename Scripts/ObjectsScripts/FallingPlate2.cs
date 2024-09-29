using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlate2 : MonoBehaviour
{
    public void ResetPos(Vector3 initPos)
    {
        transform.localPosition = initPos;
    }
}
