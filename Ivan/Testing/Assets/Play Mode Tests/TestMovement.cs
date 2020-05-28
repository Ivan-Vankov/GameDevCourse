using System.Collections;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
	public class TestMovement {

		private GameObject player;
		private Movement movement;

        // Since the Arrange section of TestMovementUp and TestMovementDown
        // is the same we can use the SetUp attribute to move
        // the arranging logic into one method.
        [SetUp]
		public void SetUp() {
			player = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
			movement = player.AddComponent<Movement>();
		}

        // You should always garbage collect in Play Mode Tests.
        // If not then assets from previous tests can stay 
        // and interfere with future tests.
        [TearDown]
        public void TearDown() {
            GameObject.Destroy(player);
        }

        [UnityTest]
		public IEnumerator TestMovementUp() {
            // Get a mock of ICustomInput
            ICustomInput customInput = Substitute.For<ICustomInput>();

            // Mock the GetVerticalInput method to always return 1
            customInput.GetVerticalInput().Returns(1);

            // Inject the mocked customInput into the object that we are testing 
            movement.customInput = customInput;
            
            // Wait a bit so that the Update method inside "movement"
            // can execute a few times
			yield return new WaitForSeconds(0.5f);

            // Assert thet we have actually moved up
			Assert.IsTrue(player.transform.position.y > 0, "Did not move up");

            // Verify that GetVerticalInput was actually called
            customInput.Received().GetVerticalInput();
        }

		[UnityTest]
		public IEnumerator TestMovementDown() {
			ICustomInput customInput = Substitute.For<ICustomInput>();
			customInput.GetVerticalInput().Returns(-1);
			movement.customInput = customInput;
			
			yield return new WaitForSeconds(0.5f);

			Assert.IsTrue(player.transform.position.y < 0, "Did not move down");
            customInput.Received().GetVerticalInput();
        }
	}
}
