using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, ICharacter, ICombatant, IMoving
{
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public bool IsDead 
    {
        get { return isDead; }
        set { isDead = value; }
    }
    public string Name 
    {
        get { return name; }
        set { name = value; }
    }
    public float Speed 
    {
        get { return speed; }
        set { speed = value; }
    }
    public bool IsMoving 
    {
        get { return isMoving; }
        set { isMoving = value; }
    }

    protected int health;
    protected float speed;
    protected bool isMoving;
    protected bool isDead;
    protected string name;

    public abstract void TakeDamage(int damage);
    public abstract void Movement();
    public abstract void Die();
}

public interface ICombatant
{
    int Health { get; }
    bool IsDead { get; }
    void TakeDamage(int damage);
}

public interface ICharacter
{
    string Name { get; }
    void Die();

}

public interface IMoving
{
    float Speed { get; }
    bool IsMoving { get; }
    void Movement();

}
