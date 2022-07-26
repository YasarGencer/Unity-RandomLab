using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
   [SerializeField] float moveSpeed;
    private Vector3 localScale;
    Animator an;
    Rigidbody2D rg;
    public float jumpPower;
    int extraJumps = 2;
    [SerializeField] LayerMask groundLayer;
    public Transform feet;
    int jumpCount=0;
    bool isGround;
    float jumpCooldown;
   
    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        localScale  = transform.localScale;
        an =GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * moveSpeed * Time.deltaTime);
        if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x > 0.5f)
        {
            transform.localScale = new Vector3(-2,localScale.y, localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(2,localScale.y,localScale.z);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                an.SetBool("run", true);
                moveSpeed = 8;
            }
            else
            {
                an.SetBool("walk", true);
                an.SetBool("run", false);
                moveSpeed = 5;
           }
        }
        else
        {
            an.SetBool("walk", false);
            an.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space ) )
        {
            Jump();
        }
        Checkgrounded();
    }
    void Jump()
    {
        if (isGround || jumpCount < extraJumps)
        {
            rg.velocity = new Vector2(rg.velocity.x, jumpPower);
            jumpCount++;
        }
    }
    void Checkgrounded()
    {
        if (Physics2D.OverlapCircle(feet.position,1f, groundLayer))
        {
            isGround = true;
            jumpCount = 0;
            jumpCooldown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCooldown)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}
