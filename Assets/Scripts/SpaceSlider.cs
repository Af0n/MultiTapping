using UnityEngine;

public class SpaceSlider : MonoBehaviour
{
    public float MinX;
    public float MaxX;
    public float Rate;
    public bool IsReverse;

    private float _t;

    public float XPos
    {
        get { return MinX + (MaxX - MinX) * _t; }
    }

    public void ToggleReverse() {
        IsReverse = !IsReverse;
    }

    public void Update()
    {
        _t += IsReverse ? -Rate * Time.deltaTime : Rate * Time.deltaTime;
    }
}
