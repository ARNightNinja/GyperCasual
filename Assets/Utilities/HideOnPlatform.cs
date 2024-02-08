using UnityEngine;

public class HideOnPlatform : MonoBehaviour
{
    [SerializeField] bool AvailableInEditor = true;
    [SerializeField] bool AvailableOnDesktop = true;
    [SerializeField] bool AvailableOnAndroid = true;
    [SerializeField] bool AvailableOnIOS = true;

    [Space(10),SerializeField] bool HideWithScale = false;

    private void Awake()
    {
#if UNITY_EDITOR
        if(!AvailableInEditor)
        {
            Hide();
            return;
        }
#endif
        if(!PlatformDetector.IsMobile())
        {
            if(!AvailableOnDesktop)
            {
                Hide();
            }
        } else
        {
            if (PlatformDetector.IsIOSMobile())
            {
                if (!AvailableOnIOS)
                    Hide();
            }
            else
            {
                if (!AvailableOnAndroid)
                    Hide();
            }
        }
    }
    void Hide()
    {
        if(HideWithScale)
        {
            transform.localScale = Vector3.zero;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
