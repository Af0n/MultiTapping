using UnityEngine;

public class SpaceSlider : MonoBehaviour
{
    public float MinX;
    public float MaxX;

    [Range(0f, 1)]
    public float Rate;
    public bool IsReverse;

    public float BonusScaling
    {
        get { return Mathf.Pow(2, -Rate); }
    }

    public float BonusMin
    {
        get { return (1 - BonusScaling) / 2; }
    }

    public float BonusMax
    {
        get { return 1 - BonusMin; }
    }

    private Transform _ball;
    private Transform _bonusRegion;
    private float _t = 0.5f;

    public float XPos
    {
        get { return MinX + (MaxX - MinX) * _t; }
    }

    public float BonusAreaScalar
    {
        get { return (MaxX - MinX) * BonusScaling; }
    }

    public bool IsInBonus
    {
        get { return BonusMin <= _t && _t <= BonusMax; }
    }

    public bool IsOut
    {
        get { return _t < 0 || 1 < _t; }
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
        _bonusRegion.localScale = new(BonusAreaScalar, 0.5f, 1);
        // check for bonus
        if (IsInBonus)
        {
            // apply bonus points 
        }
        else
        {
            // apply normal points
        }

        if (IsOut)
        {
            // end game
        }
    }

    public void ToggleReverse()
    {
        IsReverse = !IsReverse;
    }
}
