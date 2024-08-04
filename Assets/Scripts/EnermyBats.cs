using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnermyBats : MonoBehaviour
{
    [SerializeField] private float speed;

    public GameObject ball;

    private Vector2 playerMove;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Limit();
    }

    private void Limit()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        float xBall = ball.transform.position.x;
        float xEnemy = transform.position.x;
        if (xBall > xEnemy + 0.5f)
        {
            playerMove = new Vector2(1, 0);
        }
        else if (xBall < xEnemy - 0.5f)
        {
            playerMove = new Vector2(-1, 0);
        }
        else
        {
            playerMove = new Vector2(0, 0);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = playerMove * speed;
    }
}
