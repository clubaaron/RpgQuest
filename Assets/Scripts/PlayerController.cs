using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D theRB;

    public float movementSpeed;
    public bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        theRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
        
    // Handles player movement.
    void Move()
    {
        if (canMove)
        {
            float deltaX = Input.GetAxisRaw("Horizontal");
            float deltaY = Input.GetAxisRaw("Vertical");
            theRB.velocity = new Vector2(deltaX, deltaY) * movementSpeed;
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
    }
}
