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
    //public Combat combat;
    

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

    //pour ignorer des scirpt (eviter le doublon)
    private void scripteAIgnorerF()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            gameObject.layer = 6;
            foreach (var scripte in scripteAIgnorer)
            {
                scripte.enabled = false;
            }
        }

        else if (photonView.IsMine)
        {
            gameObject.layer = 7;
        }
    }

    //deplacement du joueur
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
        if (_velocity > 0.1f && this.gameObject.transform.localScale.x > 0)
        {
        
            this.gameObject.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            jeTourne = true;
        }
        else if (_velocity < -0.1f && this.gameObject.transform.localScale.x < 0)
        {
            this.gameObject.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            jeTourne = false;
            
        }
    }


    //Synchronization des input et output
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(jeTourne);
            stream.SendNext(Ennemy.instance.currentHealth);
            stream.SendNext(Combat.instance.jAttaque);
            stream.SendNext(Ennemy.instance.jeMeurt);

            
            
        }
        else
        {
            // Network player, receive data
            this.jeTourne = (bool)stream.ReceiveNext();
            Ennemy.instance.currentHealth = (int)stream.ReceiveNext();
            Combat.instance.jAttaque = (bool)stream.ReceiveNext(); 
            Ennemy.instance.jeMeurt = (bool)stream.ReceiveNext();
            
        }
    }
    



 



    
}
