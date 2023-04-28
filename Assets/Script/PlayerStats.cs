using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float _mana;
    [SerializeField] private ProgressBar _bar;
    public Menu _menu;
    public float levelZatrat = 2f;
    void Start()
    {
        _mana = 100f;
        _bar.ChangeValue(_mana);
    }
    public void DecrementMana(float mana)
    {
        _mana -= mana * levelZatrat;
        _mana = Mathf.Clamp(_mana, 0, 100);
        _bar.ChangeValue(_mana);
    }
   public bool TryAddMana(float mana)
    {
        if(_mana>=100f) return false;
        _mana += mana;
        _bar.ChangeValue(_mana);
        return true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _menu.OpenMenuWindow();
        }
    }
}
