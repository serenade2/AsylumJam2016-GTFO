using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraShading : MonoBehaviour
{
    public Material MaterialPostEffect;
    private float _time;

    void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Graphics.Blit(source, destination);
        if (MaterialPostEffect != null)
        {
            MaterialPostEffect.SetFloat("__Time", _time);
            Graphics.Blit(source, destination, MaterialPostEffect);
        }
        else
            Graphics.Blit(source, destination);

    }
}
