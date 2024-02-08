using UnityEngine;

public class EnableOnPlatform : MonoBehaviour
{
    [SerializeField] bool AvailableInEditor = true;
    [SerializeField] bool AvailableOnDesktop = true;
    [SerializeField] bool AvailableOnAndroid = true;
    [SerializeField] bool AvailableOnIOS = true;
    Transform trToEnable;
    private void Awake()
    {
        if (transform.childCount == 0) return;
        trToEnable = transform.GetChild(0);
#if UNITY_EDITOR
        SetAvailability(AvailableInEditor);
        return;
#endif
        if (PlatformDetector.IsMobile())
        {
            if (PlatformDetector.IsIOSMobile())
            {
                SetAvailability(AvailableOnIOS);
            }
            else
            {
                SetAvailability(AvailableOnAndroid);
            }
        }
        else
        {
            SetAvailability(AvailableOnDesktop);
        }
    }
    void SetAvailability(bool available)
    {
        if (available)
        {
            trToEnable.gameObject.SetActive(true);
        }
        else
        {
            Destroy(trToEnable.gameObject);
        }
    }
}
