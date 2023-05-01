using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatLogic : MonoBehaviour
{
    public static Action<string> onAttack;

    private bool isCanAtack = true;

    public void Atack()
    {
        if(isCanAtack == true)
        {
            onAttack?.Invoke("Hit1");
            isCanAtack = false;
        }
    }

    public void EndAtack()
    {
        isCanAtack = true;
    }
}
