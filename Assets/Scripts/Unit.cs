using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit
{
    public string name;
    public int posX, posY;
    public int health;
    public int maxHealth;
    public int speed;
    public int attack, attackRange;
    public string symbol;
    public Faction factionType;
    public bool isAttacking;


    public Unit(string n, int x, int y, int hp, int sp, int att, int attRange, string sym, Faction faction, bool isAtt)
    {
        name = n;
        posX = x;
        posY = y;
        health = hp;
        speed = sp;
        attack = att;
        attackRange = attRange;
        symbol = sym;
        factionType = faction;
        isAttacking = isAtt;

        maxHealth = hp;
    }



    public abstract void Move(int type);
    public abstract void Combat(int type);
    public abstract void CheckAttackRange(List<Unit> uni, List<buildings> build);
    public abstract Unit ClosestEnemy();
    public abstract bool Death();
    public abstract override string ToString();


}
