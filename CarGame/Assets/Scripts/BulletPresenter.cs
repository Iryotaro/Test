using UniRx.Triggers;
using UniRx;
using UnityEngine;

namespace RaceGunners
{
    [RequireComponent(typeof(Collision2D))]
    public class BulletPresenter : MonoBehaviour
    {
        public void Setup(Bullet bullet)
        {
            this.OnTriggerEnter2DAsObservable()
                .Subscribe(x =>
                {
                    if (x.TryGetComponent(out IReceiveAttack receiveAttack))
                    {
                        receiveAttack.Damage(bullet.atk);
                    }
                })
                .AddTo(this);
        }

        private void Update()
        {
            transform.Translate(transform.up * 5 * Time.deltaTime);
        }
    }
}
