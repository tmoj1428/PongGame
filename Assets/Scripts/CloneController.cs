using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{

    public void MoveClone(float moveAmount, bool isUp)
    {
        if (isUp)
        {
            transform.position -= new Vector3(0, moveAmount, 0);
        }
        else
        {
            transform.position += new Vector3(0, moveAmount, 0);
        }
        
    }
}
