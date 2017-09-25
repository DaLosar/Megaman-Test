using UnityEngine;
using System.Collections;

public class NewMovement : PhysicObject {

    public float maxSpeed = 7;
    public float jumpTakeoffSpeed = 7;
    public GameObject myBusterShot;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    int framesSinceLastShot = int.MaxValue;

    // Use this for initialization
    void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponentInChildren<Animator>();

    }

    protected override void ComputeVelocity()
    {
        //Debug.Log("aqiu");
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        if(move.x > 0)
        {
            animator.SetBool("isFacingRight", true);
            animator.SetBool("isMoving", true);
        }
        else
        {
            if(move.x < 0)
            {
                animator.SetBool("isFacingRight", false);
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        } 
        //Debug.Log(move);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeoffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if(velocity.y > 0 )
            {
                velocity.y = velocity.y * .5f;
            }
            
        }


        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isShooting", true);
            if(true)
            {
                Debug.Log("shoot!");
                Vector3 shootPosition = gameObject.GetComponent<Transform>().position + new Vector3(1f,1f);
                GameObject.Instantiate(myBusterShot, shootPosition, Quaternion.identity);
            }
            framesSinceLastShot++;
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
        

        animator.SetFloat("verticalSpeed", velocity.y);
        animator.SetFloat("horizontalSpeed", velocity.x);

        targetVelocity = move * maxSpeed;
    }
}
