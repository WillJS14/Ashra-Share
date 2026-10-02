using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //public int startHealth = 100;
    //public int maxHealth = 200;
    //public int currentHealth;
    public TextMeshProUGUI healthText;
    public int maxNatRegenHealth = 120;
    public float natRegenTime = 5f;
    public float natRegenCooldown = 15f;

    public Health health;

    public int startingBread = 50;
    public int currentBread;
    public TextMeshProUGUI breadText;
    public float eatingCooldown = 0.5f;

    public GameObject deathScreen;

    public TextMeshProUGUI swordCheckText;
    public TextMeshProUGUI banditRemainingText;
    public string swordType = "Wood";
    private string currentSword;
    private int banditRemaining;

    private float nextEatTime = 0f;
    private float nextNatRegenTime = 5f;

    private Transform player;
    private PlayerSwordAttack playerSwordAttack;


    void Start()
    {
        deathScreen.SetActive(false);
        playerSwordAttack = GetComponent<PlayerSwordAttack>();

        currentBread = startingBread;
        currentSword = "Wood";
        UpdateUI();
    }

    void Update()
    {
        if (Time.time >= nextNatRegenTime)
        {
            RegenHealth();
        }
        if ((Keyboard.current.eKey.isPressed) && (currentBread > 0) && (health.currentHealth <= health.maxHealth) && (Time.time >= nextEatTime))
        {
            nextEatTime =
                Time.time + eatingCooldown;
            EatBread();
        }
    }

    public bool HasStoneSword(string type)
    {
        return currentSword == type;
    }


    void RegenHealth()
    {
        if (health.currentHealth < maxNatRegenHealth) 
        {
            health.currentHealth += 1;
        }
        UpdateUI();

        nextNatRegenTime = Time.time + natRegenTime;

    }

    public void EatBread()
    {
        health.currentHealth = health.currentHealth + 2;
        currentBread = currentBread - 1;
        UpdateUI();
    }

    public void AddBread(int amount)
    {
        currentBread += amount;
        UpdateUI();
    }

    public void AddStoneSword(string type)
    {
        currentSword = type;
        UpdateUI();
    }

    public void TakeDamage()
    {
        if (playerSwordAttack != null && playerSwordAttack.IsBlocking)
        {
            Debug.Log(gameObject.name + " blocked damage!");
            return;
        }

        nextNatRegenTime = Time.time + natRegenCooldown;

        UpdateUI();

        Debug.Log(gameObject.name + " took damage!");
    }

    public void HealthTotemActivate()
    {
        health.currentHealth = 100;
    }

    public void SetShieldTotem(bool active)
    {
        if (active)
        {
            health.damageModifier = -12;
        }
        else
        {
            health.damageModifier = 0;
        } //This system needs to be changed if any other damage modifiers come into play, since this function would override them
    }

    public void setBanditsRemaining(int amount)
    {
        banditRemaining = amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health.currentHealth;
        breadText.text = "Bread: " + currentBread;
        swordCheckText.text = "Sword Type: " + currentSword;
        banditRemainingText.text = "Bandits Remaining: " + banditRemaining;
    }

    public void Die()
    {
        //Health totem script is run before this one. Checking whether health is zero here checks if a totem was activated or not, as that script sets health back to full
        if (health.currentHealth > 0)
        {
            UpdateUI();
            return;
        }

        health.currentHealth = 0;
        UpdateUI();
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();
    }
}
