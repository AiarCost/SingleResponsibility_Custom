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
    private bool CharacterDied;


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
        for(int x = 1; x <= TickAmount; x++)
        {
            Invoke("TickingDamage", ((float)x / 2));
        }
    }

    public void TickingDamage()
    {
        if (CharacterDied)
        {

            return;
        }
        else if(currentHealth <= 0)
        {
            OnDied();
            CharacterDied = true;
            return;
        }
        else
        {
            currentHealth -= TickPerHealth;
            OnHPPctChanged(CurrentHpPct);
        }
    }

}
