using UnityEngine;
using System.Collections;

public class Letter : MonoBehaviour {

  public string letter;

	void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      other.SendMessage("onLetterPickup", letter);
    }
  }
}
