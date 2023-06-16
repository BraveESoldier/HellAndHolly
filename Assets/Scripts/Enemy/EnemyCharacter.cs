using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCharacter : CharacterBase
{
    private protected float detectRange = 1;
    private protected float attackRange = 1;

    private EnemyAnimation EA;
    private EnemyCombat EC;
    private EnemyMovement EM;

    private string _direction = "Left";
    private Vector3 startPos; 

    private IDetector _searher;

    protected void Awake()
    {
        _searher = new Searcher();
        _searher.SetTarget("Player");
        EA = GetComponent<EnemyAnimation>();
        EC = GetComponent<EnemyCombat>();
        EM = GetComponent<EnemyMovement>();
        startPos = this.transform.position; //убрать зависимость при подключении Zenject
    }


    protected void FixedUpdate()
    {
        if (_searher.DetectObject(detectRange, this.transform))
        {
            _direction = _searher.DeterminePosition(this.transform);
            if (_searher.DetectObject(attackRange, this.transform))
            {
                Attack();//add an attack check and attack time so that animations are not torn
            }
            else
            {
                Movement();
            }
        }

    }

    private void IdleAnimation()
    {
        EA.SetAnimation(false, _direction);
    }


    public override void Movement()
    {
        Vector3 target = _searher.ReturnTargetPosition();
        EM.MoveTowards(target);
        EA.SetAnimation(true, _direction);
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log(Name + " get damage on " + damage + " and has " + Health + " health." );
        if (Health <= 0)
        {
            Die();
        }
    }
    private void Attack()
    {
        EM.Stop();
        EA.SetAnimation(_direction);
    }

    public override void Die()
    {
        EA.SetAnimationDie();
        this.gameObject.SetActive(false);
    }
}
