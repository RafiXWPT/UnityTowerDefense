using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySQLDatabaseManager : MonoBehaviour {
	private readonly string _secret = "ELEMENTALTDSECRETKEY";

	public void PostScore(string name, int score)
	{
		var www = new WWW (DatabaseConnectionUtilities.CreateUrl(name, score, _secret));
		if (www.error != null) {
			print ("There was error: " + www.error);
		}
	}
}
