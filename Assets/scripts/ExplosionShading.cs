using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ExplosionShading : MonoBehaviour
{
    public Material MaterialPostEffect;
    private float _time = 1000.0f;
    private Camera _camera;

    public Vector3 TestExplosionLocation;

    [InspectorButton("OnExplodeClicked")]
    public bool Explode;

    protected void OnExplodeClicked()
    {
        FireExplosion(TestExplosionLocation);
    }

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }

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

    public void FireExplosion(Vector3 position)
    {
        Vector3 viewportPosition = _camera.WorldToViewportPoint(position);
        _time = 0.0f;
        MaterialPostEffect.SetFloat("pX", viewportPosition.y);
        MaterialPostEffect.SetFloat("pY", viewportPosition.x);
    }
}
