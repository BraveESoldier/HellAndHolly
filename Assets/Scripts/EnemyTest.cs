using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : EnemyCharacter
{
    public override void TakeDamage(int damage)
    {
        Debug.Log("Oh, y hurt me on " + damage + "!");
    }
}
