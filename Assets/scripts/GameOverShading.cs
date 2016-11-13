using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GameOverShading : MonoBehaviour
{

    public Material MaterialPostEffect;
    public float RedPerSecond = 1;
    public float MinFrequency;
    public float MaxFrequency;
    public float FrequencyPerSecond;
    public float DelayBeforeFadeOut;
    public float FadeOutPerSecond;
    public bool IsShading;
    private float _time = 0;

    void FixedUpdate()
    {
        if (IsShading)
            _time += Time.fixedDeltaTime;
        else
            _time = 0;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Graphics.Blit(source, destination);
        if (MaterialPostEffect != null && IsShading)
        {
            MaterialPostEffect.SetFloat("__Time", _time);
            MaterialPostEffect.SetColor("_TintColor", new Color(-FadeOutPerSecond * _time + DelayBeforeFadeOut, 1 - RedPerSecond * _time, 1 - RedPerSecond * _time));
            float frequency = MinFrequency + _time * FrequencyPerSecond;
            MaterialPostEffect.SetFloat("_FreqX", frequency <= MaxFrequency ? frequency : MaxFrequency);
            RenderTexture intermediate = new RenderTexture(source.width, source.height, source.depth);
            Graphics.Blit(source, intermediate, MaterialPostEffect);
            Graphics.Blit(intermediate, destination);
        }
        else
            Graphics.Blit(source, destination);
    }
}
