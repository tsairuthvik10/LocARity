using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public enum Rarity { Common, Rare, Epic, Legendary }
    public Rarity rarity;
    public int pointValue;

    public void AssignRandomRarity()
    {
        float roll = Random.value;
        if (roll < 0.6f) { rarity = Rarity.Common; pointValue = 10; }
        else if (roll < 0.85f) { rarity = Rarity.Rare; pointValue = 25; }
        else if (roll < 0.95f) { rarity = Rarity.Epic; pointValue = 50; }
        else { rarity = Rarity.Legendary; pointValue = 100; }
    }

    public void ClaimTreasure()
    {
        PlayFabManager.Instance.SubmitScore(pointValue);
        Destroy(gameObject);
    }
}