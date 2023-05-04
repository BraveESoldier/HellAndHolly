using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationLogic : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public static Action<bool> onAttackEnd;

    public void SetAnimation(bool isMoving, string direction)
    {
        string currentAnim;
        if (isMoving == true)
        {
            currentAnim = "Walk" + direction;
            animator.Play(currentAnim);
        }
        else
        {
            currentAnim = "Idle" + direction;
            animator.Play(currentAnim);
        }
        //Debug.Log(currentAnim);
    }

    public void SetAnimationAttack(string hitVersion,string direction)
    {
        string currentAnim = hitVersion + direction;
        animator.Play(currentAnim); //Start anim of hit
        //Debug.Log(currentAnim);

        StartCoroutine(OnAnimationEnd(0.5f));
    }


    private IEnumerator OnAnimationEnd(float animScore) //Cour for understanding about end amin
    {
        yield return new WaitForSeconds(animScore); //Костыл, надо вернуть время анимации чтобы корутина была универсальной

        onAttackEnd?.Invoke(true);
        //yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
