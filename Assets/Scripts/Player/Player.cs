using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : CharacterBase
{
    [SerializeField] private int _health;
    [SerializeField] private string _name;

    private string _playerDirection;
    private bool isCanMoving = true;

    //ѕо хорошему надо использовать конструкторы
    private PlayerMovementLogic PML;
    private PlayerCombatLogic PCL;
    private PlayerAnimationLogic PAL;



    private void Start()
    {
        Health = _health;
        Name = _name;

        PML = GetComponent<PlayerMovementLogic>();
        PCL = GetComponent<PlayerCombatLogic>();
        PAL = GetComponent<PlayerAnimationLogic>();
    }

    public override void Die()
    {
        if (Health <= 0)
        {
            
        }
        Debug.Log("Player dies");
    }

    public override void Movement() 
    {
        if(isCanMoving == true)
        {
            PAL.SetAnimation(IsMoving,_playerDirection);
            _playerDirection = PML.direction;
            IsMoving = PML.MovementLogic();
        }
    }

    private string Attack(string numberOfHit)
    {
        isCanMoving = false;
        PAL.SetAnimationAttack(numberOfHit, _playerDirection);
        return _playerDirection;

    }

    public override void TakeDamage(int damage)
    {

    }


    private void FixedUpdate()
    {
        Movement();
    }

    private void AttactEnd(bool isCan)
    {
        isCanMoving = isCan;
    }

    private void OnEnable()
    {
        PlayerCombatLogic.onAttack += Attack;
        PlayerCombatLogic.onAttackEnd += AttactEnd;
    }

    private void OnDisable()
    {
        PlayerCombatLogic.onAttack -= Attack;
        PlayerCombatLogic.onAttackEnd -= AttactEnd;
    }

}
