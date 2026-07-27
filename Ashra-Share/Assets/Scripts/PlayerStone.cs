using TMPro;
using UnityEngine;

public class PlayerStone : MonoBehaviour
{
    public int stone = 1;


    public TextMeshProUGUI stoneText;

    void Start()
    {
        UpdateUI();
    }

    public void AddStone(int amount)
    {
        stone += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        stoneText.text = "Stone: " + stone.ToString();
    }

    public bool HasStone(int amount)
    {
        return stone >= amount;
    }

    public void RemoveStone(int amount)
    {
        stone -= amount;
        UpdateUI();
    }
}