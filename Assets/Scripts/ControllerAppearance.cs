using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ControllerAppearance : MonoBehaviour {

    private IEnumerator coroutine;

    private VRTK_ControllerReference controllerReference;
    private bool initialized;
    private Renderer renderPart;
    private Material material;
    
    // Use this for initialization
    void Start () {
        initialized = false;
    }
	
    void Initialize()
    {
        controllerReference = VRTK_ControllerReference.GetControllerReference(gameObject);
        if (controllerReference != null)
        {
            renderPart = controllerReference.model.GetComponentInChildren<Renderer>();
            if (renderPart != null)
            {
                material = renderPart.material;
                initialized = true;
            }
        }
        
    }

    void FadeOut()
    {
        StopAllCoroutines();
        coroutine = SetControllerAlpha(0.0f, 1.0f);
        StartCoroutine(coroutine);
    }

    void FadeIn()
    {
        StopAllCoroutines();
        coroutine = SetControllerAlpha(1.0f, 1.0f);
        StartCoroutine(coroutine);
    }

    IEnumerator SetControllerAlpha (float newAlpha, float fadeTime)
    {
        float currentAlpha = material.GetFloat("_Alpha");
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeTime)
        {
            material.SetFloat("_Alpha", Mathf.Lerp(currentAlpha, newAlpha, t));
            yield return null;
        }
        
    }

	// Update is called once per frame
	void Update () {
        if (!initialized)
        {
            Initialize();
        }
    }
}
