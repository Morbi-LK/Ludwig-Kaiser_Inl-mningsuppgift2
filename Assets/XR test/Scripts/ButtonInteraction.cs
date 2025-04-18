using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonInteraction : MonoBehaviour
{
    public enum ButtonType { Forward, Backward, Brake }
    public ButtonType buttonType;
    public TrainLocomotion1234 trainLocomotion;

    [SerializeField] private int direction;
    public Action<int> OnClick;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        OnClick?.Invoke(direction);
        //switch (buttonType)
        //{
        //    case ButtonType.Forward:
        //        trainLocomotion.Forward();
        //        break;

        //    case ButtonType.Backward:
        //        trainLocomotion.Backward();
        //        break;

        //    case ButtonType.Brake:
        //        trainLocomotion.Stop();
        //        break;
        //}
    }
}

