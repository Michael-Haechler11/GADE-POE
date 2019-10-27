using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class buildings 
{
    protected int posX;

    protected int posY;

    protected int health;

    public Faction faction;

    protected string symbol;

    public abstract bool Destruction();

    public abstract string ToString();

    public buildings(int x, int y, int hp, Faction fac, string sym)
    {
        posX = x;
        posY = y;
        health = hp;
        faction = fac;
        symbol = sym;


    }
}
