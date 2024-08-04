using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBats : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
            OnMouseDrag();
        Limit();
    }
    private void OnMouseDrag()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.y = -4.89f;
        transform.rotation = Quaternion.Euler(0, 0, 90);
        transform.position = position;
    }
    private void Limit()
    {
        if(transform.position.x < -3f)
        {
            transform.position = new Vector3(-3f, -4.89f, 0f);
        }
        else if(transform.position.x > 3f)
        {
            transform.position = new Vector3(3f, -4.89f, 0f);
        }
    }
}
