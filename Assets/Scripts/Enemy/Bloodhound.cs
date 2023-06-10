using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodhound : EnemyCharacter
{
    [SerializeField] private float detectRange = 10;

    private EnemyAnimation EA;
    private EnemyCombat EC;
    private EnemyMovement EM;

    private string _direction = "Left";
    private Vector3 _startPos;

    private IDetector _searher;

    private void Awake()
    {
        _searher = new Searcher();
        _searher.SetTarget("Player");
        EA = GetComponent<EnemyAnimation>();
        EC = GetComponent<EnemyCombat>();
        EM = GetComponent<EnemyMovement>(); 
        _startPos = this.transform.position; //убрать зависимость при подключении Zenject
    }
    


    private void FixedUpdate()
    {
        if (_searher.DetectObject(detectRange,this.transform))
        {
            _direction = _searher.DeterminePosition(this.transform);
            Movement();

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


}
