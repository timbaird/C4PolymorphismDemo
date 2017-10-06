using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoPolymorhphism
{
    public class Fighter
    {
        public string vName { set; get; }
        public int vHitpoints { set; get; }
        Attack vAttack;

        public Fighter(string pName, int pHits, string pAttackType)
        {
            vName = pName;
            vHitpoints = pHits;

            if (pAttackType == "kick")
                vAttack = new Kick(10);
            else if (pAttackType == "punch")
                vAttack = new Punch(10);
            else if (pAttackType == "dagger")
                vAttack = new Dagger(10);
            else if (pAttackType == "bow")
                vAttack = new Bow(10);
        }

        public void Attack(Fighter pTarget)
        {
            vHitpoints -= vAttack.MakeAttack(pTarget);
        }

    }


    public class Attack
    {
        protected int vBaseDamage;

        public Attack(int pBasdeDam)
        {
            vBaseDamage = pBasdeDam;
        }

        public virtual int MakeAttack(Fighter pTarget)
        {
            throw new NotImplementedException();
        }
    }

    public class MeleeAttack : Attack
    {
        public MeleeAttack(int pBaseDam) : base(pBaseDam) { }
    }

    public class WeaponAttack : Attack
    {
        public WeaponAttack(int pBaseDam) : base(pBaseDam) { }
    }

    public class Punch:MeleeAttack
    {
        public Punch(int pBaseDam) : base(pBaseDam) { }
        public override int MakeAttack(Fighter pTarget)
        {
            // has 50% chance of doing base dam to target
            // has 25% chance of doing nothing
            // has 25% chance of doing 0.5 * base dam to self

            MessageBox.Show("You throw a haymaker");

            var vRandom = new Random();
            var vResult = vRandom.Next(0, 3);

            if (vResult < 2)
            {
                // has 50% chance of doing base dame to target
                pTarget.vHitpoints -= vBaseDamage;
                return 0; // 0 self damage done
            }
            else if (vResult == 2)
            {
                // has 25% chance of doing nothing
                return 0;
            }
            else
            {
                // has 25% chance of doing 0.5 * base dam to self
                return (Int32)0.5 * vBaseDamage;
            }
        }

    }

    public class Kick:MeleeAttack
    {
        public Kick(int pBaseDam) : base(pBaseDam) { }
        public override int MakeAttack(Fighter pTarget)
        {
            // has 25% chance of doing 3 * base dam to target
            // has 50% chance of doing nothing
            // has 25% chance of doing base dam to self

            MessageBox.Show("You take a flying kick at his head");

            var vRandom = new Random();
            var vResult = vRandom.Next(0, 3);

            if (vResult < 2)
            {
                return 0; // has 50% chance of doing nothing
            }
            else if (vResult == 2)
            {
                // has 25 % chance of doing 3 * base dam to target
                pTarget.vHitpoints -= 3 * vBaseDamage;
                return 0;
            }
            else
            {
                // has 25% chance of doing base dam to self
                return vBaseDamage;
            }
        }
    }

    public class Bow : MeleeAttack
    {
        public Bow(int pBaseDam) : base(pBaseDam) { }
        public override int MakeAttack(Fighter pTarget)
        {
            // has 25% chance of doing 3 * base dam to target
            // has 50% chance of doing nothing
            // has 25% chance of doing base dam to self

            MessageBox.Show("You loose an arrow at his heart");

            var vRandom = new Random();
            var vResult = vRandom.Next(0, 3);

            if (vResult < 2)
            {
                return 0; // has 50% chance of doing nothing
            }
            else if (vResult == 2)
            {
                // has 25 % chance of doing 3 * base dam to target
                pTarget.vHitpoints -= 3 * vBaseDamage;
                return 0;
            }
            else
            {
                // has 25% chance of doing base dam to self
                return vBaseDamage;
            }
        }
    }

    public class Dagger : MeleeAttack
    {
        public Dagger(int pBaseDam) : base(pBaseDam) { }
        public override int MakeAttack(Fighter pTarget)
        {
  
            MessageBox.Show("You slide a dagger into his ribs");

            var vRandom = new Random();
            var vResult = vRandom.Next(0, 1);

            if (vResult < 2)
            {
                return 0; // has 50% chance of doing nothing
            }
            else if (vResult == 2)
            {
                // has 25 % chance of doing 3 * base dam to target
                pTarget.vHitpoints -= 3 * vBaseDamage;
                return 0;
            }
            else
            {
                // has 25% chance of doing base dam to self
                return vBaseDamage;
            }
        }
    }
}
