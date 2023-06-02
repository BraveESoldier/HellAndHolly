using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCharacter : CharacterBase
{
    private void Start()
    {

    }

    public override void Die()
    {
        Debug.Log("Im die!");
    }

    public override void Movement()
    {

    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log(Name + " get damage on " + damage + " and has " + Health + "health." );
        if (Health <= 0)
        {
            Die();
        }
    }
    private void Update()
    {

    }
}
