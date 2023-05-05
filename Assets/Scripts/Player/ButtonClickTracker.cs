using UnityEngine;

public class ButtonClickTracker : IButtonClickTracker
{
    private int _numberOfClicks;
    private float _lastClickTime;

    public void OnButtonClick()
    {
        float currentTime = Time.time;

        if (currentTime - _lastClickTime <= 0.5f)
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
    void OnButtonClick();
    int GetNumberOfClicks();
}
