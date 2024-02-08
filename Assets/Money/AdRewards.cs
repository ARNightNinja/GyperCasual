using UnityEngine;

public partial class AdsManager : MonoBehaviour
{
    public enum RewardType
    {
        RewardedMap
    }

    RewardType activeRewardType = RewardType.RewardedMap;

    public void RewardUser()
    {
        Debug.LogError("RewardUser:" + activeRewardType.ToString());
        if (activeRewardType == RewardType.RewardedMap)
        {
           
        }
    }
}
