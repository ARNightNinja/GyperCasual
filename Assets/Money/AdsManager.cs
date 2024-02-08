using InstantGamesBridge;
using InstantGamesBridge.Modules.Advertisement;
using InstantGamesBridge.Modules.Game;
using InstantGamesBridge.Modules.Platform;
using UnityEngine;

public partial class AdsManager : MonoBehaviour
{
#if !UNITY_EDITOR
    const int INT_DEALY = 120;
#else
    const int INT_DEALY = 120;
#endif
    public static AdsManager Instance;
    [SerializeField] AdDelayScreen adDelayScreen;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        /*if (Bridge.player.isAuthorizationSupported)
        {
            if (Bridge.platform.id == InstantGamesBridge.Common.PlatformId.VK)
                Bridge.player.Authorize();
        }*/

        Bridge.platform.SendMessage(PlatformMessage.GameReady);

        Bridge.game.visibilityStateChanged += OnGameVisibilityStateChanged;


        Bridge.advertisement.interstitialStateChanged += OnInterstitialStateChanged;
        Bridge.advertisement.rewardedStateChanged += OnRewardedStateChanged;

        Bridge.advertisement.SetMinimumDelayBetweenInterstitial(INT_DEALY);
    }
    public void ShowBanner()
    {
        if (Bridge.advertisement.isBannerSupported
            && Bridge.platform.id == InstantGamesBridge.Common.PlatformId.VK)
            Bridge.advertisement.ShowBanner();
    }
    public void HideBanner()
    {
        if (Bridge.advertisement.isBannerSupported
            && Bridge.platform.id == InstantGamesBridge.Common.PlatformId.VK)
            Bridge.advertisement.HideBanner();
    }

    private void OnGameVisibilityStateChanged(VisibilityState state)
    {
        switch (state)
        {
            case VisibilityState.Visible:
                VisChangeVis();
                break;
            case VisibilityState.Hidden:
                VisChangeHid();
                break;
        }
    }
    void VisChangeVis()
    {
        GlobalVolumeManager.UnMuteSoundFocus();
    }
    void VisChangeHid()
    {
        GlobalVolumeManager.MuteSoundFocus();
    }

    public float lastPingTime = 0;
    public void PingPopAd()
    {
        if (Time.unscaledTime - lastRVTime < 10)
        {
            Debug.Log("Rewarded ad was just recently");
            return;
        }
        if (Time.unscaledTime - lastPingTime > INT_DEALY)
        {
            if(adDelayScreen!=null)
            {
                Debug.Log("ShowAd with delay");
                //SettingsMenu.Instance.Pause();
                timePingDelay = Time.unscaledTime;
                lastPingTime = Time.unscaledTime;
                adDelayScreen.ShowDelay();
                return;
            }
            ShowInterstitial();
            lastPingTime = Time.unscaledTime;
        }
        else
        {
            Debug.Log("Next ad ping in:" + (INT_DEALY - (int)(Time.unscaledTime - lastPingTime)));
        }
    }
    float lastRVTime = 0;
    
    public void ShowInterstitial()
    {
        Debug.Log("Called ShowInterstitial");
        Bridge.advertisement.ShowInterstitial();
#if UNITY_EDITOR
        UnPauseForAd();
#endif
    }
    public void ShowRewardedAd(RewardType adType)
    {
        lastRVTime = Time.unscaledTime;
        activeRewardType = adType;
        ShowReward();
    }
    void ShowReward()
    {
        Debug.Log("Called ShowRewardedAd");
        Bridge.advertisement.ShowRewarded();
        lastRVTime = Time.unscaledTime;
#if UNITY_EDITOR
        UnPauseForAd();
#endif
    }

    private void OnInterstitialStateChanged(InterstitialState state)
    {
        Debug.Log("OnInterstitialStateChanged" + state);
        switch (state)
        {
            case InterstitialState.Loading:
                break;
            case InterstitialState.Failed:
                lastPingTime = Time.unscaledTime - INT_DEALY/2f;
                UnPauseForAd();
                break;
            case InterstitialState.Opened:
                lastPingTime = Time.unscaledTime;
                PauseForAd();
                break;
            case InterstitialState.Closed:
                UnPauseForAd();
                break;
        }

    }
    private void OnRewardedStateChanged(RewardedState state)
    {
        Debug.Log("OnRewardedStateChanged" + state);
        switch (state)
        {
            case RewardedState.Loading:
                break;
            case RewardedState.Failed:
                UnPauseForAd();
                break;
            case RewardedState.Opened:
                PauseForAd();
                break;
            case RewardedState.Closed:
                UnPauseForAd();
                break;
            case RewardedState.Rewarded:
                RewardUser();
                break;
        }
    }

    private static float timeScaleWas = 1f;
    private static bool isInAd = false;
    protected float timePingDelay = 0f;
    public static bool IsInAd()
    {
        if (Instance == null) return false;

        if (isInAd) return true;
        if (Time.unscaledTime - Instance.timePingDelay < 3f) return true;
        if (AdDelayScreen.IsInCountDown) return true;

        return false;
    }
    public static void PauseForAd()
    {
        if (isInAd) return;
        isInAd = true;
        GlobalVolumeManager.MuteSoundAd();
        timeScaleWas = Time.timeScale;
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
    }
    public static void UnPauseForAd()
    {
        if (!isInAd) return;
        isInAd = false;

        GlobalVolumeManager.UnMuteSoundAd();
        Time.timeScale = timeScaleWas;
        Debug.Log("AdClosed TimeScaleWas:" + timeScaleWas);
    }
   
}