using UnityEngine;
using System.Collections;

public class Harmful : MonoBehaviour {

  public int damage = 1;
  
  void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == "Player") {
      other.gameObject.SendMessage("onDamage");
    }
  }
}
