using UnityEngine;

namespace RaceGunners
{
    public sealed class HP
    {
        public float hp { get; }
        private float maxHp { get; }

        public HP(float maxHp)
        {
            if (maxHp < 0) Debug.LogError("0ˆÈ‰º‚Í‘Î‰ž‚µ‚Ä‚¢‚Ü‚¹‚ñ");

            this.maxHp = maxHp;
            hp = maxHp;
        }

        public HP Damage(Atk atk)
        {
            if (hp - atk.value < 0) return new HP(0);

            return new HP(hp - atk.value);
        }
        public HP Recover(HP recoverHp)
        {
            return new HP(hp + recoverHp.hp);
        }
        public HP Reset()
        {
            return new HP(maxHp);
        }
    }
}
