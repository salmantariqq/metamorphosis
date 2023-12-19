using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalInput;
    public float moveSpeed = 30f;
    private Rigidbody2D rb;
    public float jumpForce = 250f;
    private bool isJumping;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
       
        MovePlayer();
        JumpPlayer();
    }


    void MovePlayer() {

        horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

       
    }

    void JumpPlayer() { 
    
    
        
        if(Input.GetButtonDown("Jump") && !isJumping) {

            rb.velocity = new Vector2(rb.velocity.x, 7f);

            isJumping = true;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) { 
        
        isJumping = false;
        
        }
    }



}
