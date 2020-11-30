using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour {

    private Image content;

    [SerializeField]
    private TextMeshProUGUI statValue;

    [SerializeField]
    private float lerpSpeed;

    private float currentFill;

    public float MyMaxValue { get; set; }

    private float currentValue;

    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if ( value < 0 ){
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;

            statValue.text = " : " + currentValue + " / " + MyMaxValue;
        }
    }


    void Start()
    {
        MyMaxValue = 10;
        content = GetComponent<Image>(); 
    }

   
    void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }

        content.fillAmount = currentFill;
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
