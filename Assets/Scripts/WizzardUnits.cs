using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizzardUnits : Unit
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

    public WizzardUnits(string n, int x, int y, Faction faction, int hp, int sp, int att, int attRange, string sym, bool isAtt)
    : base(n, x, y, hp, sp, att, attRange, sym, faction, isAtt)

    {


    }
    public override void Move(int type)
    {
        //Moves towards closest enemey
        if (Health > MaxHealth * 0.5)
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
            }

        }
        else //Moves the unit in a direction that is determined by random
        {
            int direction = Random.Range (0, 4);

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
    public override void Combat(int type) //combat method for the wizard to attack the 
    {
        foreach (Unit u in units)
        {
            if (u is MeleeUnit)
            {
                MeleeUnit M = (MeleeUnit)u;

                if (M.PosX == PosX - 1 && M.PosY == PosY - 1)
                {
                    M.Health -= 1;
                }
                else if (M.PosX == PosX && M.PosY == PosY - 1)
                {
                    M.Health -= 1;
                }
                else if (M.PosX == PosX + 1 && M.PosY == PosY - 1)
                {
                    M.Health -= 1;
                }
                else if (M.PosX == PosX - 1 && M.PosY == PosY)
                {
                    M.Health -= 1;
                }
                else if (M.PosX == PosX + 1 && M.PosY == PosY)
                {
                    M.Health -= 1;
                }
                else if (M.PosX == PosX - 1 && M.PosY == PosY + 1)
                {
                    M.Health -= 1;
                }
                else if (M.PosX == PosX && M.PosY == PosY + 1)
                {
                    M.Health -= 1;
                }
                else if (M.PosX == PosX + 1 && M.PosY == PosY + 1)
                {
                    M.Health -= 1;
                }
            }
            else if (u is RangedUnits)
            {
                RangedUnits R = (RangedUnits)u;

                if (R.PosX == PosX - 1 && R.PosY == PosY - 1)
                {
                    R.Health -= 1;
                }
                else if (R.PosX == PosX && R.PosY == PosY - 1)
                {
                    R.Health -= 1;
                }
                else if (R.PosX == PosX + 1 && R.PosY == PosY - 1)
                {
                    R.Health -= 1;
                }
                else if (R.PosX == PosX - 1 && R.PosY == PosY)
                {
                    R.Health -= 1;
                }
                else if (R.PosX == PosX + 1 && R.PosY == PosY)
                {
                    R.Health -= 1;
                }
                else if (R.PosX == PosX - 1 && R.PosY == PosY + 1)
                {
                    R.Health -= 1;
                }
                else if (R.PosX == PosX && R.PosY == PosY + 1)
                {
                    R.Health -= 1;
                }
                else if (R.PosX == PosX + 1 && R.PosY == PosY + 1)
                {
                    R.Health -= 1;
                }
            }
        }

    }
    public override void CheckAttackRange(List<Unit> uni, List<buildings> build)
    {
        units = uni;
        building = build;

        closestUnit = ClosestEnemy();

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
        if (Health > MaxHealth * 0.5)
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
        double temp = 1000;
        Unit target = null;

        foreach (Unit u in units)
        {
            if (FactionType != u.factionType)
            {
                xDis = Mathf.Abs((PosX - u.posX) * (PosX - u.posX));
                yDis = Mathf.Abs((PosY - u.posY) * (PosY - u.posY));

                distance = Mathf.Round(Mathf.Sqrt(xDis + yDis));

                if (distance < temp)
                {

                    temp = distance;
                    target = u;
                }
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
        return name + ": X" + PosX
            + " Y: " + PosY
            + "\nMax Health: " + MaxHealth
            + "\nHealth: " + Health
            + "\nSpeed: " + Speed
            + "\nAttack Damage: " + Attack
            + "\nAttack Range: " + AttackRange
            + "\nFaction: " + FactionType;
    }
}
