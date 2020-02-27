using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerControls : MonoBehaviour
{
    public float defaultSpeed, tempSpeed, jumpForce;
    private Rigidbody2D myRB;
    private Animator anim;
    private PlayerHealth playerHealth;

    public GameObject whip;
    [SerializeField] float whipTimer;

    private bool grounded;
    private bool facingRight = true;
    private bool canFlip = true;
    private bool isAttacking = false;
    private bool canMove = true;
    private bool canCrouch = true;
    [SerializeField]private bool isCrouching = false;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        anim = GetComponent<Animator>();
        myRB = GetComponent<Rigidbody2D>();
        myRB.gravityScale = 2.5f;
        myRB.freezeRotation = true;
        whip.SetActive(false);
        tempSpeed = defaultSpeed;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(myRB.velocity.x));

        if (canMove)
        {
            myRB.velocity = new Vector2(h * defaultSpeed, myRB.velocity.y);           //acceleration movement
                                                                                      //if (Input.GetKey(KeyCode.D))
                                                                                      //{
                                                                                      //    transform.Translate(Vector2.right * tempSpeed * Time.deltaTime);
                                                                                      //}
                                                                                      //if (Input.GetKey(KeyCode.A))
                                                                                      //{
                                                                                      //    transform.Translate(Vector2.right * -tempSpeed * Time.deltaTime);
                                                                                      //}
        }

        if (!canMove)
        {
            myRB.velocity = new Vector2(0, myRB.velocity.y);
        }

        //if D, right arrow key, or right analog stick player will face left
        if (myRB.velocity.x > 0 && !facingRight && canFlip)
        {
            Flip();
        }
        //if A, left arrow key, < or left analog stick player will face left
        else if (myRB.velocity.x < 0 && facingRight && canFlip)
        {
            Flip();
        }

        if (isAttacking && grounded)
        {
            myRB.velocity = new Vector2(myRB.velocity.x * 0, myRB.velocity.y * 0);
        }
        else if(isAttacking && !grounded)
        {
            canMove = true;
        }

        if(!grounded)
        {
            canCrouch = false;
        }
        if(grounded)
        {
            canCrouch = true;
        }

        if (isAttacking && !grounded)
        {
            //canMove = true;
        }
        else
        {
            //canMove = true;
        }

        Jump();
        Crouch();
        WhipAttack();
    }

    private void Crouch()
    {
        if(isCrouching)
        {
            defaultSpeed = tempSpeed / 2;
        }
        else
        {
            defaultSpeed = tempSpeed;
        }

        if (canCrouch)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                isCrouching = true;
                anim.SetBool("Crouch", true);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                isCrouching = false;
                anim.SetBool("Crouch", false);

            }
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && grounded)
        {
            //myRB.velocity = Vector2.up * jumpForce;
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            playerHealth.HurtPlayer(1);
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

    private void WhipAttack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetFloat("Speed", 0);
            StartCoroutine(WhipTimer());
        }
    }

    private IEnumerator WhipTimer()
    {
        whip.SetActive(true);
        canMove = false;
        canFlip = false;
        isAttacking = true;
        yield return new WaitForSeconds(whipTimer);
        whip.SetActive(false);
        canMove = true;
        canFlip = true;
        isAttacking = false;
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0, 180f, 0);
    }
}
