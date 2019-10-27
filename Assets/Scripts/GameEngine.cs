using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        m = new Map(UnitNum, mapHeight, mapWidth);
        m.GenerateBattleField();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int mapHeight = 20;
    private int mapWidth = 20;

    static int UnitNum = 8;
    public int Round = 1;

    private Map m;

    public GameObject emptyTile;
    public GameObject meleeUnitOverwatch;
    public GameObject meleeUnitTalon;
    public GameObject rangedUnitOverwatch;
    public GameObject rangedUnitTalon;
    public GameObject wizzardUnitNeutral;
    public GameObject FactoryBuildingsOverwatch;
    public GameObject FactoryBuildingsTalon;
    public GameObject ResourceBuildingsOverwatch;
    public GameObject ResourceBuildingsTalon;

    public void GameEng()
    {
        int hero = 0;
        int villian = 0;

        foreach (ResourceBuildings u in m.BitCoinMine)
        {
            if (u.Faction == Faction.Overwatch)
            {
                hero++;
            }
            else
            {
                villian++;
            }
        }

        foreach (FactoryBuildings u in m.Barracks)
        {
            if (u.Faction == Faction.Overwatch)
            {
                hero++;
            }
            else
            {
                villian++;
            }
        }

        foreach (Unit u in m.units)
        {
            if (u.factionType == Faction.Overwatch)
            {
                villian++;
            }
            else
            {
                villian++;
            }
        }


        if (hero > 0 && villian > 0)
        {
            foreach (ResourceBuildings Rb in m.BitCoinMine)
            {
                Rb.GenerateResources();
            }

            foreach (FactoryBuildings Fb in m.Barracks)
            {
                if (Round % Fb.ProductionSpeed == 0)
                {
                    m.SpawnUnits(Fb.SpawnPointX, Fb.SpawnPointY, Fb.Faction, Fb.SpawnUnits());
                }
            }

            foreach (Unit u in m.units)
            {
                u.CheckAttackRange(m.units, m.buildings);
            }

            m.Populate();
            m.PlaceBuildings();
            Round++;
           // Placebuttons();

        }
        else
        {
            m.Populate();
            m.PlaceBuildings();
            //Placebuttons();


            if (hero > villian)
            {
               // MessageBox.Show("Hero Wins on Round: " + Round);
            }
            else
            {
                //MessageBox.Show("Villian Wins on Round: " + Round);
            }
        }

        for (int i = 0; i < m.rangedUnits.Count; i++)
        {
            if (m.rangedUnits[i].Death())
            {
                m.map[m.rangedUnits[i].posX, m.rangedUnits[i].posX] = "";
                m.rangedUnits.RemoveAt(i);
            }
        }

        for (int i = 0; i < m.meleeUnits.Count; i++)
        {
            if (m.meleeUnits[i].Death())
            {
                m.map[m.meleeUnits[i].posX, m.meleeUnits[i].posX] = "";
                m.meleeUnits.RemoveAt(i);
            }
        }

        for (int i = 0; i < m.units.Count; i++)
        {
            if (m.units[i].Death())
            {
                m.map[m.units[i].posX, m.units[i].posX] = "";
                m.units.RemoveAt(i);
            }
        }
        for (int i = 0; i < m.Barracks.Count; ++i)
        {
            if (m.Barracks[i].Destruction())
            {
                m.map[m.Barracks[i].PosX, m.Barracks[i].PosY] = "";
                m.Barracks.RemoveAt(i);
            }
        }

        for (int i = 0; i < m.BitCoinMine.Count; ++i)
        {
            if (m.BitCoinMine[i].Destruction())
            {
                m.map[m.BitCoinMine[i].PosX, m.BitCoinMine[i].PosY] = "";
                m.BitCoinMine.RemoveAt(i);
            }
        }

        

        for (int i = 0; i < m.buildings.Count; ++i)
        {
            if (m.buildings[i].Destruction())
            {
                if (m.buildings[i] is FactoryBuildings)
                {
                    FactoryBuildings FB = (FactoryBuildings)m.buildings[i];
                    m.map[FB.PosX, FB.PosY] = "";

                }
                else if (m.buildings[i] is ResourceBuildings)
                {
                    ResourceBuildings RB = (ResourceBuildings)m.buildings[i];
                    m.map[RB.PosX, RB.PosY] = "";
                }
                m.buildings.RemoveAt(i);
            }
        }

    }
    public void InisialiseMap()
    {
        for( int i = 0; i < mapWidth; i++)
        {
            for(int j = 0; j < mapHeight; j++)
            {
                m.mapTiles[i, j] = Tiles.emptyTile;
            }
        }
   
    }

    public void PlaceObjects()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("tile");
        foreach (GameObject g in tiles)
        {
            Destroy(g);
        }

        for(int x = 0; x < mapWidth; x++)
        {
            for(int z = 0; z < mapHeight; z++)
            {
                if(m.mapTiles[x,z] == Tiles.emptyTile)
                {
                    Instantiate(emptyTile, new Vector3(x, 0f, z), Quaternion.identity);
                }
                else if (m.mapTiles[x, z] == Tiles.meleeUnitOverwatch)
                {
                    Instantiate(meleeUnitOverwatch, new Vector3(x, 0f, z), Quaternion.identity);
                }
                else if (m.mapTiles[x, z] == Tiles.meleeUnitTalon)
                {
                    Instantiate(meleeUnitTalon, new Vector3(x, 0f, z), Quaternion.identity);
                }

    }
}
