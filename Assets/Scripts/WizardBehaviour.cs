using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private int numberOfAttackingAnimations;

    private int attackingAnimation;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime % 1 < 0.02f)
        {
            attackingAnimation = Random.Range(1, numberOfAttackingAnimations + 1);

            animator.SetFloat("WizardAnimation", attackingAnimation - 1);
        }

        animator.SetFloat("WizardAnimation", attackingAnimation, 0.2f, Time.deltaTime);
    }
}
