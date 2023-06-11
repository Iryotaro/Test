using UnityEngine;

namespace RaceGunners
{
    public static class BulletFactory
    {
        public static void Create(BulletPresenter bulletPresenter, Bullet bullet, Vector2 position, Quaternion rotation)
        {
            BulletPresenter newBullet = GameObject.Instantiate(bulletPresenter, position, rotation);
            newBullet.Setup(bullet);
        }
    }
}
