using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

[System.Serializable]
public class PlayerEntry
{
    public int rank;
    public string displayName;
    public int score;
    public string topRarity;
    public string playerId;
}

public class LeaderboardUIManager : MonoBehaviour
{
    public GameObject leaderboardEntryPrefab;
    public Transform leaderboardContainer;

    public GameObject entryPrefab;
    public Transform contentContainer;
    public Color highlightColor;
    private string currentPlayerId; // Cache this once on login

    public void LoadLeaderboard(List<PlayerEntry> data)
    {
        foreach (Transform child in contentContainer)
            Destroy(child.gameObject);

        foreach (var player in data)
        {
            GameObject entry = Instantiate(entryPrefab, contentContainer);

            entry.transform.Find("RankText").GetComponent<Text>().text = player.rank.ToString();
            entry.transform.Find("NameText").GetComponent<Text>().text = player.displayName;
            entry.transform.Find("ScoreText").GetComponent<Text>().text = player.score.ToString();
            entry.transform.Find("RarityText").GetComponent<Text>().text = player.topRarity;

            // 🎯 Highlight if this is the current player
            if (player.playerId == currentPlayerId)
            {
                Image bg = entry.GetComponent<Image>(); // Or entry.transform.Find("Background").GetComponent<Image>();
                if (bg != null)
                    bg.color = highlightColor;
            }
        }
    }


    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (Transform child in leaderboardContainer)
            Destroy(child.gameObject);

        foreach (var entry in result.Leaderboard)
        {
            GameObject go = Instantiate(leaderboardEntryPrefab, leaderboardContainer);
            go.GetComponentInChildren<Text>().text = $"{entry.Position + 1}. {entry.DisplayName ?? "Player"}: {entry.StatValue}";
        }
    }
}