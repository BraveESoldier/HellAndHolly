using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimation(bool isMoving, string direction)
    {
        string currentAnim;
        if (isMoving == true)
        {
            currentAnim = "Walk" + direction;
            _animator.Play(currentAnim);
        }
        else
        {
            currentAnim = "Idle" + direction;
            _animator.Play(currentAnim);
        }
    }

    public void SetAnimationAttack()
    {

    }

}
