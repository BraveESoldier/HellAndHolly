using UnityEngine;

public class ButtonClickTracker : IButtonClickTracker
{
    private int _numberOfClicks = 1;
    private float _lastClickTime;

    public void OnButtonClick(float animTime)
    {
        float currentTime = Time.time;

        if (currentTime - _lastClickTime <= animTime)
        {
            _numberOfClicks++;
        }
        else
        {
            _numberOfClicks = 1;
        }
        _lastClickTime = currentTime;
    }

    public int GetNumberOfClicks()
    {
        return _numberOfClicks;
    }
}

public interface IButtonClickTracker
{
    void OnButtonClick(float time);
    int GetNumberOfClicks();
}
