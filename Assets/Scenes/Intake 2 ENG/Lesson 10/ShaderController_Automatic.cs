using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class ShaderController_Automatic : MonoBehaviour
{
    public Material material;    // Assign your material here in the Inspector.
    public string[] ShaderProperties;  // Array of shader properties
    public float StartValue;
    public float EndValue;
    public float fadeTime = 1f;  // Time to fade the _RecolorFade from 1 to 0.

    private int[] propertyIDs;   // Cached IDs of the shader properties.
    private float elapsedTime;   // Time since the script started running.

    private void Start()
    {
        // Convert property names to IDs for optimized shader lookups.
        propertyIDs = new int[ShaderProperties.Length];
        for (int i = 0; i < ShaderProperties.Length; i++)
        {
            propertyIDs[i] = Shader.PropertyToID(ShaderProperties[i]);

            // Check if the material and shader support this property.
            if (!material.HasProperty(propertyIDs[i]))
            {
                Debug.LogWarning($"The shader used by {material.name} does not have a {ShaderProperties[i]} property.", this);
                enabled = false;  // Disable the script.
            }
        }
        
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float fadeValue = Mathf.Lerp(StartValue, EndValue, elapsedTime / fadeTime);

            // Apply fade value to each shader property
            foreach (int propertyID in propertyIDs)
            {
                material.SetFloat(propertyID, fadeValue);
            }

            yield return null; // wait for the next frame
        }
    }
}