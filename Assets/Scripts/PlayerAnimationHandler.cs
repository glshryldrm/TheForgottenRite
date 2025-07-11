using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    public static PlayerAnimationHandler Instance;
    Animator anim;
    const int ANIMSTATE_IDLE = 0;
    const int ANIMSTATE_S = 1;
    const int ANIMSTATE_N = 2;
    const int ANIMSTATE_E = 3;
    const int ANIMSTATE_W = 4;
    const int ANIMSTATE_M = 5;

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
            AnimState = "AM Player Idle";
        }
        else
        {
            if (move.y < 0 && state != ANIMSTATE_S)
            {
                state = ANIMSTATE_S;
                AnimState = "AM Player S";
            }
            else if (move.y > 0 && state != ANIMSTATE_N)
            {
                state = ANIMSTATE_N;
                AnimState = "AM Player N";
            }
            else if (move.x < 0 && state != ANIMSTATE_W)
            {
                state = ANIMSTATE_W;
                AnimState = "AM Player W";
            }
            else if (move.x > 0 && state != ANIMSTATE_E)
            {
                state = ANIMSTATE_E;
                AnimState = "AM Player E";
            }
        }
        anim.CrossFade(AnimState, .01f);
    }
}
