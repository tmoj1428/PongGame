using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallController : MonoBehaviour
{
    public BallController controller;
    public EventSystemController eventSys;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            eventSys.onBallLose.Invoke();
        }
    }
}
