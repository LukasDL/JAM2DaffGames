using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleItem : MonoBehaviour
{
    ToggleCreator _toggleCreator;
    public int _x;
    public int _y;
    public TextMeshProUGUI text;
    public Toggle toggle;

    private void Start()
    {
        _toggleCreator = FindObjectOfType<ToggleCreator>();
    }
    public void SetVector(int x, int y)
    {  
        _x = x;
        _y = y;
        text.text = _x.ToString() + _y.ToString();
    }
    public void OnToggleMouse()
    {
        if (Input.GetMouseButton(0))
        {
            _toggleCreator.ChangePatch(_x, _y);
            toggle.isOn = true;
        }
    }
}
