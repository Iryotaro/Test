using UnityEngine;
using UniRx;
using System;

namespace RaceGunners
{
    public sealed class Weapon
    {
        public Bullet bullet { get; }
        private int maxBulletCount { get; }
        public int ammoCount { get; private set; }

        private Subject<Bullet> attackSubject = new Subject<Bullet>();
        public IObservable<Bullet> AttackSubject => attackSubject;

        public Weapon(Bullet bullet, int maxBulletCount)
        {
            this.bullet = bullet;
            this.maxBulletCount = maxBulletCount;
            ammoCount = maxBulletCount;
        }

        public void Attack()
        {
            UseAmmo();
            attackSubject.OnNext(bullet);
        }
        private Bullet UseAmmo()
        {
            if (!IsAllowedToAttack()) Debug.LogError("’e–ò‚ÌŽg—p‚ª‹–‰Â‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");

            ammoCount--;
            return bullet;
        }
        public void AddAmmo()
        {
            if (ammoCount == maxBulletCount) return;
            ammoCount++;
        }
        public bool IsAllowedToAttack()
        {
            if (ammoCount == 0) return false;
            return true;
        }

        public void Delete()
        {
            attackSubject.Dispose();
        }
    }
}
