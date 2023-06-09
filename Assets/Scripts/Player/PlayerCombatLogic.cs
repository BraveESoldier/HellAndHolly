using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombatLogic : MonoBehaviour
{
    [SerializeField] private Transform[] _attackPoints;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private Button _button;

    private IButtonClickTracker _buttonClickTracker;

    public static Func<string,string> onAttack;
    public static Action<bool> onAttackEnd;

    private string _currentDirectionAttack;
    private float _attackRange = 1.5f;
    private bool itIsCombo1 = false;
    private bool itIsCombo2 = false;


    private void Awake()
    {
        _buttonClickTracker = new ButtonClickTracker();
    }

    private void Attack(int numberOfHit)
    {
        _currentDirectionAttack = onAttack?.Invoke("Hit" + numberOfHit.ToString());

        //Detect enemy coll
        Collider2D[] hitEnemys = Physics2D.
            OverlapCircleAll(_attackPoints[UnderstandingDirectionAttack(_currentDirectionAttack)].position, _attackRange, _enemyLayers);
        

        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<EnemyCharacter>().TakeDamage(20);
        }
    }

    private void OnDrawGizmosSelected() //Gizm
    {
        Gizmos.DrawWireSphere(_attackPoints[0].position, _attackRange);
        Gizmos.DrawWireSphere(_attackPoints[1].position, _attackRange);
        Gizmos.DrawWireSphere(_attackPoints[2].position, _attackRange);
        Gizmos.DrawWireSphere(_attackPoints[3].position, _attackRange);
    }

    public void PressOnButtonAttack()
    {
        int numberOfClicks = _buttonClickTracker.GetNumberOfClicks();

        if (numberOfClicks == 1)
        {
            Attack(1);
        }
        else if (numberOfClicks == 2)
        {
            itIsCombo1 = true;
        }
        else if (numberOfClicks == 3)
        {
            itIsCombo2 = true;
        }
        _buttonClickTracker.OnButtonClick(0.52f);
    }

    private void AnimationAttackEnd(bool isCan) 
    {
        if (itIsCombo1 == true)
        {
            Attack(2);
            itIsCombo1 = false;
        }
        else if(itIsCombo2 == true)
        {
            _button.enabled = false; //problem with button time enabled s0 need use FindAnimationTime
            Attack(3);
            itIsCombo2 = false;
        }
        else
        {
            Debug.Log(_buttonClickTracker.GetNumberOfClicks());
            onAttackEnd?.Invoke(true);
            _button.enabled = true;
        }
    }

    private int UnderstandingDirectionAttack(string direction)
    {
        if (direction == "Left") return 0;
        else if (direction == "Right") return 1;
        else if (direction == "Up") return 2;
        else if (direction == "Down") return 3;
        else return 0;
    }

    private void OnEnable()
    {
        PlayerAnimationLogic.onAnimationAttackEnd += AnimationAttackEnd;
    }

    private void OnDisable()
    {
        PlayerAnimationLogic.onAnimationAttackEnd -= AnimationAttackEnd;
    }
}
