using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class ShaderPropertyController : MonoBehaviour
{
    public Material material;   // Assign your material here in the Inspector.
    public string ShaderProperty = "_RecolorFade";
    public float StartValue;
    public float EndValue;
    public float fadeTime = 1f; // Time to fade the _RecolorFade from 1 to 0.

    private int recolorFadeID;  // Cached ID of the shader property.
    private float elapsedTime;  // Time since the script started running.

    private void Start()
    {
        // Convert property name to ID for optimized shader lookups.
        recolorFadeID = Shader.PropertyToID(ShaderProperty);

        // Check if the material and shader support this property.
        if (!material.HasProperty(recolorFadeID))
        {
            Debug.LogWarning($"The shader used by {material.name} does not have a _RecolorFade property.", this);
            enabled = false;  // Disable the script.
        }
    }

    public void TweenShaderProperty()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float fadeValue = Mathf.Lerp(StartValue, EndValue, elapsedTime / fadeTime);
            material.SetFloat(recolorFadeID, fadeValue);
            yield return null; // wait for the next frame
        }
    }
}
