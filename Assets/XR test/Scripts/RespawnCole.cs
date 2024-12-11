using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RespawnCole : MonoBehaviour, Respawnable
{
    public Action OnConsume;
    [SerializeField] private GameObject Cole;
    [SerializeField] private Transform trainTransform;
    private Vector3 initialOffset;

    void Start()
    {
        if (trainTransform != null)
        {
            initialOffset = Cole.transform.position - trainTransform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Furnace"))
        {
            Cole.SetActive(false);
            Cole.transform.position = trainTransform.position + initialOffset;
            Cole.transform.SetParent(trainTransform);
            Cole.SetActive(true);
            OnConsume?.Invoke();
        }
    }
    public void OnRespawn()
    {
        if (trainTransform != null)
        {
            Cole.transform.position = trainTransform.position + initialOffset;
            Cole.transform.SetParent(trainTransform);
        }
    }
}