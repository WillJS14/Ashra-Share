using UnityEngine;

public class YSort : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Sorting")]
    public int sortingOffset = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        sr.sortingOrder =
            Mathf.RoundToInt(-transform.position.y * 100) + sortingOffset;
    }
}