using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnAnyCollision : MonoBehaviour
{
    public GameObject _prefabDie;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_prefabDie, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
