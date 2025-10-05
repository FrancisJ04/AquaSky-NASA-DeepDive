using UnityEngine;

public class EarthMove : MonoBehaviour
{
    public bool canRotate = true; // <-- esta variable la usas desde EarthHotspot

    Vector3 rotationSpeed = new Vector3(0, 5f, 0);

    void Update()
    {
        if (canRotate)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
}

