using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class XRManagerCleaner : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        CleanupXR();
    }
    private void CleanupXR()
    {
        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
            Debug.Log("XR Subsystems deinitialized successfully.");
        }
    }
}
