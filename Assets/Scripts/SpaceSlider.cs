using UnityEngine;

public class SpaceSlider : MonoBehaviour
{
    public float MinX;
    public float MaxX;

    public float Rate;
    public bool IsReverse;

    public float BonusSize = 0.9f;

    private Transform _ball;
    private Transform _bonusRegion;
    private float _t = 0.5f;

    public float XPos
    {
        get { return MinX + (MaxX - MinX) * _t; }
    }

    public float BonusScalar
    {
        get { return (MaxX - MinX) * BonusSize; }
    }

    private void Awake()
    {
        _ball = transform.GetChild(0);
        _bonusRegion = transform.GetChild(1);
    }

    void Start()
    {
        MinX = CameraBounds.instance.MinX;
        MaxX = CameraBounds.instance.MaxX;
        transform.GetChild(2).localScale = new(MaxX - MinX, 0.5f, 1);
    }

    public void Update()
    {
        // changing the interpolation value;
        _t += IsReverse ? -Rate * Time.deltaTime : Rate * Time.deltaTime;
        // updating ball position
        _ball.localPosition = new(XPos, 0, 0);
        // update bonus region size
        _bonusRegion.localScale = new(BonusScalar, 0.5f, 1);
    }

    public void ToggleReverse()
    {
        IsReverse = !IsReverse;
    }
}
