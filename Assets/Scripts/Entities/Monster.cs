using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monster : ICharacter
{
    public int HP { get; set; }
    public int Attack { get; set; }
    public float Speed { get; set; }
    public float AtkSpeed { get; set; }
    public int Exp;
    public bool isDead { get; set; }

    public Monster(int hp, int attack, float speed, float atkspeed, int exp)
    {
        HP = hp;
        Attack = attack;
        Speed = speed;
        AtkSpeed = atkspeed;
        Exp = exp;
        isDead = false;
    }

    public void Damaged(int damage)
    {
        HP -= damage;

        if (HP < 0)
        {
            HP = 0;
            isDead = true;
        }
    }
}