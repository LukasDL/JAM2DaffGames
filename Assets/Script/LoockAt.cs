using UnityEngine;

public class LoockAt : MonoBehaviour
{
    [SerializeField] Transform _target;

    void Update()
    {
        transform.LookAt(_target.position);
    }
}
