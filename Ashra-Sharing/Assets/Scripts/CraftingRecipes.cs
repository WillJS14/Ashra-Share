using UnityEngine;

public class CraftingRecipes : MonoBehaviour
{
    public PlayerWheat playerWheat;
    public PlayerStone playerStone;
    public PlayerWood playerWood;
    public PlayerHealth playerHealth;

    public void CraftBread()
    {
        int wheatCost = 10;
        int breadReward = 4;

        if (playerWheat.HasWheat(wheatCost))
        {
            playerWheat.RemoveWheat(wheatCost);
            playerHealth.AddBread(breadReward);

            Debug.Log("Crafted Bread!");
        }
        else
        {
            Debug.Log("Not enough wheat!");
        }
    }

    public void CraftStoneSword()
    {
        Debug.Log("CraftStoneSword button pressed");
        
        int stoneCost = 25;
        int woodCost = 5;
        string stoneSwordReward = "Stone";

        if ((playerStone.HasStone(stoneCost)) && (playerWood.HasWood(woodCost)))
        {
            playerStone.RemoveStone(stoneCost);
            playerWood.RemoveWood(woodCost);
            playerHealth.AddStoneSword(stoneSwordReward);

            Debug.Log("Crafted a Stone Sword!");
        }
        else
        {
            Debug.Log("Not enough resources!");
        }
    }
}