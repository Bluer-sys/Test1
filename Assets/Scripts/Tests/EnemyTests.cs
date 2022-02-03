using Enemy;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Services.Random;
using UnityEngine;

namespace Tests
{
    public class EnemyTests
    {
        [Test]
        public void WhenSettingNewPosition_AndNewPositionSet_ThenPositionShouldBeScreenArea()
        {
            // Arrange.
            EnemyMove enemyMove = Create.EnemyMove();
            Camera mainCamera = new GameObject().AddComponent<Camera>();
            Camera cameraInstance = Object.Instantiate(mainCamera);

            Vector2 leftBorder = cameraInstance.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 rightBorder = cameraInstance.ViewportToWorldPoint(new Vector2(1, 1));

            enemyMove.RandomService = Substitute.For<IRandomService>();

            // Act.
            enemyMove.SetNewPosition();
            
            // Assert.
            enemyMove.MovePosition.x.Should().BeInRange(leftBorder.x+1, rightBorder.x-1);
            enemyMove.MovePosition.y.Should().BeInRange(leftBorder.y, rightBorder.y);
        }
    }
}