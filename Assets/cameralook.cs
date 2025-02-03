using UnityEngine;

public class CameraVerticalLook : MonoBehaviour
{
    public Transform player; // Sleep de speler hier in via de editor
    public float mouseSensitivity = 5f;

    private float pitch = 0f;

    void Update()
    {
        if (player == null) return;

        // Lees muisbewegingen voor op- en neerrotatie
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Beperk rotatie tussen -80 en 80 graden
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);

        // Draai de camera omhoog of omlaag rond de speler
        Vector3 targetPosition = player.position;
        transform.position = targetPosition;
        transform.rotation = Quaternion.Euler(pitch, player.eulerAngles.y, 0f);
    }
}
