using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbodyBird;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 3f;
    [SerializeField] private float _distanceToStartMove = 10f;
    private Transform _playerTransform;
    public bool _canMoveToPlayer;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    private void Update()
    {
        if (_canMoveToPlayer) return;

        if(Vector3.Distance(_playerTransform.position, transform.position) < _distanceToStartMove)
        {
            _canMoveToPlayer = true;
        }
    }
    private void FixedUpdate()
    {
        if (_canMoveToPlayer)
        {
            MoveToPlayer();
        }

    }
    private void MoveToPlayer()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbodyBird.mass * (toPlayer * _speed - _rigidbodyBird.velocity) / _timeToReachSpeed;
        _rigidbodyBird.AddForce(force);
    }
}
