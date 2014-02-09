using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

  public float speed = 0.0f;
  public float live = 2.0f;

	// Use this for initialization
	void Start () {
    rigidbody2D.
    rigidbody2D.velocity = new Vector3(speed, 0F, 0F);
	}
	
	// Update is called once per frame
	void Update () {
    live -= Time.deltaTime;
    if(live <= 0.0f) {
      DestroySelf();
    }
	}
  
  void OnTriggerEnter2D(Collider2D coll) {
    GameObject other = coll.gameObject;
    if(other.tag != "Player") {
      other.SendMessage("onBulletHit", null, SendMessageOptions.DontRequireReceiver);
      DestroySelf();
    }
  }
  
  void DestroySelf() {
    Destroy(gameObject);
  }
}
