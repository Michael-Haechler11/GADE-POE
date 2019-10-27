using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuildings : buildings
{
    public string UnitType
    {
        get { return unitType; }
        set { unitType = value; }
    }
    private int spawnPointY;

    public int SpawnPointY
    {
        get { return spawnPointY; }
        set { spawnPointY = value; }
    }

    private int spawnPointX;

    public int SpawnPointX
    {
        get { return spawnPointX; }
        set { spawnPointX = value; }
    }

    private int spawnSpeed;

    public int SpawnSpeed
    {
        get { return spawnSpeed; }
        set { spawnSpeed = value; }

    }
    private int productionSpeed;

    public int ProductionSpeed
    {
        get { return productionSpeed; }
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

    private string unitType;

    public FactoryBuildings(int x, int y, int hp, Faction fac, string sym, int Pspeed, string uType) :
        base(x, y, hp, fac, sym)
    {
        productionSpeed = Pspeed;
        unitType = uType;
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
        return unitType;
    }

    public override string ToString()
    {
        return " Barraks : X: " + posX
                        + "Y: " + posY
                        + "\nHealth: " + Health
                        + "\nUnitSpawn: " + unitType
                        + "\nProduction Speed: " + ProductionSpeed
                        + "\nFaction: " + Faction;

    }
}
