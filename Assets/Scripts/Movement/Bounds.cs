using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      other.gameObject.SendMessage("Reset");
    }
  }
}
