using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodhound : EnemyCharacter
{
    [SerializeField] private float detectRange = 10;

    private string direction = "Left";

    private IDetector _searher;

    private void Awake()
    {
        _searher = new Searcher();
        _searher.SetTarget("Player");
    }

    private void FixedUpdate()
    {
        if (_searher.DetectObject(detectRange,this.transform))
        {
            direction = _searher.DeterminePosition(this.transform);
        }
        
    }


}
