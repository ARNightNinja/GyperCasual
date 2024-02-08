using InstantGamesBridge;
using InstantGamesBridge.Modules.Leaderboard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    
    public static void SetNewHS(int score)
    {
        if(Bridge.leaderboard.isSetScoreSupported)
        {
            var leaderboardName = "Classic";
            var options = new SetScoreYandexOptions(score, leaderboardName);
            Bridge.leaderboard.SetScore(options);
        }
    }
}
