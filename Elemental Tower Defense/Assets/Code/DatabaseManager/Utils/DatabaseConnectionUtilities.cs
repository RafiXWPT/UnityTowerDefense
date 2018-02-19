using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DatabaseConnectionUtilities {

	private static readonly string _addToLeaderboardUrl = "http://rpalej.pl/ELETD/ELETD.php?";

	public static string CreateUrl(string name, int score, string secret)
	{
		string requestHash = ComputeMD5 (name + score + secret);
		return _addToLeaderboardUrl + "name=" + name + "&score=" + score + "&hash=" + requestHash;
	}

	public static string ComputeMD5(string value)
	{
		var bytes = new System.Text.UTF8Encoding ().GetBytes (value);
		var hashBytes = new System.Security.Cryptography.MD5CryptoServiceProvider ().ComputeHash (bytes);
		var hashString = string.Empty;
		for (var i = 0; i < hashBytes.Length; i++) {
			hashString += System.Convert.ToString (hashBytes [i], 16).PadLeft (2, '0');
		}

		return hashString.PadLeft (32, '0');
	}
}
