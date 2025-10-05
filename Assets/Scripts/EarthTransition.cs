using UnityEngine;

public class EarthTransition : MonoBehaviour
{
    public Material earthMat;         // material con el shader de mezcla
    public float delay = 5f;          // segundos antes de iniciar transición
    public float transitionTime = 3f; // duración de la transición

    private float blend = 0f;
    private bool transitioning = false;

    void Start()
    {
        earthMat.SetFloat("_Blend", 0f);
        Invoke(nameof(StartTransition), delay);
    }

    void Update()
    {
        if (transitioning)
        {
            blend += Time.deltaTime / transitionTime;
            earthMat.SetFloat("_Blend", Mathf.Clamp01(blend));
        }
    }

    void StartTransition()
    {
        transitioning = true;
    }
}

