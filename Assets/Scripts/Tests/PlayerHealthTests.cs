using FluentAssertions;
using NUnit.Framework;
using Player;
using UnityEngine;

namespace Tests
{
    public class PlayerHealthTests : MonoBehaviour
    {
        [Test]
        public void WhenTakingDamage_AndHealthAboveZero_ThenHealthShouldBeLess()
        {
            // Arrange.
            PlayerHealth playerHealth = Create.PlayerHealth();
            int startHealth = playerHealth.CurrentHealth;

            // Act.
            playerHealth.TakeDamage(1);
            
            // Assert.
            playerHealth.CurrentHealth.Should().BeLessThan(startHealth);
        }
    }
}