using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NumberofHitsHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int healthInHits = 5;

    [SerializeField]
    private float invulernabilityTimeAfterEachHit = 5f;

    private int hitsRemaining;
    private bool canTakeDamage = true;

    public event Action<float> OnHPPctChanged = delegate (float f) { };
    public event Action OnDied = delegate { };

    public float CurrentHpPct
    {
        get
        {
            return (float)hitsRemaining / (float)healthInHits;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hitsRemaining = healthInHits;
    }


    public void TakeDamage(int amount)
    {
        if (canTakeDamage)
        {
            StartCoroutine(InvulerabilityTimer());

            hitsRemaining--;

            OnHPPctChanged(CurrentHpPct);

            if (hitsRemaining <= 0)
                OnDied();
        }
    }

    private IEnumerator InvulerabilityTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invulernabilityTimeAfterEachHit);
        canTakeDamage = true;
    }
}
