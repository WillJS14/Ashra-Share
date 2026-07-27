using UnityEngine;

public class ShopTrades : MonoBehaviour
{
    public PlayerWheat playerWheat;
    public PlayerStone playerStone;
    public PlayerWood playerWood;
    public PlayerCoins playerCoins;
    public PlayerHealth playerHealth;

    public void PurchaseBread()
    {
        int coinCost = 10;
        int breadReward = 7;

        if (playerCoins.HasCoins(coinCost))
        {
            playerCoins.RemoveCoins(coinCost);
            playerHealth.AddBread(breadReward);

            Debug.Log("Purchesed Bread");
        }
        else
        {
            Debug.Log("Not enough coin!");
        }
    }

    public void PurchaseStoneSword()
    {
        Debug.Log("PurchaseStoneSword button pressed");
        
        int coinCost = 18;
        string stoneSwordReward = "Stone";

        if (playerCoins.HasCoins(coinCost))
        {
            playerCoins.RemoveCoins(coinCost);
            playerHealth.AddStoneSword(stoneSwordReward);

            Debug.Log("Crafted a Stone Sword!");
        }
        else
        {
            Debug.Log("Not enough resources!");
        }
    }

    public void PurchaseCoinFromWheat()
    {
        int wheatCost = 10;
        int coinReward = 14;

        if (playerWheat.HasWheat(wheatCost))
        {
            playerWheat.RemoveWheat(wheatCost);
            playerCoins.AddCoins(coinReward);

            Debug.Log("Purchesed Coin from Wheat");
        }
        else
        {
            Debug.Log("Not enough wheat!");
        }
    }

    public void PurchaseCoinFromWood()
    {
        int woodCost = 10;
        int coinReward = 13;

        if (playerWood.HasWood(woodCost))
        {
            playerWood.RemoveWood(woodCost);
            playerCoins.AddCoins(coinReward);

            Debug.Log("Purchesed Coin from Wood");
        }
        else
        {
            Debug.Log("Not enough wood!");
        }
    }

    public void PurchaseCoinFromStone()
    {
        int stoneCost = 10;
        int coinReward = 15;

        if (playerStone.HasStone(stoneCost))
        {
            playerStone.RemoveStone(stoneCost);
            playerCoins.AddCoins(coinReward);

            Debug.Log("Purchesed Coin from Stone");
        }
        else
        {
            Debug.Log("Not enough wood!");
        }
    }
}