using UnityEngine;

public class TotemPickup : MonoBehaviour
{
    private enum TotemType
    {
        Health,
        Shield
    }

    [SerializeField] private TotemType type;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemPickup"))
        {

            PlayerTotems playerTotems =
                collision.GetComponent<PlayerTotems>();

            if(playerTotems != null)
            {
                switch (type)
                {
                    case TotemType.Health:
                        playerTotems.GetHealthTotem();
                        break;

                    case TotemType.Shield:
                        playerTotems.GetShieldTotem();
                        break;

                    default:
                        break;
                }
            }

            Destroy(gameObject);
        }
    }
}
