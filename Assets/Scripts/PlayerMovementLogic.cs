using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementLogic : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;


    public void Move(Vector2 forceStick)
    {
        _rb.velocity = forceStick * _speed;
    } 
}
