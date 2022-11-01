using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
    /// <summary>
    /// Detects whether an XR device is connected.
    /// If it is, the XR-Controller will be used. If not, a specified (non-XR) Controller may be activated instead.
    /// </summary>

    #region Variables

    public bool startInVR = true;
    public GameObject xrOrigin;
    public GameObject desktopCharacter;

    #endregion

    #region Functions

    void Start()
    {
        if (!startInVR)
        {
            xrOrigin.SetActive(false);
            desktopCharacter.SetActive(true);
        }
        else
        {
            var xrSettings = XRGeneralSettings.Instance;
            if (xrSettings == null)
            {
                Debug.Log($"XRGeneralSettings is null.");
                return;
            }

            var xrManager = xrSettings.Manager;
            if (xrManager == null)
            {
                Debug.Log($"XRManagerSettings is null.");
                return;
            }

            var xrLoader = xrManager.activeLoader;
            if (xrLoader == null)
            {
                Debug.Log($"XRLoader is null.");
                xrOrigin.SetActive(false);
                desktopCharacter.SetActive(true);
                return;
            }

            Debug.Log($"XRLoader is NOT null.");
            desktopCharacter.SetActive(false);
            xrOrigin.SetActive(true);
        }
        
    }

    #endregion
}
