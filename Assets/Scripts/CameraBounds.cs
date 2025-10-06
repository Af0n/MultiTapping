using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public float MinX
    {
        get
        {
            float aspect = Camera.main.aspect;
            float size = Camera.main.orthographicSize;
            float width = size * aspect;
            return Camera.main.transform.position.x - width;
        }
    }

    public float MaxX
    {
        get
        {
            float aspect = Camera.main.aspect;
            float size = Camera.main.orthographicSize;
            float width = size * aspect;
            return Camera.main.transform.position.x + width;
        }
    }

    public float MinY
    {
        get
        {
            return Camera.main.transform.position.y - Camera.main.orthographicSize;
        }
    }

    public float MaxY
    {
        get
        {
            return Camera.main.transform.position.y + Camera.main.orthographicSize;
        }
    }

    public static CameraBounds instance;

    private void Awake()
    {
        instance = this;
    }

    // private void Start()
    // {
    //     Vector2 minCorner = new(MinX, MinY);
    //     Vector2 maxCorner = new(MaxX, MaxY);

    //     Debug.Log(minCorner);
    //     Debug.Log(maxCorner);
    // }
}
