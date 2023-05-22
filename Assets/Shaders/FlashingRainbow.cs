using UnityEngine;

public class FlashingRainbow : MonoBehaviour
{
    public Renderer targetRenderer;
    public Texture baseTexture;
    public Texture normalMap;
    public Color rainbowColor = Color.white;
    public float speed = 1f;
    public float transparency = 1f;

    private void Update()
    {
        float time = Time.time * speed;
        float hue = Mathf.Repeat(time, 1f);
        Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f);

        targetRenderer.material.SetColor("_Color", rainbowColor);
        targetRenderer.material.SetTexture("_BaseTexture", baseTexture);
        targetRenderer.material.SetTexture("_NormalMap", normalMap);
        targetRenderer.material.SetFloat("_Transparency", transparency);
    }
}