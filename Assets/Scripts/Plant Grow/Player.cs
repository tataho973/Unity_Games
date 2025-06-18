using LTX.Singletons;

namespace Plant_Grow
{
    public class Player : MonoSingleton<Player>
    {
        public Inventory Inventory { get; private set; }

        protected override void Awake()
        {
            Inventory = new Inventory();
        }
    }
}