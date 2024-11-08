using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [SerializeField]KeyCode Jump;
    [SerializeField]KeyCode[] walk;

    [SerializeField] Rigidbody2D rb;

    public float jumpForce;
    public bool stoppedJump;
    public bool grounded;
    public float jumpTime;
    float jumpTimer;

    [SerializeField]float D;
    [SerializeField] float A;

    void Start()
    {
        
    }
    void Update()
    {
        if (!grounded)
        {
            jumpTimer = jumpTimer + Time.deltaTime;
        }
        if(jumpTimer > jumpTime)
        {
            rb.gravityScale = rb.gravityScale + Time.deltaTime * 10;
        }

        if (Input.GetKeyDown(Jump) && grounded && rb.gravityScale < 5)
        {

            rb.gravityScale = 1;
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);

        }
        if (Input.GetKeyUp(Jump))
        {

            stoppedJump = true;

        }
        if(stoppedJump && !grounded)
        {
            rb.gravityScale = 5f;
        }
        else if(rb.linearVelocityY < 0 && !grounded)
        {

            if(rb.gravityScale < 5)
            {
                rb.gravityScale = rb.gravityScale + Time.deltaTime * 10;
            }

        }

        if(grounded)
        {
            stoppedJump = false;
            rb.gravityScale = 1;
            jumpTimer = 0;
        }


        if (Input.GetKey(walk[0]))
        {

            D = D + Time.deltaTime;

        }
        else
        {
            D = 0;
        }
        if (Input.GetKey(walk[1]))
        {

            A= A+ Time.deltaTime;  

        }
        else
        {
            A = 0;
        }

        if(A == 0 && D > 0)
        {
            if (rb.linearVelocityX < 0)
                rb.linearVelocityX += Time.deltaTime * 10;
            rb.linearVelocityX += Time.deltaTime * 5;

        }
        if(A != 0 && D != 0 && D < A)
        {
            if (rb.linearVelocityX < 0)
                rb.linearVelocityX += Time.deltaTime * 10;
            rb.linearVelocityX += Time.deltaTime * 5;
        }
        if(D == 0 && A > 0)
        {
            if (rb.linearVelocityX > 0)
                rb.linearVelocityX -= Time.deltaTime * 10;
            rb.linearVelocityX -= Time.deltaTime * 5;
        }
        if(A!=0 && D != 0 && A < D)
        {
            if (rb.linearVelocityX > 0)
                rb.linearVelocityX -= Time.deltaTime * 10;
            rb.linearVelocityX -= Time.deltaTime * 5;
        }
        if(A == 0 && D == 0 && (rb.linearVelocityX > 0|| rb.linearVelocityX < 0))
        {
            rb.linearVelocityX = rb.linearVelocityX + (-rb.linearVelocityX * 0.01f);
        }
    }
}
