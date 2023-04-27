using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float _speed = 4;
    public float _powerJump = 10;
    public bool _isGround = false;
    private void Update()
    {
        if (_isGround)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                _rigidbody.AddForce(0f, _powerJump, 0f);
            }
        }
    }
    void FixedUpdate()
    {

        Vector3 velocity = new Vector3(_speed, _rigidbody.velocity.y, 0.0f);
        _rigidbody.velocity = velocity;
        _rigidbody.AddForce(Vector3.down * 9.81f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        _isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGround = false;
    }
}
