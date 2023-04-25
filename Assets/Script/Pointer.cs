using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Ray _ray;
    private Plane _plane;
    void Start()
    {
        _plane = new Plane(-Vector3.forward, Vector3.zero);
    }
    void LateUpdate()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hit;
        _plane.Raycast(_ray, out hit);
        transform.position = _ray.GetPoint(hit);
    }
}
