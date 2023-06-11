using UnityEngine;

namespace RaceGunners
{
    public class CarPresenter : MonoBehaviour
    {
        //普段はIdで管理
        //今回はだるいからいい
        protected Car car;

        protected void Create(HP hp, Weapon weapon)
        {
            car = new Car(hp, weapon);
        }
        private void OnDestroy()
        {
            car.Delete();
        }
    }
}
