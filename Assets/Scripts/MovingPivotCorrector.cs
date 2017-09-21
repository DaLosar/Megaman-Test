using UnityEngine;
using System.Collections;

public class MovingPivotCorrector : StateMachineBehaviour {
    private bool isFacingRight = true;
    Vector2 myPivot;
    Vector2 accumulatedTranslation;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        bool shouldBeFacingRight = animator.GetBool("isFacingRight");
        myPivot = new Vector2(1f, 1f);

        MirrorCheck(shouldBeFacingRight, animator);

        SpriteRenderer sr;
        sr = animator.gameObject.GetComponent<SpriteRenderer>();
        //Vector2 myPivot = new Vector2(sr.sprite.pivot.x / sr.sprite.rect.width, sr.sprite.pivot.y / sr.sprite.rect.height);
        //Vector2 myPivot = new Vector2(1f, 1f);
        animator.transform.parent.TransformVector(myPivot);
        animator.transform.Translate(myPivot);
        accumulatedTranslation = myPivot;

    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        bool shouldBeFacingRight = animator.GetBool("isFacingRight");
        MirrorCheck(shouldBeFacingRight, animator);
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        SpriteRenderer sr;
        sr = animator.gameObject.GetComponent<SpriteRenderer>();
        //Vector2 myPivot = new Vector2(sr.sprite.pivot.x / sr.sprite.rect.width, sr.sprite.pivot.y / sr.sprite.rect.height);
        if(isFacingRight)
        {
            Vector2 myPivot = new Vector2(-1f, -1f);
        }
        else
        {
            Vector2 myPivot = new Vector2(-1f, -1f);
        }
        
        //animator.transform.parent.TransformVector(myPivot);
        animator.transform.Translate(-accumulatedTranslation);
    }

    public void MirrorCheck(bool shouldBeFacingRight, Animator animator)
    {
        if (!shouldBeFacingRight && isFacingRight)
        {
            isFacingRight = false;
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            myPivot = new Vector2(-0.5f, 0);
            animator.transform.parent.TransformVector(myPivot);
            animator.transform.Translate(myPivot);
            accumulatedTranslation += myPivot;
            //lastTransition += animator.transform.parent.TransformVector(new Vector3(0.25f, 0));
        }
        else
        {
            if (shouldBeFacingRight && !isFacingRight)
            {
                isFacingRight = true;
                animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                myPivot = new Vector2(0.5f, 0);
                animator.transform.parent.TransformVector(myPivot);
                animator.transform.Translate(myPivot);
                accumulatedTranslation += myPivot;
            }
        }
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
