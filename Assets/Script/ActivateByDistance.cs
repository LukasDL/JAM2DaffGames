using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float _distanceToActivate = 20f;
    private bool _isActive = true;
    private float distance;
    private Activator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.Add(this);
    }
    public void CheckDistance(Vector3 player)
    {
        distance = Mathf.Abs(transform.position.x - player.x);

        if (_isActive)
        {
            DeActivateObjectByDistance();
        }
        else
        {
            ActivateObjectByDistance();
        }
    }

    private void DeActivateObjectByDistance()
    {
        if (distance >= _distanceToActivate + 2f)
        {
            _isActive = false;
            gameObject.SetActive(false);
        }
    }
    private void ActivateObjectByDistance()
    {
        if (distance < _distanceToActivate)
        {
            _isActive = true;
            gameObject.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        _activator.DestroyActivate(this);
    }
}
