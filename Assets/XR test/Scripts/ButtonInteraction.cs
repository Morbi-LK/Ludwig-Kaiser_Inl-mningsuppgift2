using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonInteraction : MonoBehaviour
{
    public enum ButtonType { Forward, Backward, Brake }
    public ButtonType buttonType;
    public TrainLocomotion1234 trainLocomotion;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        switch (buttonType)
        {
            case ButtonType.Forward:
                trainLocomotion.Forward();
                break;

            case ButtonType.Backward:
                trainLocomotion.Backward();
                break;

            case ButtonType.Brake:
                trainLocomotion.Stop();
                break;
        }
    }
}

