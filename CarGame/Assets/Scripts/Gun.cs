using UniRx;
using UnityEngine;

namespace RaceGunners
{
    public class Gun : WeaponPresenter
    {
        [SerializeField]
        private BulletPresenter bullet;
        [SerializeField]
        private float atk;
        [SerializeField]
        private int maxBulletCount;

        public override void Setup()
        {
            Create(new Bullet(new Atk(atk)), maxBulletCount);

            weapon.AttackSubject
                .Subscribe(x => 
                {
                    BulletFactory.Create(bullet, x, transform.position, transform.rotation);
                })
                .AddTo(this);
        }
    }
}
