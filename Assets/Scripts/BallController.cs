using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public EventSystemController eventSys;

    private Rigidbody2D rb2d;
    private bool ballPlay;

    void Start()
    {
        ballPlay = true;
        rb2d = GetComponent<Rigidbody2D>();
        Launch();
        eventSys.onCanPlay.AddListener(changePlayBall);
        eventSys.onBallLose.AddListener(RestartGame);
    }

    public void Launch()
    {
        transform.position = new Vector2(0, getRandomY());
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(0.02f, -0.01f));
        }
        else
        {
            rb2d.AddForce(new Vector2(-0.02f, -0.01f));
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public void RestartGame()
    {
        if (ballPlay)
        {
            ResetBall();
            Launch();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.CompareTag("Clone"))
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPosition, Vector2 paddlePosition, float PaddleHeight)
    {
        return (ballPosition.y - paddlePosition.y) / PaddleHeight;
    }

    private void changePlayBall()
    {
        ballPlay = false;
    }

    private float getRandomY()
    {
        return Random.Range(-4, 5);
    }
}
