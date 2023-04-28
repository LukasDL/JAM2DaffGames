using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaColba : MonoBehaviour
{
    [SerializeField] private float _manaValue = 50f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerStats>() is PlayerStats player)
        {
            if (player.TryAddMana(_manaValue))
            {
                Destroy(gameObject);
            }
        }
    }
}
