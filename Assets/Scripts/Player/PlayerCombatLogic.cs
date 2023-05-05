using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatLogic : MonoBehaviour
{
    //Надо понять когда нажимается кнопка несколько раз и в зависимости от этого включать анимации.
    public static Action<string> onAttack;
    public static Action<bool> onAttackEnd;

    private bool isCanAttack = true;
    private bool itIsCombo = false;

    [HideInInspector]
    private int numberOfHit = 0;

    private void Attack()//не нравиттся
    {
        if (isCanAttack == true)
        {
            numberOfHit++;

            onAttack?.Invoke("Hit" + numberOfHit.ToString());
            isCanAttack = false;
        }
        else if (numberOfHit > 1)
        {
            itIsCombo = true;
        }
    }

    public void PressOnButtonAtack()
    {
        Attack();
    }

    private void AnimationAttackEnd(bool isCan) //Жесткая зависимость isCanAttack, конца анимации и возможностью аттаковать
    {
        if (itIsCombo == true)
        {
            Attack();
        }
        else
        {
            isCanAttack = isCan;
            onAttackEnd?.Invoke(true);
            numberOfHit = 0;
        }
    }

    private void OnEnable()
    {
        PlayerAnimationLogic.onAnimationAttackEnd += AnimationAttackEnd;
    }

    private void OnDisable()
    {
        PlayerAnimationLogic.onAnimationAttackEnd -= AnimationAttackEnd;
    }
}
