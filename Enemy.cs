namespace TextBasedGame
{
    public class Enemy
    {
        public int Health;
        public int Attack;
        public int Defence;

        public Enemy()
        {
            Health = 100;
            Attack = 15;
            Defence = 5;
        }
        public int GetHit(int damage)
        {
            damage -= Defence;
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
            return Health;
        }
    }
}
