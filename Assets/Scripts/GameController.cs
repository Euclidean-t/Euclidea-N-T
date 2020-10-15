using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController _instance;

    void Start()
    {
        _instance = this;
    }

    public List<Portal> portals;
    public List<int> triggers;
    private int level = 0;

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public List<Portal> Portals
    {
        get
        {
            return portals;
        }

        set
        {
            portals = value;
        }
    }

    public List<int> Triggers
    {
        get
        {
            return triggers;
        }

        set
        {
            triggers = value;
        }
    }

    public Portal CurrentPortal
    {
        get
        {
            if (level >= 0 && level < portals.Count)
                return portals[level];
            return null;
        }
    }

    public int CurrentTriggers
    {
        get
        {
            if (level >= 0 && level < triggers.Count)
                return triggers[level];
            return -1;
        }
        set
        {
            if (level >= 0 && level < triggers.Count)
                triggers[level] = value;
            else
                triggers[level] = -1;
        }
    }

    public Dimension CurrentDimension
    {
        get
        {
            if (CurrentPortal == null) return null;
            return CurrentPortal.FromDimension();
        }
    }
}
