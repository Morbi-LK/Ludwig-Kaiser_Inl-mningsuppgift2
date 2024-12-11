using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class VRInitializer : MonoBehaviour
{
    private bool isXRInitialized = false;

    private void Start()
    {
        // Kontrollera om XR redan �r initialiserat, annars initiera
        if (!XRGeneralSettings.Instance.Manager.isInitializationComplete)
        {
            EnableXR();  // F�rs�k att starta XR vid starten om det inte �r initialiserat
        }
        else
        {
            Debug.Log("XR is already initialized.");
        }
    }

    private void OnDestroy()
    {
        DisableXR();  // St�ng av XR n�r objektet tas bort
    }

    public void EnableXR()
    {
        // Om XR redan �r initialiserat, g�r inget
        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            Debug.LogWarning("XR is already initialized or loader is already active.");
            return;
        }

        // Annars k�r vi initialiseringen av XR
        StartCoroutine(StartXRCoroutine());
    }

    public void DisableXR()
    {
        // Om XR �r initialiserat, stoppa subsystems och deinitialisera loader
        if (XRGeneralSettings.Instance.Manager.isInitializationComplete)
        {
            Debug.Log("Stopping XR...");
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
            isXRInitialized = false;  // Markera som inte initialiserad
            Debug.Log("XR stopped completely.");
        }
        else
        {
            Debug.Log("XR was not initialized, no need to deinitialize.");
        }
    }

    public IEnumerator StartXRCoroutine()
    {
        // Om det redan finns en aktiv loader, g�r inget
        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            Debug.LogWarning("XR Loader is already initialized.");
            yield break;  // Om det redan finns en laddare, stoppa och avbryt
        }

        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        }
        else
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            isXRInitialized = true; // Markera som initialiserat
        }
    }
}
