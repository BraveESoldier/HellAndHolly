using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatLogic : MonoBehaviour
{
    //���� ������ ����� ���������� ������ ��������� ��� � � ����������� �� ����� �������� ��������.
    public static Action<string> onAttack;

    private bool isCanAttack = true;

    [HideInInspector]
    public int numberOfHit = 0;

    public void PressOnButtonAtack()
    {
        if(isCanAttack == true)
        {
            numberOfHit++;

            onAttack?.Invoke("Hit" + numberOfHit.ToString());
            if (numberOfHit >= 3) numberOfHit = 0;
            isCanAttack = false;
        }   
    }

    private void AttackEnd(bool isCan) //������� ����������� isCanAttack, ����� �������� � ������������ ����������
    {
        if(numberOfHit <=1)
        isCanAttack = isCan;
    }

    private void OnEnable()
    {
        PlayerAnimationLogic.onAttackEnd += AttackEnd;
    }

    private void OnDisable()
    {
        PlayerAnimationLogic.onAttackEnd -= AttackEnd;
    }
}
