using UnityEngine;
using UniRx;
using System;

namespace RaceGunners
{
    public class PlayerInput : MonoBehaviour
    {
        private Subject<Vector2> moveSubject = new Subject<Vector2>();
        private Subject<Unit> attackSubject = new Subject<Unit>();

        public IObservable<Vector2> MoveSubject => moveSubject;
        public IObservable<Unit> AttackSubject => attackSubject;

        private void Update()
        {
            CheckInputVector();
            CheckAttack();
        }

        private void CheckInputVector()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector2 moveVector = new Vector2(x, y);

            if (moveVector == Vector2.zero) return;
            moveSubject.OnNext(moveVector);
        }
        private void CheckAttack()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackSubject.OnNext(Unit.Default);
            }
        }

        private void OnDestroy()
        {
            moveSubject.Dispose();
            attackSubject.Dispose();
        }
    }
}
