using NUnit.Framework;

namespace Tests {
	public class PalindromeTest {

        // A simple Edit Mode test
		[Test]
		public void ababaIsAPalindrome() {
			// Arrange
			string palindrome = "ababa";
			// Act
			bool actualResult = PalindromeDetector.IsPalindrome(palindrome);
			// Assert
			Assert.IsTrue(actualResult, "Incorrectly predicted palindrome");
		}
        
        [Test]
        public void doesNotBreakOnNull() {
            string palindrome = null;
            Assert.DoesNotThrow(() => PalindromeDetector.IsPalindrome(palindrome),
                "Threw NullPointerException");
        }
    }
}
