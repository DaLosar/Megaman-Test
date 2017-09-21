using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    Animator anim;
    private float horizontalSpeed = 0;
    private float verticalSpeed = 0;
    private float middleX = 1;
    private float middleY = 1;
    private bool isMoving = false;
    private Collider2D myCollider;
    private bool isFacingRight = true;
    private bool isStartingToMove = true;
    private int framesAccelerating = 0;
    public float jumpSpeed = 0;
    public float walkSpeed = 0;
    public float fallDownMaxSpeed = 0;
    public float fallDownAcceleration = 0;
    public Vector2 teste;
    private bool isSlidingLeft = false;
    private bool isSlidingRight = false;

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        //Debug.Log("" + myCollider.name);
	}
	
	// Update is called once per frame
    void Update ()
    {
        //Physics2D.queriesStartInColliders = false;
        RaycastHit2D hitDownLeft = Physics2D.Raycast(new Vector2(transform.position.x + 0.28f, transform.position.y - 0.001f), Vector2.down);
        RaycastHit2D hitDownMiddle = Physics2D.Raycast(new Vector2(transform.position.x + 0.7f, transform.position.y - 0.001f), Vector2.down);
        RaycastHit2D hitDownRight = Physics2D.Raycast(new Vector2(transform.position.x + 1.12f, transform.position.y - 0.001f), Vector2.down);
        //Debug.Log(hitDownRight.point);

        bool shouldBePulledDownLeft = hitDownLeft.transform == null || hitDownLeft.distance > 0.0f;
        bool shouldBePulledDownMiddle = hitDownMiddle.transform == null || hitDownMiddle.distance > 0.0f;
        bool shouldBePulledDownRight = hitDownRight.transform == null || hitDownRight.distance > 0.0f;

        RaycastHit2D hitRightTop = Physics2D.Raycast(new Vector2(transform.position.x + 1.121f, transform.position.y + 1.84f), Vector2.right);
        RaycastHit2D hitRightMiddle = Physics2D.Raycast(new Vector2(transform.position.x + 1.121f, transform.position.y + 0.92f), Vector2.right);
        RaycastHit2D hitRightBottom = Physics2D.Raycast(new Vector2(transform.position.x + 1.121f, transform.position.y + 0.00f), Vector2.right);

        RaycastHit2D hitLeftTop = Physics2D.Raycast(new Vector2(transform.position.x + 0.279f, transform.position.y + 1.84f), Vector2.left);
        RaycastHit2D hitLeftMiddle = Physics2D.Raycast(new Vector2(transform.position.x + 0.279f, transform.position.y + 0.92f), Vector2.left);
        RaycastHit2D hitLeftBottom = Physics2D.Raycast(new Vector2(transform.position.x + 0.279f, transform.position.y + 0.00f), Vector2.left);

        Debug.Log(hitLeftMiddle.distance);


        //RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - 1f, transform.position.y + 1.8f), Vector2.left);
        //Debug.Log(gameObject.transform.TransformVector(new Vector3(1, 1, 1)));
        //Debug.Log(gameObject.transform.InverseTransformVector(new Vector3(1, 1, 1)));

        if (shouldBePulledDownLeft && shouldBePulledDownMiddle && shouldBePulledDownRight)
        {
            float result = verticalSpeed + fallDownAcceleration;
            //Debug.Log(result);
            if(result < fallDownMaxSpeed)
            {
                verticalSpeed = fallDownMaxSpeed;
            }
            else
            {
                verticalSpeed = result;
            }
        }
        else
        {
            verticalSpeed = 0;
        }


        //RaycastHit2D teste = Physics2D.Raycast()
        //Debug.Log("" + hitDown.collider.name);
        //BoxCollider2D teste;
        //teste.

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (hitRightBottom.transform == null || hitRightBottom.distance > 0.2f &&
                hitRightMiddle.transform == null || hitRightMiddle.distance > 0.2f && 
                hitRightTop.transform == null || hitRightTop.distance > 0.2f)
            {

                if (framesAccelerating < 7)
                {
                    framesAccelerating++;
                    horizontalSpeed = walkSpeed/2;
                }
                else
                {
                    horizontalSpeed = walkSpeed;
                }
                
                //Debug.Log("horizontalspeed: " + horizontalSpeed);
                //Debug.Log("distance: " + hitRight.distance);
            }
            else
            {
                horizontalSpeed = 0;
            }
            isFacingRight = true;
            //Debug.Log("distance: " + hitRight.distance);
        }
        else
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (hitLeftBottom.transform == null || hitLeftBottom.distance > 0.2f &&
                    hitLeftMiddle.transform == null || hitLeftMiddle.distance > 0.2f &&
                    hitLeftTop.transform == null || hitLeftTop.distance > 0.2f)
                {

                    if (framesAccelerating < 7)
                    {
                        framesAccelerating++;
                        horizontalSpeed = -walkSpeed/2;
                    }
                    else
                    {
                        horizontalSpeed = -walkSpeed;
                    }
                    
                    //GetComponentInChildren<SpriteRenderer>().flipX = true;
                    //Debug.Log("horizontalspeed: " + horizontalSpeed);
                    //Debug.Log("distance: " + hitRight.distance);
                }
                else
                {
                    horizontalSpeed = 0;
                }
                //Debug.Log("distance: " + hitRight.distance);
                isFacingRight = false;
            }
            else
            {
                horizontalSpeed = 0;
            }
            
        }

        if (Input.GetButtonDown("Jump"))
        {
            
            if (hitDownLeft.distance == 0.0f || hitDownMiddle.distance == 0.0f || hitDownRight.distance == 0.0f)
            {
                //Debug.Log("Jump!");
                verticalSpeed = jumpSpeed;
            }
        }

        float distanceToGround = hitDownLeft.distance;
        if(hitDownMiddle.distance < distanceToGround)
        {
            distanceToGround = hitDownMiddle.distance;
        }
        else
        {
            if (hitDownRight.distance < distanceToGround)
            {
                distanceToGround = hitDownRight.distance;
            }
        }
        //Debug.Log("Distance to ground was: " + distanceToGround);
        //Debug.Log("gone down " + verticalSpeed * Time.deltaTime + " units in the previous frame");


        if (-(verticalSpeed * Time.deltaTime) > distanceToGround)
        {
            //verticalSpeed = distanceToGround/ Time.deltaTime;
            GetComponent<Transform>().Translate(new Vector3(horizontalSpeed * Time.deltaTime, -distanceToGround));
        }
        else
        {
            GetComponent<Transform>().Translate(new Vector3(horizontalSpeed, verticalSpeed) * Time.deltaTime);

        }

        //GetComponent<Transform>().Translate(new Vector3(horizontalSpeed, verticalSpeed) * Time.deltaTime);


        if (horizontalSpeed != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
            framesAccelerating = 0;
        }

        //AdjustPivot();

        anim.SetFloat("verticalSpeed", verticalSpeed);
        anim.SetFloat("horizontalSpeed", horizontalSpeed);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isFacingRight", isFacingRight);
        //horizontalSpeed = 0;
        //verticalSpeed = 0;
    }

	void FixedUpdate ()
    {

	}
}
