using TMPro;
using UnityEngine;

public class PlayerWheat : MonoBehaviour
{
    public int wheat = 1;


    public TextMeshProUGUI wheatText;

    void Start()
    {
        UpdateUI();
    }

    public void AddWheat(int amount)
    {
        wheat += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        wheatText.text = "Wheat: " + wheat.ToString();
    }

    public bool HasWheat(int amount)
    {
        return wheat >= amount;
    }

    public void RemoveWheat(int amount)
    {
        wheat -= amount;
        UpdateUI();
    }
}