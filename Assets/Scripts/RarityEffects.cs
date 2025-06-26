using UnityEngine;

public class RarityEffects : MonoBehaviour
{
    public Renderer treasureRenderer;
    public ParticleSystem fx;
    public TreasureManager.Rarity rarity;

    void Start()
    {
        Color color = Color.white;
        switch (rarity)
        {
            case TreasureManager.Rarity.Common: color = Color.gray; break;
            case TreasureManager.Rarity.Rare: color = Color.blue; break;
            case TreasureManager.Rarity.Epic: color = Color.magenta; break;
            case TreasureManager.Rarity.Legendary: color = Color.yellow; break;
        }

        treasureRenderer.material.color = color;
        var main = fx.main;
        main.startColor = color;
        fx.Play();
    }
}