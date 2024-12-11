using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class VRInitializer : MonoBehaviour
{
    private bool isXRInitialized = false;

    private void Start()
    {
        // Kontrollera om XR redan är initialiserat, annars initiera
        if (!XRGeneralSettings.Instance.Manager.isInitializationComplete)
        {
            EnableXR();  // Försök att starta XR vid starten om det inte är initialiserat
        }
        else
        {
            Debug.Log("XR is already initialized.");
        }
    }

    private void OnDestroy()
    {
        DisableXR();  // Stäng av XR när objektet tas bort
    }

    public void EnableXR()
    {
        // Om XR redan är initialiserat, gör inget
        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            Debug.LogWarning("XR is already initialized or loader is already active.");
            return;
        }

        // Annars kör vi initialiseringen av XR
        StartCoroutine(StartXRCoroutine());
    }

    public void DisableXR()
    {
        // Om XR är initialiserat, stoppa subsystems och deinitialisera loader
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
        // Om det redan finns en aktiv loader, gör inget
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
