using UnityEngine;

public class AppFocus : MonoBehaviour
{
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //Debug.Log("GVM.focus " + Time.unscaledTime);
            GlobalVolumeManager.UnMuteSoundFocus();
        }
        else
        {
            //Debug.Log("GVM.hid "+Time.unscaledTime);
            GlobalVolumeManager.MuteSoundFocus();
        }
    }
}
