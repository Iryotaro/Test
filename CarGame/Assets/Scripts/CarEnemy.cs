using UniRx;
using UnityEngine;

namespace RaceGunners
{
    public class CarEnemy : CarPresenter, IReceiveAttack
    {
        [SerializeField]
        private float maxHp;

        private void Start()
        {
            Create(new HP(maxHp), null);

            car.DamageEvent
                .Subscribe(x => Debug.Log(x.hp))
                .AddTo(this);
        }

        public void Damage(Atk atk)
        {
            car.Damage(atk);
        }
    }
}
