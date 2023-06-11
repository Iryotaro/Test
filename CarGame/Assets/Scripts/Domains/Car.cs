using System;
using UniRx;

namespace RaceGunners
{
    public sealed class Car
    {
        private string id { get; }
        public HP hp { get; private set; }
        public Weapon weapon { get; private set; }

        private Subject<HP> damageEvent = new Subject<HP>();
        public IObservable<HP> DamageEvent => damageEvent;

        public Car(HP hp, Weapon weapon)
        {
            id = Guid.NewGuid().ToString();
            this.hp = hp;
            this.weapon = weapon;
        }

        public void Damage(Atk atk)
        {
            hp = hp.Damage(atk);
            damageEvent.OnNext(hp);
        }
        public void Recover(HP recoverHp)
        {
            hp = hp.Recover(recoverHp);
        }

        public void Delete()
        {
            damageEvent.Dispose();
        }
    }
}
