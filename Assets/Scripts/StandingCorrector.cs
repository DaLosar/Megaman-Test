using UnityEngine;
using System.Collections;

public class StandingCorrector : StateMachineBehaviour {
    private bool isFacingRight = true;
    private bool shouldBeFacingRight;
    private Vector2 accumulatedTranslation = new Vector2(0, 0);

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        shouldBeFacingRight = animator.GetBool("isFacingRight");
        if (!shouldBeFacingRight && isFacingRight)
        {
            Debug.Log("should be facing right " + shouldBeFacingRight);
            isFacingRight = false;
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            Vector2 myCorrection = new Vector2(1f, 0f);
            myCorrection = animator.transform.parent.TransformVector(myCorrection);
            //animator.transform.Translate(myPivot);
            accumulatedTranslation += myCorrection;
            animator.transform.Translate(accumulatedTranslation);
        }
        else
        {
            if (shouldBeFacingRight && !isFacingRight)
            {
                Debug.Log("should be facing right " + shouldBeFacingRight);
                isFacingRight = true;
                animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                Vector2 myCorrection = new Vector2(-1f, 0f);
                myCorrection = animator.transform.parent.TransformVector(myCorrection);
                //animator.transform.Translate(myPivot);
                accumulatedTranslation += myCorrection;
                animator.transform.Translate(accumulatedTranslation);   
            }
        }
        
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //animator.transform.Translate(-accumulatedTranslation);
        Debug.Log("accumulated translation: " + accumulatedTranslation);
        //accumulatedTranslation = new Vector2(0, 0);
        
        if (!isFacingRight)
        {
            
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
