using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StandardHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;

    private int currentHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    public float CurrentHpPct
    {
        get { return (float)currentHealth / (float)startingHealth; }

    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Invalid damage amount specified: " + amount);

        currentHealth -= amount;

        OnHPPctChanged(CurrentHpPct);

        if(CurrentHpPct<= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDied();
        Destroy(gameObject);
    }
}
