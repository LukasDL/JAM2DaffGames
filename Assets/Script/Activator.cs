using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private List<ActivateByDistance> _listToActivate = new();
    [SerializeField] private Transform _player;
    private void Update()
    {
        _listToActivate.ForEach(toActivate =>
        {
            toActivate.CheckDistance(_player.position);
        });
    }
    public void Add(ActivateByDistance addActivate)
    {
        _listToActivate.Add(addActivate);
    }
    public void DestroyActivate(ActivateByDistance destroyActivator)
    {
        _listToActivate.Remove(destroyActivator);
    }
}
