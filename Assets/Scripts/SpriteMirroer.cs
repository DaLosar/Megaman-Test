using UnityEngine;
using System.Collections;

public class SpriteMirroer : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (!animator.GetBool("isFacingRight"))
        {
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            //lastTransition += animator.transform.parent.TransformVector(new Vector3(-0.25f, 0));
            animator.transform.Translate(1f-animator.transform.position.x,0,0);
        }
        else
        {
            animator.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

    }

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
