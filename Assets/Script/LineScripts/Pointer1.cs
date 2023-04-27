using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer1 : MonoBehaviour
{
    [SerializeField] private DrawLine playerLineStatus;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<DrawLine>())
        {
            playerLineStatus.LineStatus = LineStatus.Created;

        }



    }
}
