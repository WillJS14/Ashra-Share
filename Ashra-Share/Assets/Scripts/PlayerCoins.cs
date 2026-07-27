using TMPro;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public int coins = 1;


    public TextMeshProUGUI coinText;

    void Start()
    {
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "Coins: " + coins.ToString();
    }

    public bool HasCoins(int amount)
    {
        return coins >= amount;
    }

    public void RemoveCoins(int amount)
    {
        coins -= amount;
        UpdateUI();
    }
}