public interface ICharacter
{
    int HP { get; set; }
    int Attack { get; set; }
    float Speed { get; set; }
    float AtkSpeed { get; set; }
    bool isDead { get; set; }

    void Damaged(int damage);
}