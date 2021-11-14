using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{

    private Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
    }


    private void HandleHPPctChanged(float pct)
    {
        slider.value = pct;
    }

}
