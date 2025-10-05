using UnityEngine;

public class EarthMaterialChanger : MonoBehaviour
{
    [Header("Materiales del planeta")]
    public Material normalMaterial;             // Tierra normal
    public Material gravityGradientMaterial;    // Gradiente gravitacional
    public Material colorDataMaterial;          // ColorData.png
    public Material clorofilaDataMaterial;      // ClorofilaData.jpg

    [Header("Imágenes flotantes")]
    public GameObject floatingImageGradient;    // Imagen del gradiente
    public GameObject floatingImageColorData;   // Imagen del ColorData
    public GameObject floatingImageClorofila;   // Imagen del ClorofilaData

    [Header("Tiempos (segundos)")]
    public float firstDelay = 5f;               // Espera inicial antes del gradiente
    public float secondDelay = 5f;              // Espera después del gradiente
    public float thirdDelay = 5f;               // Espera después del ColorData

    private Renderer earthRenderer;

    void Start()
    {
        earthRenderer = GetComponent<Renderer>();

        // Estado inicial
        earthRenderer.material = normalMaterial;

        if (floatingImageGradient != null)
            floatingImageGradient.SetActive(false);
        if (floatingImageColorData != null)
            floatingImageColorData.SetActive(false);
        if (floatingImageClorofila != null)
            floatingImageClorofila.SetActive(false);

        // Primera transición
        Invoke(nameof(ChangeToGravityGradient), firstDelay);
    }

    void ChangeToGravityGradient()
    {
        earthRenderer.material = gravityGradientMaterial;

        if (floatingImageGradient != null)
            floatingImageGradient.SetActive(true);

        Invoke(nameof(ChangeToColorData), secondDelay);
    }

    void ChangeToColorData()
    {
        earthRenderer.material = colorDataMaterial;

        if (floatingImageGradient != null)
            floatingImageGradient.SetActive(false);
        if (floatingImageColorData != null)
            floatingImageColorData.SetActive(true);

        Invoke(nameof(ChangeToClorofilaData), thirdDelay);
    }

    void ChangeToClorofilaData()
    {
        earthRenderer.material = clorofilaDataMaterial;

        if (floatingImageColorData != null)
            floatingImageColorData.SetActive(false);
        if (floatingImageClorofila != null)
            floatingImageClorofila.SetActive(true);
    }
}

