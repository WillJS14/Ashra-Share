using UnityEngine;
using UnityEngine.InputSystem;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject shopMenuClosed;
    public float openShopRadius = 10f;
    public GameObject shopPrompt;

    private bool menuOpen = false;
    private bool shopOpen = false;
    private Transform shop;

    void Start()
    {
        shopMenu.SetActive(false);
        shopMenuClosed.SetActive(false);
        shop = GameObject.FindGameObjectWithTag("Shop").transform;
    }

    void Update()
    {
        float distanceToShop =
            Vector2.Distance(transform.position, shop.position);

        bool playerNearShop =
            distanceToShop <= openShopRadius;

        shopPrompt.SetActive(playerNearShop);

        if (!playerNearShop)
        {
            menuOpen = false;
            shopMenu.SetActive(false);
            shopMenuClosed.SetActive(false);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame && playerNearShop)
        {
            if (shopOpen)
            {
                menuOpen = !menuOpen;
                shopMenu.SetActive(menuOpen);
            }
            else
            {
                menuOpen = !menuOpen;
                shopMenuClosed.SetActive(menuOpen);
            }
        }
    }
    public void RepairShop(bool repairedShopStatus)
    {
        shopOpen = true;
        shopMenu.SetActive(true);
        shopMenuClosed.SetActive(false);

    }
}