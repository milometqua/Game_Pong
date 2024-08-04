using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private int scorePlayer;
    private int scoreEnermy;
    private Rigidbody2D rb;
    private int hitCounter;

    [SerializeField] private float _intialSpeed;
    [SerializeField] private float _speedIncrease;

    public Text playerScore;
    public Text enemyScore;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        scorePlayer = 0;
        scoreEnermy = 0;
        Invoke("StartBall", 2f);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, _intialSpeed + (_speedIncrease * hitCounter));
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(0, -1) * (_intialSpeed + _speedIncrease * hitCounter);
    }

    private void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;

        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float directionX, directionY;
        if(transform.position.y > 0)
        {
            directionY = -1;
        }
        else
        {
            directionY = 1;
        }
        directionX = (ballPos.x - playerPos.x) / myObject.GetComponent<Collider2D>().bounds.size.x;
        if(directionX == 0)
        {
            directionX = 0.25f;
        }
        rb.velocity = new Vector2(directionX, directionY) * (_intialSpeed + _speedIncrease * hitCounter);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BatsEnemy") || collision.gameObject.CompareTag("BatsPlayer"))
        {
            PlayerBounce(collision.transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScorePlayer"))
        {
            ++scoreEnermy;
            enemyScore.text = scoreEnermy.ToString();
            this.transform.position = new Vector3(0f, 0f, 0f);
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("ScoreEnermy"))
        {
            ++scorePlayer;
            playerScore.text = scorePlayer.ToString();
            this.transform.position = new Vector3(0f, 0f, 0f);
            ResetBall();
        }
    }
}
