using UniRx;
using UnityEngine;

namespace RaceGunners
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerUI))]
    public class CarPlayer : CarPresenter, IReceiveAttack
    {
        [SerializeField]
        private float maxHp;

        [SerializeField]
        private WeaponPresenter weaponPresenter;

        private PlayerInput playerInput;

        private void Start()
        {
            weaponPresenter.Setup();
            Create(new HP(maxHp), weaponPresenter.weapon);

            playerInput = GetComponent<PlayerInput>();
            GetComponent<PlayerUI>().Setup(car);

            playerInput.MoveSubject
                .Subscribe(x => Move(x))
                .AddTo(this);

            playerInput.AttackSubject
                .Subscribe(_ => Attack())
                .AddTo(this);
        }

        public void Damage()
        {
            car.Damage(new Atk(4));
        }
        public void Attack()
        {
            if (!car.weapon.IsAllowedToAttack()) Debug.Log("íeÇÇ¬Ç©Ç¢Ç´Ç¡ÇΩÇºÇ¢ÅI");
            else car.weapon.Attack();
        }
        private void Move(Vector2 moveVector)
        {
            //âΩÇ©ÇÃèàóù
            transform.Translate(moveVector * Time.deltaTime);
        }

        public void Damage(Atk atk)
        {
            car.Damage(atk);
        }
    }
}
