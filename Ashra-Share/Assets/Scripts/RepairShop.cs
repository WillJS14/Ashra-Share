using UnityEngine;

public class RepairShop : MonoBehaviour
{
    public PlayerWheat playerWheat;
    public PlayerStone playerStone;
    public PlayerWood playerWood;
    public ShopMenu shopMenu;


    public void RepairShopButton()
    {
        Debug.Log("Repair button pressed");
        
        int wheatCost = 20;
        int stoneCost = 17;
        int woodCost = 15;
        bool repairedShopStatus = true;

        if ((playerStone.HasStone(stoneCost)) && (playerWood.HasWood(woodCost)) && (playerWheat.HasWheat(wheatCost)))
        {
            playerWheat.RemoveWheat(wheatCost);
            playerStone.RemoveStone(stoneCost);
            playerWood.RemoveWood(woodCost);
            shopMenu.RepairShop(repairedShopStatus);

            Debug.Log("Repaired the Shop!");
        }
        else
        {
            Debug.Log("Not enough resources!");
        }
    }
}