public interface ICharacter
{
    float HP { get; set; }
    float Attack { get; set; }
    float Speed { get; set; }
    float AtkSpeed { get; set; }
    bool isDead { get; set; }

    void Damaged(float damage);
}