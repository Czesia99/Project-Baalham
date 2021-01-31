using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public float Value;
    public float MinValue;
    public float MaxValue;
    public float rate; 

    private Light lightComponent;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Value < MaxValue)
                Value += rate * Time.deltaTime; // Cap at some max value too
        }
        else if (Value > MinValue)
        {
            Value -= (rate / 5) * Time.deltaTime; // Cap at some min value too
        }
        lightComponent.intensity = Value;
    }
}
