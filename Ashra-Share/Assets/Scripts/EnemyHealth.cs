using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public Slider healthBar;
    
    public GameObject coinPrefab;
    public int minCoinsDropped = 4;
    public int maxCoinsDropped = 6;
    
    public GameObject wheatPrefab;
    public int minWheatDropped = 1;
    public int maxWheatDropped = 5;

    public GameObject stonePrefab;
    public int minStoneDropped = 1;
    public int maxStoneDropped = 4;

    public GameObject woodPrefab;
    public int minWoodDropped = 1;
    public int maxWoodDropped = 4;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar();

        Debug.Log(gameObject.name + " took damage!");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        healthBar.value = (float)currentHealth / maxHealth;
    }

    void Die()
    {
        DropCoins();
        DropWheat();
        DropStone();
        DropWood();

        GameManager.Instance.BanditKilled();

        Destroy(gameObject);
    }

    void DropCoins()
    {
        int coinsToDrop =
            Random.Range(minCoinsDropped, maxCoinsDropped + 1);

        for (int i = 0; i < coinsToDrop; i++)
        {
            Vector2 randomOffset =
                Random.insideUnitCircle * 0.5f;

            Instantiate(
                coinPrefab,
                (Vector2)transform.position + randomOffset,
                Quaternion.identity
            );
        }
    }

    void DropWheat()
    {
        int WheatToDrop =
            Random.Range(minWheatDropped, maxWheatDropped + 1);

        for (int i = 0; i < WheatToDrop; i++)
        {
            Vector2 randomOffset =
                Random.insideUnitCircle * 0.5f;

            Instantiate(
                wheatPrefab,
                (Vector2)transform.position + randomOffset,
                Quaternion.identity
            );
        }
    }

    void DropStone()
    {
        int StoneToDrop =
            Random.Range(minStoneDropped, maxStoneDropped + 1);

        for (int i = 0; i < StoneToDrop; i++)
        {
            Vector2 randomOffset =
                Random.insideUnitCircle * 0.5f;

            Instantiate(
                stonePrefab,
                (Vector2)transform.position + randomOffset,
                Quaternion.identity
            );
        }
    }

    void DropWood()
    {
        int WoodToDrop =
            Random.Range(minWoodDropped, maxWoodDropped + 1);

        for (int i = 0; i < WoodToDrop; i++)
        {
            Vector2 randomOffset =
                Random.insideUnitCircle * 0.5f;

            Instantiate(
                woodPrefab,
                (Vector2)transform.position + randomOffset,
                Quaternion.identity
            );
        }
    }
}
