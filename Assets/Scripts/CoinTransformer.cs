using UnityEngine;
using System.Collections;

public class CoinTransformer : MonoBehaviour {

	public GameObject coin;
	//public Transform CoinAtributes;
	void OnBecameInvisible()
	{
		DestroyObject (coin);
	}

}
