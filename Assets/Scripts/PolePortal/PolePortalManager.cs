using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolePortalManager : MonoBehaviour
{
    public bool debug = true;

    private PolePortalTrigger lastTrigger;
    private bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Log(string msg)
    {
        if (debug) Debug.Log(msg);
    }

    private int Level
    {
        get
        {
            return GameController._instance.Level;
        }

        set
        {
            GameController._instance.Level = value;
        }
    }

    public int PortalAmount
    {
        get
        {
            return GameController._instance.Portals.Count;
        }
    }

    public Portal CurrentPortal
    {
        get
        {
            return GameController._instance.CurrentPortal;
        }
    }

    public void SetTrigger(PolePortalTrigger trigger)
    {
        if (lastTrigger == null)
        {
            lastTrigger = trigger;
        }
        if (trigger != lastTrigger)
        {
            Log("Trigger not equal! Checking if " + trigger.index + ">" + lastTrigger.index);
            if (trigger.index > lastTrigger.index)
            {
                ProgressPortal();
                trigger.enabled = false;
                lastTrigger.enabled = false;
            }

            lastTrigger = trigger;
        }
    }

    /*// TODO: Remove temp code
    public Dimension CurrentDimension()
    {
        Log("Camera layer = " + Camera.main.gameObject.layer);
        foreach (Dimension dimension in LayerManager.definedDimensions)
        {
            Log(dimension.name + " layer = " + dimension.layer);
            if (dimension.layer == Camera.main.gameObject.layer)
                return dimension;
        }
        return null;
    }

    public Dimension NextDimension()
    {
        int index = dimensions.IndexOf(portals[level].dimension2) + 1;
        if (index >= 0 && index < LayerManager.definedDimensions.Count)
            return LayerManager.definedDimensions[index];
        return null;
    }
    //*/

    public bool CheckEligibilty()
    {
        Log("Current level is " + Level);
        if (Level <= 0)
            return true;
        if (Level >= PortalAmount)
            return false;
        Log("Checking if " + CurrentPortal.dimension2.name + "==" + CurrentPortal.FromDimension().name);
        return (CurrentPortal.dimension2 == CurrentPortal.FromDimension());
    }

    public void ProgressPortal()
    {
        Log("Checking elegibility!");
        if (CheckEligibilty())
        {
            Log("Passed! Disabling portal" + Level);
            CurrentPortal.gameObject.SetActive(false);
            if (initialized)
                if (GameController._instance.CurrentButtons > 0)
                    GameController._instance.CurrentButtons--;
                else
                    Level++;
            else
                initialized = true;

            Log("Passed! Enabling portal" + Level);
            CurrentPortal.gameObject.SetActive(true);
        }
    }
}
