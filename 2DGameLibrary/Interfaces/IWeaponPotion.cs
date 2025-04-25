namespace GameLibrary.Interfaces;

public interface IWeaponPotion : IPotion
{
    IWeapon? UsePotion(IWeapon target);
}
