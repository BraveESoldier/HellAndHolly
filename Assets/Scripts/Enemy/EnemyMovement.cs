using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveTowards(Vector3 targetPosition)
    {
        Vector2 moveDirection = (targetPosition - transform.position).normalized;
        _rb.velocity = moveDirection * _speed;
    }
}
