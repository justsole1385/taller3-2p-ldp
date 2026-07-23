using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public Transform targetPlayer; // Arrastra aquí tu Player desde la Jerarquía

    void Update()
    {
        // Sigue al jugador en X, mantiene la Y fija y el Z en -10 (para cámara 2D)
        transform.position = new Vector3(targetPlayer.position.x + 6f, 0, -10);
    }
}
