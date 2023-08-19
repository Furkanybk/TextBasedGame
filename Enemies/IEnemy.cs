namespace TextBasedGame.Enemies
{
    public interface IEnemy
    {
        int Health { get; set; }
        int Chance { get; set; }
        void Attack();
        void GetHit(int damage);
    }
}