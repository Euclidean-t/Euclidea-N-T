using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolePortalTrigger : MonoBehaviour
{
    public PolePortalManager manager;
    public int index;
    public bool debug = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Log(string msg)
    {
        if (debug) Debug.Log(msg);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Log(this.name + ": OnTriggerEnter(" + other.gameObject.name + ")");
        if (other.gameObject == Camera.main.gameObject)
        {
            manager.SetTrigger(this);
        }
    }
}
