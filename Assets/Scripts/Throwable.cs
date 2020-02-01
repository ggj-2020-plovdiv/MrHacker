using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public Texture2D targetCursor;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SelectedThrowable(string name)
    {
        Cursor.SetCursor(targetCursor, Vector2.zero, CursorMode.Auto);
    }
}
