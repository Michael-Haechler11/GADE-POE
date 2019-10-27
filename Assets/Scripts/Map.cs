using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Faction
{
    Overwatch,
    Talon,
    Neutral
}

public enum ResourceType
{
    Gems,
    oil

}

public enum Tiles
{
    emptyTile,
    meleeUnitOverwatch,
    meleeUnitTalon,
    rangedUnitOverwatch,
    rangedUnitTalon,
    wizzardUnitNeutral,
    FactoryBuildingsOverwatch,
    FactoryBuildingsTalon,
    ResourceBuildingsOverwatch,
    ResourceBuildingsTalon

}

public class Map : MonoBehaviour


{
    public string[,] map;// = new string[20, 20];


    int mapHeight = 20;
    int mapWidth = 20;
    public List<Unit> units = new List<Unit>();
    public List<Unit> rangedUnits = new List<Unit>();
    public List<Unit> meleeUnits = new List<Unit>();
    public buildings[,] buildingMap;// = new buildings[20, 20];

    public List<buildings> buildings = new List<buildings>();
    public List<ResourceBuildings> BitCoinMine = new List<ResourceBuildings>();
    public List<FactoryBuildings> Barracks = new List<FactoryBuildings>();
    public List<WizzardUnits> wizzardUnits = new List<WizzardUnits>();
    public Unit[,] uniMap;// = new Unit [20, 20];

    public Tiles[,] mapTiles;


    Random Rd = new Random();

    int BuildingNum;

    public Map(int UnitN, int MapH, int MapW)
    {
        mapHeight = MapH;
        mapWidth = MapW;
        mapTiles = new Tiles[mapWidth, mapHeight];

        buildingMap = new buildings[mapWidth, mapHeight];
        uniMap = new Unit[mapWidth, mapHeight];
        map = new string[mapWidth, mapHeight];

        BuildingNum = UnitN;

    }

    public void GenerateBattleField() // method to allow the random number of units, including the ranged and the melee units
    {

        for (int i = 0; i < BuildingNum; i++)
        {
            int UnitNum = Random.Range(0, 2);
            string UnitName;
            if (UnitNum == 0)
            {
                UnitName = "Melee";
            }
            else
            {
                UnitName = "Ranged";
            }

            ResourceBuildings DiamondMine = new ResourceBuildings(0, 0, 100, Faction.Overwatch, "**");
            BitCoinMine.Add(DiamondMine);

            FactoryBuildings Barrack = new FactoryBuildings(0, 0, 100, Faction.Overwatch, "$$", Random.Range(3, 10), UnitName);
            Barracks.Add(Barrack);

        }
        for (int i = 0; i < BuildingNum; i++)
        {
            int UnitNum = Random.Range(0, 2);
            string UnitName;
            if (UnitNum == 0)
            {
                UnitName = "Melee";
            }
            else
            {
                UnitName = "Ranged";
            }

            ResourceBuildings DiamondMine = new ResourceBuildings(0, 0, 100, Faction.Talon, "**");
            BitCoinMine.Add(DiamondMine);

            FactoryBuildings barrack = new FactoryBuildings(0, 0, 100, Faction.Talon, "$$", Random.Range(3, 10), UnitName);
            Barracks.Add(barrack);

        }
        for (int i = 0; i < BuildingNum; i++)
        {
            WizzardUnits wizzard = new WizzardUnits("Wizard", 0, 0, Faction.Neutral, 20, 2, 3, 1, "^", false);
            wizzardUnits.Add(wizzard);
        }

        foreach (ResourceBuildings u in BitCoinMine)
        {
            for (int i = 0; i < BitCoinMine.Count; i++)
            {
                int xPos = Random.Range(0, mapHeight);
                int yPos = Random.Range(0, mapWidth);

                while (xPos == BitCoinMine[i].PosX && yPos == BitCoinMine[i].PosY && xPos == Barracks[i].PosX && yPos == Barracks[i].PosY)
                {
                    xPos = Random.Range(0, mapHeight);
                    yPos = Random.Range(0, mapWidth);
                }

                u.PosX = xPos;
                u.PosY = yPos;

            }
            buildingMap[u.PosY, u.PosX] = (buildings)u;
            buildings.Add(u);
        }


        foreach (FactoryBuildings u in Barracks)
        {
            for (int i = 0; i < Barracks.Count; i++)
            {
                int xPos = Random.Range(0, mapHeight);
                int yPos = Random.Range(0, mapWidth);

                while (xPos == Barracks[i].PosX && yPos == Barracks[i].PosY && xPos == BitCoinMine[i].PosX && yPos == BitCoinMine[i].PosY)
                {
                    xPos = Random.Range(0, mapHeight);
                    yPos = Random.Range(0, mapWidth);
                }

                u.PosX = xPos;
                u.PosY = yPos;

            }
            buildingMap[u.PosY, u.PosX] = (buildings)u;
            buildings.Add(u);

            u.SpawnPointY = u.PosY;
            if (u.PosX < 19)
            {
                u.SpawnPointX = u.PosX + 1;
            }
            else
            {
                u.SpawnPointX = u.PosX - 1;
            }
        }
        foreach (WizzardUnits u in wizzardUnits)
        {
            for (int i = 0; i < wizzardUnits.Count; i++)
            {
                int xPos = Random.Range(0, mapHeight);
                int yPos = Random.Range(0, mapWidth);

                while (xPos == BitCoinMine[i].PosX && yPos == BitCoinMine[i].PosY && xPos == Barracks[i].PosX && yPos == Barracks[i].PosY && xPos == wizzardUnits[i].PosX && yPos == wizzardUnits[i].PosY)
                {
                    xPos = Random.Range(0, mapHeight);
                    yPos = Random.Range(0, mapWidth);
                }

                u.PosX = xPos;
                u.PosY = yPos;

            }
            uniMap[u.PosY, u.PosX] = (Unit)u;
            units.Add(u);
        }
        Populate();
        PlaceBuildings();
    }

    public void Populate() // method used to populate the map with units
    {
        foreach (RangedUnits u in rangedUnits)
        {
            if(u.FactionType == Faction.Overwatch)
            {
                mapTiles[u.PosY, u.PosX] = Tiles.rangedUnitOverwatch;
            }
            else
            {
                mapTiles[u.PosY, u.PosX] = Tiles.rangedUnitTalon;
            }
        }

        foreach( MeleeUnit u in meleeUnits)
        {
            if(u.FactionType == Faction.Overwatch)
            {
                mapTiles[u.PosY, u.PosX] = Tiles.meleeUnitOverwatch;
            }
            else
            {
                mapTiles[u.PosY, u.PosX] = Tiles.meleeUnitTalon;
            }
        }

        foreach (WizzardUnits u in wizzardUnits)
        {
            mapTiles[u.PosY, u.PosX] = Tiles.wizzardUnitNeutral;
        }

    }

    public void PlaceBuildings()  //method that places the buidlings on the map
    {
        foreach (FactoryBuildings u in Barracks )
        {
            if (u.Faction == Faction.Overwatch)
            {
                mapTiles[u.PosY, u.PosX] = Tiles.FactoryBuildingsOverwatch;
            }
            else
            {
                mapTiles[u.PosY, u.PosX] = Tiles.FactoryBuildingsTalon;
            }
        }
        foreach (ResourceBuildings u in BitCoinMine)
        {
            if (u.Faction == Faction.Overwatch)
            {
                mapTiles[u.PosY, u.PosX] = Tiles.ResourceBuildingsOverwatch;
            }
            else
            {
                mapTiles[u.PosY, u.PosX] = Tiles.ResourceBuildingsTalon;
            }
        }
    }


    public void SpawnUnits(int x, int y, Faction fac, string unitType)
    {
        if (unitType == "Ranged")
        {
            RangedUnits sniper = new RangedUnits("sniper", x, y, fac, 30, 1, 5, 3, "->", false);
            rangedUnits.Add(sniper);
            units.Add(sniper);
        }
        else if (unitType == "Melee")
        {

            MeleeUnit Cavalry = new MeleeUnit("Cavalry", x, y, fac, 50, 1, 10, 1, "#", false);
            meleeUnits.Add(Cavalry);
            units.Add(Cavalry);
        }
    }

}
