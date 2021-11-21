using UnityEngine;
using UnityEngine.Events;

public class EventSystemController : MonoBehaviour
{
    public UnityEvent onBallLose;
    public UnityEvent onCanPlay;
    void Awake()
    {
        onBallLose = new UnityEvent();
        onCanPlay = new UnityEvent();
    }
}
