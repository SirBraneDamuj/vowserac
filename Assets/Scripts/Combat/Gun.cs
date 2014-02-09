using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

  public bool canShoot = true;
  public GameObject bulletPrefab;
  public float shotSpeed = 25.0f;
  public float rateOfFire = 0.5f; //seconds between shot
  private float shotTimer = 0.0f;
  
  private Movement movement;
	
  void Start() {
    movement = GetComponent<Movement>();
  }
	
	void Update () {
    doShooting();
	}
  
  private void doShooting() {
    if(shotTimer <= 0.0f && Input.GetButtonDown("Fire1")) {
      Vector3 bulletPosition = transform.position;
      bulletPosition.x += movement.moveDirection * ((BoxCollider2D)collider2D).size.x / 2;
      Bullet b = (Instantiate(bulletPrefab, bulletPosition, Quaternion.identity) as GameObject).GetComponent<Bullet>();
      b.speed = movement.moveDirection * (shotSpeed + movement.velocity.x);
      shotTimer = rateOfFire;
    } else if(shotTimer > 0.0f) {
      shotTimer -= Time.deltaTime;
    }
  }
}
