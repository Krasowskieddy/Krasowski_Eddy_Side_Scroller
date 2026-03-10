using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    [Header("Camera")]
    public Camera cam;

    [Header("options")]
    public bool enableVertical = true;

    [Tooltip("Lissage du mouvement (0 = aucun, 1 = instantané).")]
    [Range(0f, 1f)]
    public float smoothing = 0.1f;

    private ParallaxLayers[] layers;
    private Vector3 previousCamPos;

    void Awake()
    {
        if (cam == null) cam = Camera.main;

        previousCamPos = cam.transform.position;

        int count = transform.childCount;

        layers = new ParallaxLayers[count];
        Debug.Log(count);
        for (int i = 0; i < count; i++)
        {
            layers[i] = new ParallaxLayers(transform.GetChild(i));
        }
    }

    private void LateUpdate()
    {
        Vector3 camPos = cam.transform.position;
        Vector3 delta = camPos - previousCamPos;

        foreach (ParallaxLayers layer in layers)
        {
            layer.Move(delta, enableVertical, smoothing);
        }
        previousCamPos = camPos;
        previousCamPos = camPos;
    }
}
