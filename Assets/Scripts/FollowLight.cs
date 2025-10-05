using UnityEngine;

public class FollowLight : MonoBehaviour
{
    public Transform player;       // Arrastra el objeto del jugador
    public Vector3 offset = new Vector3(0, 2, 0); // Altura relativa de la luz

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
