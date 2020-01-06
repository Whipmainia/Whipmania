using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour
{
    public float speed, jumpForce;
    private Rigidbody2D myRB;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRB.gravityScale = 2;
        myRB.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        myRB.velocity = new Vector2(h * speed, myRB.velocity.y);

        Jump();
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && grounded)
        {
            myRB.velocity = Vector2.up * jumpForce;
            grounded = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
