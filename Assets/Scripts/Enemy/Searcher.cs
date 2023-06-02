using UnityEngine;

public interface IDetector
{
    void SetTarget(string tag);
    bool DetectObject(float detectionRange, Transform seeker);
    string DeterminePosition(Transform seeker);
}

public class Searcher: MonoBehaviour, IDetector
{
    private GameObject target;

    public void SetTarget(string tag)
    {
        target = GameObject.FindGameObjectWithTag(tag);
    }

    public bool DetectObject(float detectionRange, Transform seeker)
    {
        float distanceToTarget = Vector3.Distance(seeker.position, target.transform.position);
        return distanceToTarget <= detectionRange;
    }

    public string DeterminePosition(Transform seeker)
    {
        Vector3 direction = target.transform.position - seeker.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle >= -45f && angle <= 45f)
        {
            return "Right";
        }
        else if (angle > 45f && angle <= 135f)
        {
            return "Up";
        }
        else if (angle > 135f || angle <= -135f)
        {
            return "Left";
        }
        else
        {
            return "Down";
        }
    }
}
