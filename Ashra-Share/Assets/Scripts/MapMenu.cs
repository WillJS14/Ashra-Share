using UnityEngine;
using UnityEngine.InputSystem;

public class MapMenu : MonoBehaviour
{
    public GameObject localMap;
    public GameObject islandMap;


    void Start()
    {
        localMap.SetActive(false);
        islandMap.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            localMap.SetActive(true);
            islandMap.SetActive(false);
        }
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            OpenMap();
        }
    }

    public void OpenMap()
    {
        islandMap.SetActive(true);
        localMap.SetActive(false);
    }
}