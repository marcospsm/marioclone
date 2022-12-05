
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (other.CompareTag("Player"))
        {
            player.Hit();
        }

        else
        {
            Destroy(other.gameObject);
        }
    }
}
