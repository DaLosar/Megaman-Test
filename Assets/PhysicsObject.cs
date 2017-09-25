using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    public float gravityModifier = 1f;
    public float minGroundNormalY = 0.65f; //o quão ingrime uma rampa pode ser antes de ser considerada uma parede
    public float maxFallSpeed = 10f;

    protected Rigidbody2D rb2d;
    protected ContactFilter2D contactFilter;
    protected bool grounded;
    protected bool blocked;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void FixedUpdate()
    {
        grounded = false;
        blocked = false;

        Move(new Vector2(1,1));
    }

    void Move(Vector2 movement)
    {
        Move(movement, false);
        Move(movement, true);
        //Debug.Log(Physics2D.gravity);
        
    }

    void Move(Vector2 movement, bool verticalMovement)
    {
        Vector2 translation;
        if (gravityModifier != 0)
        {
            translation = (movement + Physics2D.gravity * gravityModifier) * Time.deltaTime;
        }
        else
        {
            translation = movement * Time.deltaTime;
        }

        RaycastHit2D[] myHits = new RaycastHit2D[16];
        int count = rb2d.Cast(translation, contactFilter, myHits, translation.magnitude);

        for(int i = 0; i < count; i++)
        {
            Vector2 currentNormal = myHits[i].normal;
            //Vector2 teste = myHits[i].
            if (verticalMovement)
            {
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    translation.y = 0;
                }
            }
            else
            {
                if(currentNormal.x > currentNormal.y)//myHits[i]. se tem objeto na direita colidindo com esse ele não pode andar para a direita
                {
                    //myHits[i].collider
                    blocked = true;
                    translation.x = 0;
                }
            }
        }

        if(verticalMovement)
        {
            //rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y + translation.y));
            rb2d.position = new Vector2(rb2d.position.x, rb2d.position.y + translation.y);
        }
        else
        {
            //rb2d.MovePosition(new Vector2(rb2d.position.x + translation.x, rb2d.position.y));
            rb2d.position = new Vector2(rb2d.position.x + translation.x, rb2d.position.y);
        }
        //rb2d.Cast()
        //Vector2 translation = movement;
        //Vector2 newPosition = rb2d.position + translation;
        //rb2d.MovePosition(newPosition);
        //Debug.Log("teste");
    }

}