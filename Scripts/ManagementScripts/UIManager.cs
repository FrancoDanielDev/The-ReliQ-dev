using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Bortoló
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image[] health;
    public Image dash;

    [SerializeField] private Player _player;

    [SerializeField] private Sprite _hp, _noHp, _dash, _noDash;


    private void Awake()
    {
        instance = this;
    }

    public void HealthUpdate(int currentHP)
    {
        for (int i = 0; i < health.Length; i++)
        {
            if (i < currentHP)
            {
                health[i].sprite = _hp;
            }
            else
            {
                health[i].sprite = _noHp;
            }
        }
    }

    public void DashUpdate(bool canDash)
    {
        if (!canDash)
        {
            dash.sprite = _noDash;
        }
        else
        {
            dash.sprite = _dash;
        }
    }
}
