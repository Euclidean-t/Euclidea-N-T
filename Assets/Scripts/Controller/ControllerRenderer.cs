using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerRenderer : MonoBehaviour
{
    private SteamVR_RenderModel SteamVRRenderer;
    private bool rendering = true;
    public Dimension dimension;

    private RaycastHit hit;
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        SteamVRRenderer = GetComponent<SteamVR_RenderModel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dimension == GameController._instance.CurrentDimension)
        {
            ray = new Ray(transform.position, Camera.main.transform.position - transform.position);
            Collider portalCollider = GameController._instance.CurrentPortal.gameObject.GetComponent<Collider>();
            if (portalCollider.Raycast(ray, out hit, (Camera.main.transform.position - transform.position).magnitude))
            {
                if (rendering)
                {
                    SteamVRRenderer.SetMeshRendererState(false);
                    rendering = false;
                }
            }
            else
            {
                if (!rendering)
                {
                    SteamVRRenderer.SetMeshRendererState(true);
                    rendering = true;
                }
            }
        }
        else
        {
            ray = new Ray(transform.position, Camera.main.transform.position - transform.position);
            Collider portalCollider = GameController._instance.CurrentPortal.gameObject.GetComponent<Collider>();
            if (portalCollider.Raycast(ray, out hit, (Camera.main.transform.position - transform.position).magnitude))
            {
                Debug.Log("Hit " + hit.collider.gameObject.name);
                if (!rendering)
                {
                    Debug.Log("Enabling rendering!");
                    SteamVRRenderer.SetMeshRendererState(true);
                    rendering = true;
                }
            } 
            else
            {
                if (rendering)
                {
                    Debug.Log("Disabling rendering!");
                    SteamVRRenderer.SetMeshRendererState(false);
                    rendering = false;
                }
            }
        }
    }

    public void SwitchDimensions(Dimension to)
    {
        dimension = to;
    }
}
