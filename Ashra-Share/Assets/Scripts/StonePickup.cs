using UnityEngine;

public class StonePickup : MonoBehaviour
{
    public int minStoneValue = 2;
    public int maxStoneValue = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something touched stone: " + other.name);

        if (other.CompareTag("ItemPickup"))
        {
            Debug.Log("Player picked up Stone!");

            PlayerStone playerStone =
                other.GetComponent<PlayerStone>();

            int randomStoneValue = Random.Range(minStoneValue, maxStoneValue + 1);

            if (playerStone != null)
            {
                playerStone.AddStone(randomStoneValue);
            }

            Destroy(gameObject);
        }
    }
}