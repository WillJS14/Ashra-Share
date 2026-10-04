using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [Header("Teleport Destination")]
    public Vector2 destinationPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

            other.transform.position = new Vector3(
            destinationPosition.x,
            destinationPosition.y,
            other.transform.position.z
        );
    }
}