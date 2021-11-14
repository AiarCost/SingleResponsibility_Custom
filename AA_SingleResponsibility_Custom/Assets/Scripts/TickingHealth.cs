using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TickingHealth: MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private int TickPerHealth = 5;
    [SerializeField] private int TickAmount = 8;

    private int currentHealth;


    public event Action<float> OnHPPctChanged = delegate (float f) { };
    public event Action OnDied = delegate { };

    public void Start()
    {
        currentHealth = startingHealth;
    }
    public float CurrentHpPct
    {
        get
        {
            return (float)currentHealth / (float)startingHealth;
        }
    }
 
    public void TakeDamage(int amount)
    {
        Debug.Log("Take Damage Ticking!");
        for(int x = 1; x <= TickAmount; x++)
        {
            Invoke("TickingDamage", ((float)x / 2));
        }

        if (currentHealth <= 0)
        {
            OnDied();
        }
    }

    public void TickingDamage()
    {
        currentHealth -= TickPerHealth;

        OnHPPctChanged(CurrentHpPct);

        if(currentHealth <= 0)
        {
            OnDied();
        }
    }

}
