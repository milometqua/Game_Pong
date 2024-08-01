using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private int scorePlayer;
    private int scoreEnermy;
    private Rigidbody2D rb;

    public Text _playerScore; // teen bien dat chua dung
    public Text _enemyScore;
    public GameObject _playerBats;
    public GameObject _enemyBats;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        scorePlayer = 0;
        scoreEnermy = 0;
        //_enemyBats = GameObject.Find("Up");
        //_playerBats = GameObject.Find("Down");
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        int directionX = Random.Range(-2, 2);
        int directionY = Random.Range(-2, 2);

        if (directionX == 0)
        {
            directionX = 1;
        }
        else if (directionY == 0)
        {
            directionY = 1;
        }
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(2);
        rb.velocity = new Vector2(6f * directionX, 6f * directionY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BatsPlayer"))
        {
            float playerPosX = _playerBats.transform.position.x;
            if (playerPosX > 0.2f)
            {
                rb.velocity = new Vector2(-10f, 10f);
            }
            else if (playerPosX < -0.2f)
            {
                rb.velocity = new Vector2(10f, 10f);
            }
            else
            {
                rb.velocity = new Vector2(0f, 10f);
            }
        }
        else if (collision.gameObject.CompareTag("BatsEnermy")) // sai chinh ta
        {
            if (_enemyBats.transform.position.x > 0.2f)
            {
                rb.velocity = new Vector2(-10f, -10f);
            }
            else if (_enemyBats.GetComponent<Rigidbody2D>().velocity.x < -0.2f)
            {
                rb.velocity = new Vector2(10f, -10f);
            }
            else
            {
                rb.velocity = new Vector2(0f, -10f);
            }
        }
        if (collision.gameObject.CompareTag("ScorePlayer"))
        {
            ++scoreEnermy;
            _enemyScore.text = scoreEnermy.ToString();
            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
        }
        else if(collision.gameObject.CompareTag("ScoreEnermy"))
        {
            ++scorePlayer;
            _playerScore.text = scorePlayer.ToString();
            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
        }
    }
}
