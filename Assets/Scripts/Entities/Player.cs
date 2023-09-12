using TMPro;

public class Player : ICharacter
{
    public float HP { get; set; }
    public float Attack { get; set; }
    public float Speed { get; set; }
    public float AtkSpeed { get; set; }
    public bool isDead { get; set; }


    public Player(int hp, int attack, float speed, float atkspeed)
    {
        HP = hp;
        Attack = attack;
        Speed = speed;
        AtkSpeed = atkspeed;
        isDead = false;
    }

    public void Damaged(float damage)
    {
        HP -= damage;

        if (HP < 0)
        {
            HP = 0;
            isDead = true;
        }
    }
}