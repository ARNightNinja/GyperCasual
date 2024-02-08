using System.Collections;
using UnityEngine;

public class GlobalVolumeManager : MonoBehaviour
{
    //public static GlobalVolumeManager Instance;
    public static bool AdMuted = false;
    public static bool PauseMuted = false;
    public static bool FocusMuted = false;
    public static bool PlayerMuted = false;
    public static bool FakeLoading = false;

    public static bool ReducedVol = false;

    /*private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }*/
    static bool IsMutedAnyType()
    {
        return AdMuted || FocusMuted || PlayerMuted || PauseMuted || FakeLoading;
    }
    public static void SetNewVolume(float newVol)
    {
        if (IsMutedAnyType())
        {
            volumeWasMute = newVol;
            if (ReducedVol)
                volumeReducedWas = newVol;
        }
        else
        {
            if (ReducedVol)
                AudioListener.volume = newVol / 3f;
            else
                AudioListener.volume = newVol;
        }
        Debug.Log("SetNewVol:" + (int)(AudioListener.volume * 100));
    }

    static float volumeWasMute = 0.4f;
    static void SaveMuteVol()
    {
        if (!IsMutedAnyType() && AudioListener.volume > 0)
            volumeWasMute = AudioListener.volume;
        if (volumeWasMute == 1)
            volumeWasMute = 0.4f;
    }
    public static void MuteSoundFakeLoading()
    {
        if (FakeLoading) return;

        SaveMuteVol();

        FakeLoading = true;

        UpdateMuteState();
    }
    public static void UnMuteSoundFakeLoading()
    {
        if (!FakeLoading) return;
        FakeLoading = false;

        UpdateMuteState();
    }
    public static void MuteSoundPlayer()
    {
        if (PlayerMuted) return;

        SaveMuteVol();

        PlayerMuted = true;

        UpdateMuteState();
    }
    public static void UnMuteSoundPlayer()
    {
        if (!PlayerMuted) return;
        PlayerMuted = false;

        UpdateMuteState();
    }
    public static void MuteSoundPause()
    {
        if (PauseMuted) return;

        SaveMuteVol();

        PauseMuted = true;

        UpdateMuteState();
    }
    public static void UnMuteSoundPause()
    {
        if (!PauseMuted) return;
        PauseMuted = false;

        UpdateMuteState();
    }
    public static void MuteSoundAd()
    {
        if (AdMuted) return;

        SaveMuteVol();

        AdMuted = true;

        UpdateMuteState();
    }
    public static void UnMuteSoundAd()
    {
        if (!AdMuted) return;
        AdMuted = false;

        UpdateMuteState();
    }
    public static void MuteSoundFocus()
    {
        if (FocusMuted) return;

        SaveMuteVol();

        FocusMuted = true;

        UpdateMuteState();
    }
    public static void UnMuteSoundFocus()
    {
        if (!FocusMuted) return;
        FocusMuted = false;

        UpdateMuteState();
    }

    static void UpdateMuteState()
    {
        if (IsMutedAnyType())
        {
            AudioListener.volume = 0f;
            AudioListener.pause = true;
            //Debug.Log("UpdateMuteState: AudioListener.volume = 0f");
        }
        else
        {
            //Debug.Log("UpdateMuteState: AudioListener.volume = "+ (int)(volumeWasMute*100));
            AudioListener.volume = volumeWasMute;
            AudioListener.pause = false;
        }
    }




    static float volumeReducedWas = 0.4f;
    public static void ReduceSound()
    {
        if (ReducedVol || IsMutedAnyType()) return;
        ReducedVol = true;
        MuteSoundPause();

        volumeReducedWas = AudioListener.volume;
        AudioListener.volume = volumeReducedWas / 3.25f;
        // Debug.Log((int)(100f*volumeReducedWas / 2.7f)+ " ReduceSound " + Time.unscaledTime);

        //if (FixingSoundCoroutine == null) FixingSoundCoroutine = StartCoroutine(FixSoundFrameDelay());
    }
    public static void UnReduceSound()
    {
        if (!ReducedVol || IsMutedAnyType()) return;
        ReducedVol = false;
        UnMuteSoundPause();

        //Debug.Log((int)(100f * volumeReducedWas) + " UnReduceSound " + Time.unscaledTime);
        AudioListener.volume = volumeReducedWas;
    }
}
