using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float _speed;
    private Vector3 _vector3Velocity;

    void Start()
    {
        _vector3Velocity = transform.forward.normalized * _speed;
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = _vector3Velocity;
    }
}
