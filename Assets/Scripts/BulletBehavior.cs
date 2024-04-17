/*********************************************

    Bullet Behavior Class

*********************************************/

using Unity.Burst.CompilerServices;
using UnityEngine;

/*public class BulletBehavior : MonoBehaviour {
    Rigidbody _rb;
    float _speed;
    private bool _isTouching = false;
    public int damage;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        //_rb.AddForce(transform.forward * _speed * 10);        
    }

    void FixedUpdate() { _rb.velocity = transform.forward * _speed; }

    private void OnTriggerEnter( Collider other ) {
        if( other.CompareTag( "Enemy" ) ) {
            Debug.Log( "acertei " );
            other.GetComponent<EnemyBehavior>().Destroy();
        }
        if( other.CompareTag( "Player" ) ) {
            Debug.Log( "acertei " );
            PlayerManager.instance._playerStats.DecreaseHealth(PlayerManager.instance.weapons[1].weaponDamage);
        }
        if( other.CompareTag( "Shield" ) ) Reflect();
    }

    private void OnTriggerExit( Collider other ) { if( _isTouching ) _isTouching = false; }
    
    public void SetSpeed(float speed = 20) { this._speed = speed; }

    private void Kill(Collision collision) {
        if ( collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") ) {
            Destroy(collision.gameObject);
        }
    }

    private void Reflect() => transform.rotation *= Quaternion.Euler(0 , 180 , 0);

}*/
