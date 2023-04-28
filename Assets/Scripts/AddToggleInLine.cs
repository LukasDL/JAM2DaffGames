using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToggleInLine : MonoBehaviour
{
    public void AddToggle(GameObject _toggle) {   
        _toggle.transform.SetParent(transform, false);
    }
}
