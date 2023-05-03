using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatLogic : MonoBehaviour
{
    //Надо понять когда нажимается кнопка несколько раз и в зависимости от этого включать анимации.
    public static Action<string> onAttack;

    private int numberOfHit = 0;
    private bool isCanAtack = true;
    private bool isAttacking = false;

    public void PressOnButtonAtack()
    {
        numberOfHit++;

        Attack();
        if(numberOfHit > 3) numberOfHit = 0;
            
    }

    private void Attack()
    {
        if (isCanAtack == true)
        {
            onAttack?.Invoke("Hit" + numberOfHit.ToString());
            isCanAtack = false;
            isAttacking = true;
        }

    }

    private IEnumerator OnAnimationEnd()
    {
        yield return new WaitForSeconds(0.5f);


    }

    private void ComboActivity()
    {

    }

    public void EndAtack()
    {
        isCanAtack = true;
    }
}
