using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class KnopPortalTrigger : PolePortalTrigger
{
    protected override void OnTriggerEnter(Collider other)
    {
        Log(this.name + ": OnTriggerEnter(" + other.gameObject.name + ")");
        if (other.gameObject.TryGetComponent(typeof(Hand), out Component controller) || other.gameObject == Camera.main.gameObject)
        {
            manager.SetTrigger(this);
        }
    }
}
