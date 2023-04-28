using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Drawing : MonoBehaviour
{
    public bool isDrawing = false;

    public void Update()
    {
        OnDrag();
    }
    public void OnDrag()
    {
        if (isDrawing)
        {
            
        }
    }

    public void OnPointerDown()
    {
        isDrawing = true;
    }

    public void OnPointerUp()
    {
        isDrawing = false;
    }

}
