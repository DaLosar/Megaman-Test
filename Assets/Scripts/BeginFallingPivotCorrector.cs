using UnityEngine;
using System.Collections;

public class BeginFallingPivotCorrector : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        SpriteRenderer sr;
        sr = animator.gameObject.GetComponent<SpriteRenderer>();
        //Vector2 myPivot = new Vector2(sr.sprite.pivot.x / sr.sprite.rect.width, sr.sprite.pivot.y / sr.sprite.rect.height);
        Vector2 myPivot = new Vector2(0.7f, 1f);
        animator.transform.parent.TransformVector(myPivot);

        
        animator.transform.Translate(myPivot);

        //Debug.Log("sprite: " + animator.gameObject.GetComponent<SpriteRenderer>().sprite.name + "pivot: " + myPivot);
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Vector2 myPivot = new Vector2(-0.7f, -1f);
        animator.transform.parent.TransformVector(myPivot);

        animator.transform.Translate(myPivot);
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
