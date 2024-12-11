using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainSlider : MonoBehaviour
{
    [SerializeField] private Slider fuelSlider;
    [SerializeField] private TrainLocomotion1234 trainLocomotion;
    private float depletionRate = 0.1f;

    void Start()
    {
        if (fuelSlider == null)
            fuelSlider = GetComponent<Slider>();
        fuelSlider.value = 1f;
    }
    void Update()
    {
        if (trainLocomotion != null && trainLocomotion.CanMove() && fuelSlider.value > 0 && trainLocomotion.IsMoving())
        {
            fuelSlider.value -= depletionRate * Time.deltaTime;
        }
        if (fuelSlider.value <= 0f)
        {
            fuelSlider.value = 0f;
            trainLocomotion.Stop();
        }
    }
    public void RefillSlider()
    {
        fuelSlider.value = 1f;
    }
}


