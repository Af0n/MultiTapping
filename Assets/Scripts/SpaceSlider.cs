using UnityEngine;

public class SpaceSlider : MonoBehaviour
{
    public float BaseRate;
    public float Difficulty;
    public bool IsReverse;
    public float VerticalScale;

    private Transform _ball;
    private Transform _bonusRegion;
    private float _rate;
    private float _t = 0.5f;

    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    public float Rate
    {
        get { return Rate; }
    }

    public float BonusScaling
    {
        get { return Mathf.Pow(2, -_rate); }
    }

    public float BonusMin
    {
        get { return (1 - BonusScaling) / 2; }
    }

    public float BonusMax
    {
        get { return 1 - BonusMin; }
    }

    public float XPos
    {
        get { return _minX + (_maxX - _minX) * _t; }
    }

    public float BonusAreaScalar
    {
        get { return (_maxX - _minX) * BonusScaling; }
    }

    public float VerticalScalar
    {
        get { return (_maxY - _minY) * 0.1f; }
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
        // scale fields
        _minX = CameraBounds.instance.MinX;
        _maxX = CameraBounds.instance.MaxX;
        _minY = CameraBounds.instance.MinY;
        _maxY = CameraBounds.instance.MaxY;

        _ball.localScale = new(VerticalScalar * 0.75f, VerticalScalar * 0.75f, 1);
        // background
        transform.GetChild(2).localScale = new(_maxX - _minX, VerticalScalar, 1);
        _rate = BaseRate;
    }

    public void Update()
    {
        _rate += Difficulty * Time.deltaTime;
        // changing the interpolation value;
        _t += IsReverse ? -_rate * Time.deltaTime : _rate * Time.deltaTime;
        // updating ball position
        _ball.localPosition = new(XPos, 0, 0);
        // update bonus region size
        _bonusRegion.localScale = new(BonusAreaScalar, VerticalScalar, 1);
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
