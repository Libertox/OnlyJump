using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event EventHandler OnJumped;

    private readonly float gravity = -9.81f;
    private readonly float gravityScale = 1.07f;

    [SerializeField] private float jumpHeight;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private LayerMask groundLayerMask;

    private float jumpForce;
    private Vector2 size;
  
    private void Start()
    {
        jumpForce = CalculateJumpForce();
        size = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    private float CalculateJumpForce() => Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravityScale));
    
    private void FixedUpdate()
    {
        velocity.y += gravity * Time.deltaTime * gravityScale;

        if (GroundCheck() && velocity.y < 0) 
            velocity.y = 0;

        if (CanJump())
        {
            velocity.y = jumpForce;
            OnJumped?.Invoke(this, EventArgs.Empty);
        }
           
        transform.Translate(velocity * Time.deltaTime);
    }

    private bool CanJump() => ((Input.GetKey(KeyCode.Space) || Input.touchCount > 0) && GroundCheck());

    private bool GroundCheck()
    {
        if (Physics2D.OverlapBox(transform.position , size, 0, groundLayerMask))
            return true;
       
       return false;  
    }
}
