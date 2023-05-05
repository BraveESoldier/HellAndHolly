using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatLogic : MonoBehaviour
{
    private IButtonClickTracker _buttonClickTracker;

    //Надо понять когда нажимается кнопка несколько раз и в зависимости от этого включать анимации.
    public static Action<string> onAttack;
    public static Action<bool> onAttackEnd;

    private bool isCanStartAttack = true;
    private bool itIsCombo1 = false;
    private bool itIsCombo2 = false;

    private void Awake()
    {
        _buttonClickTracker = new ButtonClickTracker();
    }

    private void Attack(int numberOfHit)//не нравиттся
    {

        onAttack?.Invoke("Hit" + numberOfHit.ToString());
        isCanStartAttack = false;
    }

    public void PressOnButtonAttack()
    {
        _buttonClickTracker.OnButtonClick();
        int numberOfClicks = _buttonClickTracker.GetNumberOfClicks();

        if (numberOfClicks == 1)
        {
            Attack(1);
        }
        else if (numberOfClicks == 2)
        {
            itIsCombo1 = true;
        }
        else if (numberOfClicks == 3)
        {
            itIsCombo2 = true;
        }
    }

    private void AnimationAttackEnd(bool isCan)
    {
        if (itIsCombo1 == true)
        {
            Attack(2);
            itIsCombo1 = false;
        }
        else if(itIsCombo2 == true)
        {
            Attack(3);
            itIsCombo2 = false;
        }
        else
        {
            isCanStartAttack = isCan;
            onAttackEnd?.Invoke(true);
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
