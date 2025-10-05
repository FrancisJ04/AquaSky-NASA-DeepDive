using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthHotspot : MonoBehaviour
{
    public Camera playerCamera;               // arrastra la Main Camera
    public string sceneToLoad = "OceanScene"; // nombre exacto de la escena
    public float rayDistance = 100f;          // distancia máxima del raycast
    public EarthMove earth;                   // referencia al planeta para detener rotación
    private SceneTransition sceneTransition;  // referencia al sistema de fade

    void Start()
    {
        // Buscar automáticamente el controlador de transición en la escena
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    void Update()
    {
        // Raycast desde el centro de la cámara
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Si golpea este objeto y se hace clic
            if (hit.collider.gameObject == this.gameObject && Input.GetMouseButtonDown(0))
            {
                Debug.Log("🌍 Tierra seleccionada → cambiando a escena oceánica...");

                // Detener la rotación de la Tierra
                if (earth != null)
                    earth.canRotate = false;

                // Si existe un sistema de transición, usarlo
                if (sceneTransition != null)
                {
                    sceneTransition.LoadSceneWithFade(sceneToLoad);
                }
                else
                {
                    // Si no hay transición, cambiar de escena directamente
                    SceneManager.LoadScene(sceneToLoad);
                }
            }
        }
    }
}
