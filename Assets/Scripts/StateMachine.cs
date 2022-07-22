using UnityEngine;

public class StateMachine : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimationController.IsPlayingAnimation = false;
        animator.enabled = false;
        Debug.Log("End Animation");
    }
}