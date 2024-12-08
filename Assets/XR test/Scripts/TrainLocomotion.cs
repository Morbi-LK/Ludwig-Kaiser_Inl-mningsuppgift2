using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainLocomotion : MonoBehaviour
{
    [Header("Test values")]
    [SerializeField] private bool TestValues = false;
    [SerializeField] private bool Forwards = false;
    [SerializeField] private bool Backwards = false;
    [SerializeField] private bool addCole = false;
    [Header("End of test")]

    [SerializeField] private RespawnCole Cole; 

    [SerializeField] private float speed = 5f;
    [Header("Cole Values")]
    [SerializeField] private Slider ColeAmount;
    private float ColeValue = 1f;
    private bool Consume = false;
    private int direction = 0;
    private float Timer;

    public void Forward()
    {
        direction = 1;
    }
    public void Backward()
    {
        direction = -1;
    }
    public void Stop()
    {
        direction = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        ColeValue = 1f;
        ColeAmount.value = ColeValue;
        direction = 0;

        Cole.OnConsume += ColeConsumed;

    }

    private async void ColeConsumed()
    {
        Consume = true;
        Timer = 2f;
        ColeValue += 0.5f;
        ColeValue = Mathf.Clamp(ColeValue, 0f, 1f);
        ColeAmount.value = ColeValue;

    }

    // Update is called once per frame
    void Update()
    {
        if (TestValues)
        {
            if (Forwards)
                direction = 1;
            else if (Backwards)
                direction = -1;
            else
                direction = 0;
        }

        if (addCole)
        {
            ColeValue += 1f;
            ColeValue = Mathf.Clamp(ColeValue, 0f, 1f); 
            addCole = false;   
        }

        if (direction != 0 && ColeValue > 0)
        {
            ColeValue -= 0.1f * Time.deltaTime;
            ColeAmount.value = ColeValue;
            transform.position += Vector3.forward * direction * speed * Time.deltaTime;
        }
        if (Consume)
        {
            if (Timer > 0f)
            {
                Timer -= Time.deltaTime;
                return;
            }
            Consume = false;
            Cole.gameObject.SetActive(true);
        }
    }
}
