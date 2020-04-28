using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D theRB;
    private Animator playerAnim;

    public float movementSpeed;
    public bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        theRB = gameObject.GetComponent<Rigidbody2D>();
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
        
    void Move()
    {
        if (canMove)
        {
            // Move player by updating velocity.
            float deltaX = Input.GetAxisRaw("Horizontal");
            float deltaY = Input.GetAxisRaw("Vertical");
            theRB.velocity = new Vector2(deltaX, deltaY) * movementSpeed;

            // Set values in Animator to determine sprites to show.
            AnimateWalk();
            SetDirection();
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }

        // Make sure player stays within map bounds.
        float maxX = Mathf.Clamp(transform.position.x, SceneManager.instance.bottomLeftCoords.x, SceneManager.instance.topRightCoords.x);
        float maxY = Mathf.Clamp(transform.position.y, SceneManager.instance.bottomLeftCoords.y, SceneManager.instance.topRightCoords.y);
        float maxZ = transform.position.z;
        transform.position = new Vector3(maxX, maxY, maxZ);
    }

    void AnimateWalk()
    {
        playerAnim.SetFloat("moveX", theRB.velocity.x);
        playerAnim.SetFloat("moveY", theRB.velocity.y);
    }

    void SetDirection()
    {
        float horizMovement = Input.GetAxisRaw("Horizontal");
        float vertMovement = Input.GetAxisRaw("Vertical");

        if (horizMovement == 1 || horizMovement == -1 || vertMovement == 1 || vertMovement == -1)
        {
            playerAnim.SetFloat("lastMoveX", horizMovement);
            playerAnim.SetFloat("lastMoveY", vertMovement);
        }
    }
}
