using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Animator))]
public class Player : CharacterBase
{
    [SerializeField] private int _health;
    [SerializeField] private string _name;
    [SerializeField] private Joystick _stick;

    private string direction;
    private bool isCanMoving = true;

    private Animator _animator;
    private PlayerMovementLogic PML;
    private PlayerCombatLogic PCL;


    private void Start()
    {
        Health = _health;
        Name = _name;

        _animator = GetComponent<Animator>();
        PML = GetComponent<PlayerMovementLogic>();
        PCL = GetComponent<PlayerCombatLogic>();
        Debug.Log(Name);
    }

    public override void Die()
    {
        Debug.Log("Player dies");
    }

    public override void Movement()
    {
        Vector2 forceStick = _stick.Direction.normalized;
        if(isCanMoving == true)
        {
            if (forceStick != Vector2.zero)
            {
                IsMoving = true;
                PML.Move(forceStick);

                // Установка направлениz
                SetDirection(forceStick);
                // Установка анимации направления
                SetAnimation();
            }
            else
            {
                PML.Move(Vector2.zero);
                IsMoving = false;
            }
        }
    }

    public override void TakeDamage(int damage)
    {

    }

    public void SetAnimation()
    {
        string currentAnim;
        if (isMoving == true)
        {
            currentAnim = "Walk" + direction;
            _animator.Play(currentAnim);
        }
        else 
        {
            currentAnim = "Walk" + direction; //Change na STAY
            _animator.Play(currentAnim);
        }
    }

    public void SetAnimation(string hitVersion)
    {
        isCanMoving = false;
        string currentAnim = hitVersion + direction;
        _animator.Play(currentAnim);

        StartCoroutine(OnAnimationEnd());
    }

    IEnumerator OnAnimationEnd() //Cour for understanding about end amin
    {
        yield return new WaitForSeconds(0.5f); //Костыль надо вернуть время анимации чтобы корутина была универсальной

        isCanMoving = true;
        SetAnimation();
        PCL.EndAtack();
        //yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
    }

    public void SetDirection(Vector2 force)
    {
        //if (direction == Vector2.zero)
        //{
        //    IsMoving = false;
        //    return;
        //}

        float angle = Mathf.Atan2(force.y, force.x) * Mathf.Rad2Deg;

        if (angle > -45 && angle <= 45)
        {
            direction = "Right";
        }
        else if (angle > 45 && angle <= 135)
        {
            direction = "Up";
        }
        else if (angle > 135 || angle <= -135)
        {
            direction = "Left";
        }
        else
        {
            direction = "Down";
        }
    }


    private void FixedUpdate()
    {
        Movement();
    }

    private void OnEnable()
    {
        PlayerCombatLogic.onAttack += SetAnimation;
    }

    private void OnDisable()
    {
        PlayerCombatLogic.onAttack -= SetAnimation;
    }
}
