using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveAmount;
    public CloneController clone;
    public EventSystemController eventSys;
    public int PlayerHearts;
    
    private bool canPlay;

    private void Start()
    {
        canPlay = true;
        PlayerHearts = 3;
        eventSys.onBallLose.AddListener(UpdatePlayerHearts);
    }

    private void Update()
    {
        if (canPlay)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, moveAmount, 0);
                clone.MoveClone(moveAmount, true);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= new Vector3(0, moveAmount, 0);
                clone.MoveClone(moveAmount, false);
            }
        }
    }

    private void UpdatePlayerHearts()
    {
        if (PlayerHearts > 0)
        {
            PlayerHearts -= 1;
        }
        if (PlayerHearts == 0)
        {
            canPlay = false;
            eventSys.onCanPlay.Invoke();
        }
    }

}
