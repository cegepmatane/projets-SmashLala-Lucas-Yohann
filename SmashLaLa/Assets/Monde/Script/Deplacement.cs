
using UnityEngine;
using System.Collections;

public class Deplacement : MonoBehaviour
{

    public float vitesse;
    public float jumpforce;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;


    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;


    private Vector3 velocity = Vector3.zero;



    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        

         float horizontalMovement = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;

             if(Input.GetButtonDown("Jump") && isGrounded )
             {
                 isJumping = true;
             }

        DeplacementJoueur(horizontalMovement);


        Flip(rb.velocity.x);

        float charactervelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("vitesse", charactervelocity);

    }

    public void DeplacementJoueur(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f) ;

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpforce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = true;
        } else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
