using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuildings : buildings
{
    private string unitType;

    public string UnitType
    {
        get { return unitType; }
        set { unitType = value; }

    }

    public int PosX
    {
        get { return base.posX; }
        set { posX = value; }

    }
    public int PosY
    {
        get { return base.posY; }
        set { posY = value; }

    }
    public int Health
    {
        get { return base.health; }
        set { health = value; }

    }
    public Faction Faction
    {
        get { return base.faction; }
        set { faction = value; }

    }
    public string Symbol
    {
        get { return base.symbol; }
        set { symbol = value; }

    }

    private int ResourceGenerated;
    private int GeneratePerRound;
    private int ResourcePool;
    private ResourceType Resource;

    public ResourceBuildings(int x, int y, int hp, Faction fac, string sym) :
        base(x, y, hp, fac, sym)
    {

    }

    public override bool Destruction()
    {
        if (Health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public string SpawnUnits()
    {
        return UnitType;
    }

    public void GenerateResources()
    {

    }


    public override string ToString()
    {
        return "Gem Mine: X: " + PosX + "Y: " + PosY
            + "\nHP: " + Health
            + "\nFaction " + Faction
            + "\nResource: " + Resource + ": " + ResourceGenerated
            + "\n" + Resource + "remaining: " + ResourcePool;
    }
}
