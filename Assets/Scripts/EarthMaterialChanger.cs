using UnityEngine;

public class EarthMaterialChanger : MonoBehaviour
{
    [Header("Asignar materiales desde el Inspector")]
    public Material normalMaterial;
    public Material gravityGradientMaterial;

    [Header("Tiempo antes del cambio (segundos)")]
    public float delay = 5f;

    private Renderer earthRenderer;

    void Start()
    {
        // Obtiene el Renderer del objeto actual (la esfera)
        earthRenderer = GetComponent<Renderer>();

        // Establece el material inicial
        earthRenderer.material = normalMaterial;

        // Ejecuta el cambio después de 'delay' segundos
        Invoke(nameof(ChangeToGravityGradient), delay);
    }

    void ChangeToGravityGradient()
    {
        earthRenderer.material = gravityGradientMaterial;
    }
}

