using TMPro;
using UnityEngine;

public class PlayerWood : MonoBehaviour
{
    public int wood = 1;


    public TextMeshProUGUI woodText;

    void Start()
    {
        UpdateUI();
    }

    public void AddWood(int amount)
    {
        wood += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        woodText.text = "Wood: " + wood.ToString();
    }

    public bool HasWood(int amount)
    {
        return wood >= amount;
    }

    public void RemoveWood(int amount)
    {
        wood -= amount;
        UpdateUI();
    }
}