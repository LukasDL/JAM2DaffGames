using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ProgressBar : MonoBehaviour
{
    private Slider _slider;
    float _value = 1;
    void Start()
    {
        _slider = GetComponent<Slider>();
        ChangeValue(100);
    }
    public void ChangeValue(float value)
    {
        _value = value/100;
        _value = Mathf.Clamp(_value, 0, 1);
        Paint();
    }
    private void Paint()
    {
        if(_slider)
        _slider.value = _value;
    }

}
