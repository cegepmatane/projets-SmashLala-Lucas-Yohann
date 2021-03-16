using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class JoueurReseau : MonoBehaviour, IPunObservable
{
    public MonoBehaviour[] scripteAIgnorer;
    private PhotonView photonView;
    private object IsFiring;
    //public Deplacement deplacement;
    

    public float vitesse;
    public float jumpforce;

    private bool isJumping;
    private bool isGrounded;
    private Vector3 velocity = Vector3.zero;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
  


    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public bool jeTourne;

    // Start is called before the first frame update
    void Start()
    {

        
        scripteAIgnorerF();
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);



        float horizontalMovement = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
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
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpforce));
            isJumping = false;
        }
    }


    public void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
        
            this.gameObject.transform.localScale = new Vector3(-1.5f, 1.5f, 0f);
            jeTourne = true;
        }
        else if (_velocity < -0.1f)
        {
            this.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 0f);
            jeTourne = false;
            
        }
    }

    //pour ignorer des scirpt (eviter le doublon)
    private void scripteAIgnorerF()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach (var scripte in scripteAIgnorer)
            {
                scripte.enabled = false;
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(jeTourne);
        }
        else
        {
            // Network player, receive data
            this.jeTourne = (bool)stream.ReceiveNext();
        }
    }
    



 



    
}
