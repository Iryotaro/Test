using UnityEngine;

namespace RaceGunners
{
    public abstract class WeaponPresenter : MonoBehaviour
    {
        public Weapon weapon { get; private set; }

        public void Create(Bullet bullet, int maxBulletCount)
        {
            weapon = new Weapon(bullet, maxBulletCount);
        }
        private void OnDestroy()
        {
            weapon.Delete();
        }

        public abstract void Setup();
    }
}
