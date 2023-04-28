using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer1 : MonoBehaviour
{
    [SerializeField] private DrawLine playerLineStatus;
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
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<DrawLine>())
        {
            playerLineStatus.LineStatus = LineStatus.Created;
        }
    }
}
