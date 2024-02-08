using UnityEngine;
using System;

public class SessionManager : MonoBehaviour
{
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("FirstLoginDate"))
        {
            RecordFirstLogin();
        }
        RecordNewSession();
    }
    public static void RecordFirstLogin()
    {
        string curDate = DateTime.Now.ToString();
        PlayerPrefs.SetString("FirstLoginDate", curDate);
    }
    public static int SecsSinceLogin()
    {
        if (!PlayerPrefs.HasKey("FirstLoginDate"))
        {
            RecordFirstLogin();
        }
        string firstLoginDateStr = PlayerPrefs.GetString("FirstLoginDate");
        DateTime firstLoginDate = DateTime.Parse(firstLoginDateStr);
        double secs = (DateTime.Now - firstLoginDate).TotalSeconds;
        int totalSecs = (int)secs;
        return totalSecs;
    }
    public static int CurrentSession()
    {
        return PlayerPrefs.GetInt("Session");
    }
    static bool SessionRecorded = false;
    public static void RecordNewSession()
    {
        if (SessionRecorded) return;
        SessionRecorded = true;
        PlayerPrefs.SetInt("Session", CurrentSession() + 1);
    }
}
