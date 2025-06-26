using UnityEngine;
using UnityEngine.UI;

public class SortFilterManager : MonoBehaviour
{
    public Dropdown sortDropdown;
    public Dropdown rarityFilterDropdown;

    public void ApplySortFilter()
    {
        string sortType = sortDropdown.options[sortDropdown.value].text;
        string filter = rarityFilterDropdown.options[rarityFilterDropdown.value].text;
        PlayerPrefs.SetString("SortType", sortType);
        PlayerPrefs.SetString("RarityFilter", filter);
        Debug.Log("Applied sort: " + sortType + " | Filter: " + filter);
        // Trigger leaderboard reload here if needed
    }
}