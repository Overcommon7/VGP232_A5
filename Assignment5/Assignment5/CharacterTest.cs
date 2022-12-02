using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class CharacterTest
    {
        Character character;
        [SetUp]
        public void SetUp()
        {
            character = new Character("TestCharacter", RaceCategory.Human, 10);
        }

        [TearDown]
        public void TearDown()
        {
            character = null;
        }

        [Test]
        public void Character_Test_Damange()
        {
            int damage = 5;
            int remainingHealth = character.Health - damage;
            character.TakeDamage(damage);
            Assert.AreEqual(character.Health, remainingHealth);
        }

        [Test]
        public void Character_Test_Death()
        {
            character.Health = character.MaxHealth;
            character.IsAlive = true;

            character.RestoreHealth(character.Health);
            Assert.AreEqual(character.IsAlive, false);
        }

        [Test]
        public void Character_Test_RestoreHealth()
        {
            character.Health = (int)(character.MaxHealth * 0.5);
            int totalHealth = character.Health + (int)(character.Health * 0.25);
            character.RestoreHealth((int)(character.Health * 0.25));
            Assert.AreEqual(character.Health, totalHealth);
        }

        public void Character_Test_Revive()
        {
            character.Health = 0;
            character.IsAlive = false;

            character.RestoreHealth(character.MaxHealth);
            Assert.AreEqual(character.IsAlive, true);
        }
    }
}
