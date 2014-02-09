using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D other) {
    other.gameObject.SendMessage("onCollectedItem");
    Destroy(gameObject);
  }
	
}
