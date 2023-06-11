using UniRx;
using UnityEngine;

namespace RaceGunners
{
    public class PlayerUI : MonoBehaviour
    {
        public void Setup(Car car)
        {
            car.DamageEvent
                .Subscribe(x =>
                {
                    Debug.Log(x.hp);
                })
                .AddTo(this);
        }
    }
}
