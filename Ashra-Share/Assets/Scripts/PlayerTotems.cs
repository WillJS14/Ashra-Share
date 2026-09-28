using UnityEngine;
using UnityEngine.UI;

public class PlayerTotems : MonoBehaviour
{
    public bool hasHealthTotem;
    public bool hasShieldTotem;

    private PlayerHealth playerHealth;

    [SerializeField] private GameObject healthTotemIcon;
    [SerializeField] private GameObject shieldTotemIcon;

    //private sound source totemsfx
    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();

        hasHealthTotem = false;
        hasShieldTotem = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryHealthTotem()
    {
        if (hasHealthTotem)
        {
            SetHealthTotemActive(false);
            playerHealth.HealthTotemActivate();
            //Play sound
        }
    }

    public void GetHealthTotem()
    {
        SetHealthTotemActive(true);
        //Play sound
    }

    public void GetShieldTotem()
    {
        SetShieldTotemActive(true);
        //Play sound
    }

    public void SetHealthTotemActive(bool active)
    {
        hasHealthTotem = active;
        healthTotemIcon.SetActive(active);
    }

    public void SetShieldTotemActive(bool active)
    {
        hasShieldTotem = active;
        shieldTotemIcon.SetActive(active);

        playerHealth.SetShieldTotem(active);
    }
}
