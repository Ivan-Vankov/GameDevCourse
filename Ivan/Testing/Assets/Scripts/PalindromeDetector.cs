using System;

public class PalindromeDetector {
	public static bool IsPalindrome(string str) {
		char[] strReverse = str.ToCharArray();
		Array.Reverse(strReverse);
		return str.Equals(new string(strReverse));
	}
}
