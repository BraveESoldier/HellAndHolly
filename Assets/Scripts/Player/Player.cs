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
        Debug.Log("Player dies");
    }

    public override void Movement() 
    {
        if(isCanMoving == true && PCL.numberOfHit <= 1)
        {
            PAL.SetAnimation(isMoving,_playerDirection);
            _playerDirection = PML.direction;
            isMoving = PML.MovementLogic();
        }
        //else if(isCanMoving == false) 
    }

    private void Attack(string numberOfHit)
    {
        isCanMoving = false;
        PAL.SetAnimationAttack(numberOfHit, _playerDirection);
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
        PlayerAnimationLogic.onAttackEnd += AttactEnd;
    }

    private void OnDisable()
    {
        PlayerCombatLogic.onAttack -= Attack;
        PlayerAnimationLogic.onAttackEnd -= AttactEnd;
    }

}
