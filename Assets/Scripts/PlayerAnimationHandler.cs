using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    public static PlayerAnimationHandler Instance;
    Animator anim;
    const int ANIMSTATE_IDLE = 0;
    const int ANIMSTATE_WALK = 1;


    private int state = ANIMSTATE_IDLE;

    public string AnimState;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void HandleAnimations(Vector2 move)
    {
        if(move.sqrMagnitude == 0)
        {
            state = ANIMSTATE_IDLE;
            AnimState = "idle";
        }
        else if (move.sqrMagnitude>0)
        {
            state = ANIMSTATE_WALK;
            AnimState = "walk";
        }
        anim.CrossFade(AnimState, .01f);
    }
}
