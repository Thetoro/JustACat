using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionMano : MonoBehaviour
{
    
    private Collider2D currentCollider;
    private bool isMoving;
    private Rigidbody2D rb;

    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public Collider2D CurrentCollider { get => currentCollider; set => currentCollider = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude > 50)
            isMoving = true;
        else 
            isMoving = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentCollider = other;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentCollider = null;
    }
}
