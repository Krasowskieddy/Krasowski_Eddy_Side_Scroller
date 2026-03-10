using UnityEngine;

public class button : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D hit;

        bool isBooted = Physics2D.Raycast(transform.position, Vector2.up, out hit, 2f);
    }
}
