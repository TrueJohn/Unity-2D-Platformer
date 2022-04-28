using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;
    public Collider2D colider;

    Animator animator;
    private SpriteRenderer mySpriteRenderer;
    float movementSpeedmodifier=2;
    float mx;
    [SerializeField] bool isruning = false;
    bool faceright = true;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Update() {
      
        mx = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
        Jump();
            
        }
        if(faceright==true && mx<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            
            faceright = false;

        }
        else if(faceright==false && mx>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceright = true;

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isruning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isruning = false;
        }
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("Jump", !IsGrounded());
    }
    private void FixedUpdate() 
    {
        mx = mx * movementSpeed;
        if (isruning)
            mx = mx * movementSpeedmodifier;
       Vector2 movement = new Vector2(mx,rb.velocity.y);
        rb.velocity = movement;   
    }
    void Jump(){
      Vector2 movement = new Vector2(rb.velocity.x,jumpForce);
      rb.velocity = movement;
    }
    public bool IsGrounded1()
    {
      Collider2D groundCheck = Physics2D.OverlapCircle(feet.position,0.5f,groundLayers);
      if(groundCheck != null){
        return true;
      }
      return false;

    }
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(colider.bounds.center, colider.bounds.size, 0, Vector2.down, 0.1f, groundLayers);
        return hit.collider != null;
    }

}
