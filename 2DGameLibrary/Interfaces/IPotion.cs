using GameLibrary.Enums;

namespace GameLibrary.Interfaces
{
    public interface IPotion : IItem
    {
        public int MaxDoses { get; init; }

        public int CurrentDoses { get; set; }

        public PotionTypes PotionType { get; init; }
    }
}
