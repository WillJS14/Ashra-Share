using UnityEngine;
using UnityEngine.InputSystem;

public class OpenControlsScreen : MonoBehaviour
{
    public GameObject openControlsScreen;

    private Transform player;

    void Start()
    {
        openControlsScreen.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame) 
        {

            openControlsScreen.SetActive(true);
            Time.timeScale = 0f;
            /*if (menuOpen = true)
            {
                Time.timeScale = 0f;
            }
            else if (menuOpen = false)
            {
                Time.timeScale = 1f;
            }*/
        }
    }
}