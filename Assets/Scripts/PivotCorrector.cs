using UnityEngine;
using System.Collections;

public class PivotCorrector : StateMachineBehaviour {

    private Vector3 lastTransition = new Vector3(0,0,0);
    private Vector3 currentTransition = new Vector3(0, 0, 0);
    private bool changeInNextFrame = false;
    //SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        changeInNextFrame = true;

        /*
        SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("OnStateEnter sprite: " + sr.sprite.name);
        if (stateInfo.IsName("Standing"))
        {
            //Debug.Log("current transition : " + currentTransition);
            //animator.transform.Translate(-currentTransition);
            currentTransition = new Vector3(0, 0, 0);
            animator.transform.Translate(currentTransition);
            
        }

        if (stateInfo.IsName("BeginFalling") || stateInfo.IsName("Falling"))
        {
            //animator.transform.Translate(-currentTransition);
            currentTransition = new Vector3(0.7f, 0.9f, 0);
            animator.transform.Translate(currentTransition);
        }

        if(stateInfo.IsName("MovingLeftLegtoRight") || stateInfo.IsName("MovingRightLegtoRight"))
        {
            currentTransition = new Vector3(0.7f, 1f, 0);
            animator.transform.Translate(currentTransition);

            sr = animator.gameObject.GetComponent<SpriteRenderer>();
            Vector2 myVector = new Vector2(sr.sprite.pivot.x / sr.sprite.rect.width, sr.sprite.pivot.y / sr.sprite.rect.height);
            animator.transform.parent.TransformVector(myVector);

            Debug.Log("sprite: " + animator.gameObject.GetComponent<SpriteRenderer>().sprite.name + "pivot: " + myVector);
        }*/

        
        //SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();
        //Debug.Log("STATE ENTER sprite: " + sr.sprite.name + " bounds: " + +sr.sprite.rect.width + " " + sr.sprite.rect.height);
        //Debug.Log("trocando posicao de " + animator.gameObject.transform.position + " para "  + (animator.gameObject.transform.position + new Vector3(1, 1)));
        /*
        if(stateInfo.IsName("BeginFalling") || stateInfo.IsName("Falling"))
        {
            lastTransition = new Vector3(0.5f, 0.5f);
            lastTransition = animator.transform.parent.TransformVector(lastTransition);
        }
        if(stateInfo.IsName("MovingLeftLegtoRight") || stateInfo.IsName("MovingRightLegtoRight"))
        {
            lastTransition = new Vector3(0.5f, 0.5f);
            lastTransition = animator.transform.parent.TransformVector(lastTransition);
        }
        
        if (!animator.GetBool("isFacingRight"))
        {
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            lastTransition += animator.transform.parent.TransformVector(new Vector3(-0.25f, 0));
        }
        else
        {
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        animator.gameObject.transform.Translate(lastTransition, Space.World);
        */
        //animator.GetComponent<
        //  SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();
        //  lastTransition = new Vector2(sr.sprite.pivot.x / sr.sprite.rect.width, sr.sprite.pivot.y / sr.sprite.rect.height);
        //  lastTransition = animator.transform.parent.TransformVector(lastTransition);
        //   animator.gameObject.transform.Translate(lastTransition, Space.World);



        //lastTransition = new Vector3(0, 0);
        //lastTransition = lastTransition + ;
        // lastTransition = animator.transform.parent.TransformVector(lastTransition);

        //  Debug.Log("" + sr.sprite.pivot);
        //  Debug.Log("sprite: " + sr.sprite.name +" bounds: " + +sr.sprite.rect.width + " " + sr.sprite.rect.height);
        //sr.sprite.border
        //animator.pi
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();
        GameObject myGameObject = new GameObject();
        SpriteRenderer TS = myGameObject.GetComponent<SpriteRenderer>();


        Debug.Log("OnStateUpdate sprite: " + sr.sprite.name);

        if(changeInNextFrame)
        {
            //animator.transform.Translate(currentTransition);

            sr = animator.gameObject.GetComponent<SpriteRenderer>();
            Vector2 myPivot = new Vector2(sr.sprite.pivot.x / sr.sprite.rect.width, sr.sprite.pivot.y / sr.sprite.rect.height);
            animator.transform.parent.TransformVector(myPivot);

            animator.transform.Translate(myPivot);

            Debug.Log("sprite: " + animator.gameObject.GetComponent<SpriteRenderer>().sprite.name + "pivot: " + myPivot);
            changeInNextFrame = false;
        }
        //animator.gameObject.transform.Translate(lastTransition, Space.World);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("OnStateExit sprite: " + sr.sprite.name);
        animator.transform.Translate(-currentTransition);
        //animator.gameObject.transform.Translate(lastTransition, Space.World);

        /*
        animator.gameObject.transform.Translate(-lastTransition, Space.World);
        SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();
        currentTransition = new Vector2(sr.sprite.pivot.x / sr.sprite.rect.width, sr.sprite.pivot.y / sr.sprite.rect.height); //sprite ainda ta retornando o sprite errado
        currentTransition = animator.transform.parent.TransformVector(currentTransition);
        animator.gameObject.transform.Translate(currentTransition, Space.World);
        
        Debug.Log("last transition: " + lastTransition + " current transition: " + currentTransition);
        lastTransition = currentTransition;*/




        //animator.gameObject.transform.position = animator.gameObject.transform.position - lastTransition;
        /*

        if (!animator.GetBool("isFacingRight"))
        {
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            //lastTransition += animator.transform.parent.TransformVector(new Vector3(0.25f, 0));
            Debug.Log("foi");   
        }
        else
        {
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        */
        //animator.gameObject.transform.Translate(-lastTransition, Space.World);

        // SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();
        //lastTransition = new Vector2(sr.sprite.pivot.x / sr.sprite.rect.width, sr.sprite.pivot.y / sr.sprite.rect.height);
        //lastTransition = animator.transform.parent.TransformVector(lastTransition);
        //animator.gameObject.transform.Translate(lastTransition, Space.World);

        //Debug.Log("" + sr.sprite.pivot);
        //Debug.Log("STATE EXIT sprite: " + sr.sprite.name + " bounds: " + +sr.sprite.rect.width + " " + sr.sprite.rect.height);

        //animator.pivotPosition

    }

    //OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("OnStateMove sprite: " + sr.sprite.name);
    }

    //OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        SpriteRenderer sr = animator.gameObject.GetComponent<SpriteRenderer>();
        Debug.Log("OnStateIK sprite: " + sr.sprite.name);
    }

    void adjust()
    {
        
    }
}
