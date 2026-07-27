using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingMenu : MonoBehaviour
{
    public GameObject craftingMenu;

    private bool menuOpen = false;

    void Start()
    {
        craftingMenu.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            menuOpen = !menuOpen;

            craftingMenu.SetActive(menuOpen);
        }
    }
}