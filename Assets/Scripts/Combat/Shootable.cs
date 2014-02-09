using UnityEngine;
using System.Collections;

public class Shootable : MonoBehaviour {

  public int health = 1;
  
  void onBulletHit() {
    health -= 1;
    if(health == 0) {
      Destroy(gameObject);
    }
  }
}
