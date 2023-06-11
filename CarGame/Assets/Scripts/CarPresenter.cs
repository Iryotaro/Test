using UnityEngine;

namespace RaceGunners
{
    public class CarPresenter : MonoBehaviour
    {
        //���i��Id�ŊǗ�
        //����͂��邢���炢��
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
