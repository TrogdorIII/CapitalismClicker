using UnityEngine;
using System.Collections;

public class BuildingBaseClass
{

    public string name;
    public string description;
    public string tooltip;
    public int cost;

    public BuildingBaseClass(string name, string description, string tooltip, int cost)
    {
        this.name = name;
        this.description = description;
        this.tooltip = tooltip;
        this.cost = cost;
    }

}
