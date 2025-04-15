using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;

    private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        moveHand();
        
    }

    private void moveHand()
    {
        Vector2 v = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.velocity = v * speed;
    }
}
