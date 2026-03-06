using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public float smoothTime = .2f;
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    public float distance = 5f;

    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;
        GetComponent<Camera>().orthographicSize = distance;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
