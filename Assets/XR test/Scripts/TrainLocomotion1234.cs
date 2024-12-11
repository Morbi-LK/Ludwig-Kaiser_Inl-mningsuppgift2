using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TrainLocomotion1234 : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Slider ColeAmount;
    private float ColeValue = 1f;
    private int direction = 0;

    [SerializeField] private RespawnCole Cole;

    private bool Consume = false;
    private float Timer = 0f;

    public bool CanMove()
    {
        return ColeAmount.value > 0 && direction != 0;
    }
    public bool IsMoving()
    {
        return direction != 0;
    }
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
    void Start()
    {
        ColeAmount.value = ColeValue;
        Cole.OnConsume += ColeConsumed;
    }
    private void ColeConsumed()
    {
        Consume = true;
        Timer = 2f;
        ColeValue = Mathf.Clamp(ColeValue + 0.5f, 0f, 1f);
        ColeAmount.value = ColeValue;
    }
    void Update()
    {
        if (IsMoving() && ColeValue > 0)
        {
            ColeValue -= 0.1f * Time.deltaTime;
            ColeAmount.value = ColeValue;
            transform.position += Vector3.forward * direction * speed * Time.deltaTime;
        }
        if (Cole != null && Cole.gameObject.transform.parent != transform)
        {
            Cole.gameObject.transform.position = transform.position;
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



