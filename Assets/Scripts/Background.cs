using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ = 1;
    float _t = 0;
    private Vector3 startPosition;
    bool slowingDown = false;
    void Start()
    {
        startPosition = transform.position;
    }

    public void SlowDown()
    {
        slowingDown = true;
    }

    void Update()
    {
        if (scrollSpeed > 0)
        {
            if (slowingDown)
                scrollSpeed -= 0.0007f;
            float newPosition = Mathf.Repeat(_t, 29f);
            _t += scrollSpeed;
            transform.position = startPosition + Vector3.down * newPosition;
        }
    }
}
