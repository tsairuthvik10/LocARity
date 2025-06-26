using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager Instance;
    public string PlayFabId;
    public string DisplayName;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    public void Login(string customId)
    {
        var request = new LoginWithCustomIDRequest { CustomId = customId, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        PlayFabId = result.PlayFabId;
        Debug.Log("PlayFab login successful!");
    }

    void OnLoginError(PlayFabError error)
    {
        Debug.LogError("PlayFab login failed: " + error.GenerateErrorReport());
    }

    public void UpdateDisplayName(string name)
    {
        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = name };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, result => {
            DisplayName = result.DisplayName;
            Debug.Log("Display name updated: " + result.DisplayName);
        }, error => {
            Debug.LogError("Failed to update display name: " + error.GenerateErrorReport());
        });
    }

    public void SubmitScore(int score)
    {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new System.Collections.Generic.List<StatisticUpdate> {
                new StatisticUpdate { StatisticName = "TreasureScore", Value = score }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, result => {
            Debug.Log("Score submitted!");
        }, error => {
            Debug.LogError("Score submit failed: " + error.GenerateErrorReport());
        });
    }
}