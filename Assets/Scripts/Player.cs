using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
public class Player : CharacterBase
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private string _name;
    [SerializeField] private Joystick _stick;

    private Animator _animator;
    private Rigidbody2D _rb;

    //public Player()
    //{
    //    Health = _health;
    //    Speed = _speed;
    //    Name = _name;
    //}

    private void Start()
    {
        Health = _health;
        Speed = _speed;
        Name = _name;

        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        Debug.Log(Name);
    }

    public override void Die()
    {
        Debug.Log("Player dies");
    }

    public override void Movement()
    {
        Vector2 forceStick = _stick.Direction.normalized;
        if (forceStick != Vector2.zero)
        {
            _rb.velocity = forceStick * Speed;

            // Установка направление анимации
            SetAnimationDirection(forceStick);
        }
        else
        {
            _rb.velocity = Vector2.zero;
            IsMoving = false;
        }
    }

    public override void TakeDamage(int damage)
    {

    }
    public void SetAnimationDirection(Vector2 direction)
    {
        //if (direction == Vector2.zero)
        //{
        //    IsMoving = false;
        //    return;
        //}

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle > -45 && angle <= 45)
        {
            IsMoving = true;
            _animator.Play("WalkRight");
        }
        else if (angle > 45 && angle <= 135)
        {
            IsMoving = true;
            _animator.Play("WalkUp");
        }
        else if (angle > 135 || angle <= -135)
        {
            IsMoving = true;
            _animator.Play("WalkLeft");
        }
        else
        {
            IsMoving = true;
            _animator.Play("WalkDown");
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }
}
