using UnityEngine;

namespace RaceGunners
{
    public class CarPresenter : MonoBehaviour
    {
        //•’i‚ÍId‚ÅŠÇ—
        //¡‰ñ‚Í‚¾‚é‚¢‚©‚ç‚¢‚¢
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
