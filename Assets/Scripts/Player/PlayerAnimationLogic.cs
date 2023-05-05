using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAnimationLogic : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public static Action<bool> onAnimationAttackEnd;

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
    }

    public void SetAnimationAttack(string hitVersion,string direction)
    {
        string currentAnim = hitVersion + direction;
        animator.Play(currentAnim); //Start anim of hit

        StartCoroutine(OnAnimationEnd(FindAnimationTime(currentAnim)));
    }

    private float FindAnimationTime(string clipName)
    {
        AnimationClip clip = animator.runtimeAnimatorController.animationClips
            .FirstOrDefault(c => c.name.Equals(clipName));

        if (clip != null)
        {
            return clip.length;
        }
        else
        {
            Debug.LogError($"Animation '{clipName}' not found");
            return 0f;
        }
    }

    IEnumerator OnAnimationEnd(float duration) //Cour for understanding about end amin
    {
        Debug.Log(duration);
        yield return new WaitForSeconds(duration);

        onAnimationAttackEnd?.Invoke(true);
    }
}
