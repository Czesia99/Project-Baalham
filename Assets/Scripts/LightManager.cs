using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
    public float Value;
    public float MinValue;
    public float MaxValue;
    public float Qty;
    public float rate;
    public Light LightComponent;
    public Image LightBar;

    private float initValue;
    // Start is called before the first frame update
    void Start()
    {
        initValue = Value;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && Qty > 0)
        {
            if (Value < MaxValue)
                Value += rate * Time.deltaTime; // Cap at some max value too
            Qty -= (rate / 5) * Time.deltaTime;
        }
        else if (Value > MinValue)
        {
            Value -= (rate / 5) * Time.deltaTime; // Cap at some min value too
        }
        LightComponent.intensity = Value;
        LightBar.fillAmount = Qty / 10;
    }
    public void IncreaseLightQty(float value)
    {
        if (Qty + value > MaxValue)
            Qty = MaxValue - 1;
        else if (Qty + value < MaxValue)
            Qty += value;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Value >= initValue)
                other.gameObject.SetActive(false);
        }
    }
}
