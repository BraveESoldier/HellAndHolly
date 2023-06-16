using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodhound : EnemyCharacter
{
    [SerializeField] private float _attackRange = 2;
    [SerializeField] private float _detectRange = 10;
    [SerializeField] private int _health = 160;

    private void Start()
    {
        SetSetting();
    }

    private void SetSetting()
    {
        attackRange = _attackRange;
        detectRange = _detectRange;
        Health = _health;
    }

}
