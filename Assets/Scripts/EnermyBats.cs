using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyBats : MonoBehaviour
{
    public GameObject ball;

    // Update is called once per frame
    void Update()
    {
        Limit();
    }

    private void Limit()
    {
        float x = ball.transform.position.x;
        if (x < -1.72)
        {
            transform.position = new Vector3(-1.72f, 4.89f, 0f);
        }
        else if (x > 1.72)
        {
            transform.position = new Vector3(1.72f, 4.89f, 0f);
        }
        else
        {
            transform.position = new Vector3(x, 4.89f, 0f);
        }
    }
}
