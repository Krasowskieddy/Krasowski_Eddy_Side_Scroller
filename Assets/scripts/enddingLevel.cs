using UnityEngine;

public class enddingLevel : MonoBehaviour
{
    public GameObject player;
    public Transform upgradePoint;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = upgradePoint.position;
        }
    }
}
