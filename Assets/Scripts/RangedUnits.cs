using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUnits : Unit
{
    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public int PosX
    {
        get { return base.posX; }
        set { base.posX = value; }
    }

    public int PosY
    {
        get { return base.posY; }
        set { base.posY = value; }
    }

    public int Health
    {
        get { return base.health; }
        set { base.health = value; }
    }

    public int MaxHealth
    {
        get { return base.maxHealth; }
    }

    public int Speed
    {
        get { return base.speed; }
    }

    public int Attack
    {
        get { return base.attack; }
    }

    public int AttackRange
    {
        get { return base.attackRange; }
    }

    public string Symbol
    {
        get { return base.symbol; }
    }


    public Faction FactionType
    {
        get { return base.factionType; }
    }

    public bool IsAttacking
    {
        get { return base.isAttacking; }
        set { base.isAttacking = value; }
    }

    private int speedCounter = 1;
    List<Unit> units = new List<Unit>();
    List<buildings> building = new List<buildings>();
    Random r = new Random();
    Unit closestUnit;
    buildings closestBuilding;

    public RangedUnits(string n, int x, int y, Faction faction, int hp, int sp, int att, int attRange, string sym, bool isAtt)
        : base(n, x, y, hp, sp, att, attRange, sym, faction, isAtt)
    {


    }

    public override void Move(int type)
    {
        //Moves towards closest enemey
        if (Health > MaxHealth * 0.25)
        {
            if (type == 0)
            {
                if (closestUnit is MeleeUnit)
                {
                    MeleeUnit closestUnitM = (MeleeUnit)closestUnit;

                    if (closestUnitM.PosX > posX && PosX < 20)
                    {
                        posX++;
                    }
                    else if (closestUnitM.PosX < posX && posX > 0)
                    {
                        posX--;
                    }

                    if (closestUnitM.PosY > posY && PosY < 20)
                    {
                        posY++;
                    }
                    else if (closestUnitM.PosY < posY && posY > 0)
                    {
                        posY--;
                    }
                }
                else if (closestUnit is RangedUnits)
                {
                    RangedUnits closestUnitR = (RangedUnits)closestUnit;

                    if (closestUnitR.PosX > posX && PosX < 20)
                    {
                        posX++;
                    }
                    else if (closestUnitR.PosX < posX && posX > 0)
                    {
                        posX--;
                    }

                    if (closestUnitR.PosY > posY && PosY < 20)
                    {
                        posY++;
                    }
                    else if (closestUnitR.PosY < posY && posY > 0)
                    {
                        posY--;
                    }
                }
                else if (closestUnit is WizzardUnits)
                {
                    WizzardUnits closestUnitR = (WizzardUnits)closestUnit;

                    if (closestUnitR.PosX > posX && PosX < 20)
                    {
                        posX++;
                    }
                    else if (closestUnitR.PosX < posX && posX > 0)
                    {
                        posX--;
                    }

                    if (closestUnitR.PosY > posY && PosY < 20)
                    {
                        posY++;
                    }
                    else if (closestUnitR.PosY < posY && posY > 0)
                    {
                        posY--;
                    }
                }
            }
            else
            {
                if (closestBuilding is FactoryBuildings)
                {
                    FactoryBuildings closestBuildingFB = (FactoryBuildings)closestBuilding;

                    if (closestBuildingFB.PosX > posX && PosX < 20)
                    {
                        posX++;
                    }
                    else if (closestBuildingFB.PosX < posX && posX > 0)
                    {
                        posX--;
                    }

                    if (closestBuildingFB.PosY > posY && PosY < 20)
                    {
                        posY++;
                    }
                    else if (closestBuildingFB.PosY < posY && posY > 0)
                    {
                        posY--;
                    }
                }
                else if (closestBuilding is ResourceBuildings)
                {
                    ResourceBuildings closestBuildingRB = (ResourceBuildings)closestBuilding;

                    if (closestBuildingRB.PosX > posX && PosX < 20)
                    {
                        posX++;
                    }
                    else if (closestBuildingRB.PosX < posX && posX > 0)
                    {
                        posX--;
                    }

                    if (closestBuildingRB.PosY > posY && PosY < 20)
                    {
                        posY++;
                    }
                    else if (closestBuildingRB.PosY < posY && posY > 0)
                    {
                        posY--;
                    }
                }
            }
        }
        else //Moves the unit in a direction that is determined by random
        {
            int direction = Random.Range(0, 4);

            if (direction == 0 && PosX < 19)
            {
                posX++;
            }
            else if (direction == 1 && posX > 0)
            {
                posX--;
            }
            else if (direction == 2 && posY < 19)
            {
                posY++;
            }
            else if (direction == 3 && posY > 0)
            {
                posY--;
            }
        }

    }

    public override void Combat(int type)
    {
        if (type == 0)
        {
            if (closestUnit is MeleeUnit)
            {
                MeleeUnit M = (MeleeUnit)closestUnit;
                M.Health -= Attack;
            }
            else if (closestUnit is RangedUnits)
            {
                RangedUnits R = (RangedUnits)closestUnit;
                R.Health -= Attack;
            }
            else if (closestUnit is WizzardUnits)
            {
                WizzardUnits R = (WizzardUnits)closestUnit;
                R.Health -= Attack;
            }
        }
        else if (type == 1)
        {
            if (closestBuilding is FactoryBuildings)
            {
                FactoryBuildings FB = (FactoryBuildings)closestBuilding;
                FB.Health -= Attack;
            }
            else if (closestBuilding is ResourceBuildings)
            {
                ResourceBuildings RB = (ResourceBuildings)closestBuilding;
                RB.Health -= Attack;
            }
        }
    }

    public override void CheckAttackRange(List<Unit> uni, List<buildings> build)
    {
        units = uni;
        building = build;

        closestUnit = ClosestEnemy();
        closestBuilding = ClosestBuilding();

        int enemyType;

        int xDis = 0, yDis = 0;

        int uDistance = 10000, bDistance = 10000;
        int distance;

        if (closestUnit is MeleeUnit)
        {
            MeleeUnit M = (MeleeUnit)closestUnit;
            xDis = Mathf.Abs((PosX - M.PosX) * (PosX - M.PosX));
            yDis = Mathf.Abs((PosY - M.PosY) * (PosY - M.PosY));

            uDistance = (int)Mathf.Round(Mathf.Sqrt(xDis + yDis));
        }
        else if (closestUnit is RangedUnits)
        {
            RangedUnits R = (RangedUnits)closestUnit;
            xDis = Mathf.Abs((PosX - R.PosX) * (PosX - R.PosX));
            yDis = Mathf.Abs((PosY - R.PosY) * (PosY - R.PosY));

            uDistance = (int)Mathf.Round(Mathf.Sqrt(xDis + yDis));
        }
        else if (closestUnit is WizzardUnits)
        {
            WizzardUnits R = (WizzardUnits)closestUnit;
            xDis = Mathf.Abs((PosX - R.PosX) * (PosX - R.PosX));
            yDis = Mathf.Abs((PosY - R.PosY) * (PosY - R.PosY));

            uDistance = (int)Mathf.Round(Mathf.Sqrt(xDis + yDis));
        }

        if (closestBuilding is FactoryBuildings)
        {
            FactoryBuildings FB = (FactoryBuildings)closestBuilding;
            xDis = Mathf.Abs((PosX - FB.PosX) * (PosX - FB.PosX));
            yDis = Mathf.Abs((PosY - FB.PosY) * (PosY - FB.PosY));

            bDistance = (int)Mathf.Round(Mathf.Sqrt(xDis + yDis));
        }
        else if (closestBuilding is ResourceBuildings)
        {
            ResourceBuildings RB = (ResourceBuildings)closestBuilding;
            xDis = Mathf.Abs((PosX - RB.PosX) * (PosX - RB.PosX));
            yDis = Mathf.Abs((PosY - RB.PosY) * (PosY - RB.PosY));

            bDistance = (int)Mathf.Round(Mathf.Sqrt(xDis + yDis));
        }

        if (units[0] != null)
        {
            if (uDistance < bDistance)
            {
                distance = uDistance;
                enemyType = 0;
            }
            else
            {
                distance = bDistance;
                enemyType = 1;
            }
        }
        else
        {
            distance = bDistance;
            enemyType = 1;
        }

        //Checks to see if they are below 25% health so they move rather than attacking
        if (Health > MaxHealth * 0.25)
        {
            if (distance <= AttackRange)
            {
                IsAttacking = true;
                Combat(enemyType);
            }
            else
            {
                IsAttacking = false;
                Move(enemyType);
            }
        }
        else
        {
            Move(enemyType);
        }

    }

    public override Unit ClosestEnemy()
    {

        int xDis, yDis;
        double distance;
        double temp = 0;
        Unit target = null;

        foreach (Unit u in units)
        {
            if (FactionType != u.factionType)
            {
                xDis = Mathf.Abs((PosX - u.posX) * (PosX - u.posX));
                yDis = Mathf.Abs((PosY - u.posY) * (PosY - u.posY));

                distance = Mathf.Round(Mathf.Sqrt(xDis + yDis));

                if (distance > temp)
                {
                    temp = distance;

                    temp = distance;
                    target = u;
                }
            }

        }
        return target;

    }

    public buildings ClosestBuilding()
    {
        int xDis = 0, yDis = 0;
        double distance = 1000;
        double temp = 1000;
        buildings target = null;

        foreach (buildings u in building)
        {
            if (u is FactoryBuildings)
            {
                FactoryBuildings b = (FactoryBuildings)u;
                if (factionType != b.Faction)
                {
                    xDis = Mathf.Abs((PosX - b.PosX) * (PosX - b.PosX));
                    yDis = Mathf.Abs((PosY - b.PosY) * (PosY - b.PosY));

                    distance = Mathf.Round(Mathf.Sqrt(xDis + yDis));
                }
            }
            else if (u is ResourceBuildings)
            {
                ResourceBuildings b = (ResourceBuildings)u;
                if (factionType != b.Faction)
                {
                    xDis = Mathf.Abs((PosX - b.PosX) * (PosX - b.PosX));
                    yDis = Mathf.Abs((PosY - b.PosY) * (PosY - b.PosY));

                    distance = Mathf.Round(Mathf.Sqrt(xDis + yDis));
                }
            }
            if (distance < temp)
            {
                temp = distance;
                target = u;
            }

        }
        return target;
    }

    public override bool Death()
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
    public override string ToString()
    {
        return "Snipers X" + PosX
            + " Y: " + PosY
            + "\nMax Health: " + MaxHealth
            + "\nHealth: " + Health
            + "\nSpeed: " + Speed
            + "\nAttack Damage: " + Attack
            + "\nAttack Range: " + AttackRange
            + "\nFaction: " + FactionType;
    }
}
