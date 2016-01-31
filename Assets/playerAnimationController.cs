using UnityEngine;
using System.Collections;

public class playerAnimationController : MonoBehaviour {

    Animator animator;
    enums.PlayerAnimations currentAnimation = enums.PlayerAnimations.Torso_Rig_Idle;

    // Use this for initialization
    void Start() {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    public enums.PlayerAnimations getCurrentAnimation()
    {
        return currentAnimation;
    }

    public void SetIdle()
    {
        animator.Play(enums.PlayerAnimations.Torso_Rig_Idle.ToString());
        currentAnimation = enums.PlayerAnimations.Torso_Rig_Idle;
    }

    public void SetWalk()
    {
        animator.Play(enums.PlayerAnimations.Torso_Rig_Walk.ToString());
        currentAnimation = enums.PlayerAnimations.Torso_Rig_Walk;
    }
}
