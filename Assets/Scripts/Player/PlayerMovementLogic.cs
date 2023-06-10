using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementLogic : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Joystick _stick;

    [HideInInspector]
    public string direction = "Left";

    public void SetDirection(Vector2 force)
    {

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

    public bool MovementLogic()
    {
        Vector2 forceStick = _stick.Direction.normalized;
        if (forceStick != Vector2.zero)
        {
            SetDirection(forceStick);
            Move(forceStick);
            return true;
        }
        else
        {
            Move(Vector2.zero);
            return false;
        }
    }

    public void Move(Vector2 forceStick)
    {
        _rb.velocity = forceStick * _speed;
    } 
}
