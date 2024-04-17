using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class MeleeWeaponBehavior : MonoBehaviour {
    float _radius;
    Vector3 _dir;
    Vector3 _position;
    Vector3 _enemypos;
    GameObject _enemy;
    public float trashhold = 0.7f;
    bool _isTouching = false;

    /// <summary>
    /// Receive the direction where the player is looking at and the position of the enemy.
    /// </summary>
    /// <param name="mouseDirection"></param>
    /// <param name="playerPosition"></param>
    public void Attack( Vector2 mouseDirection , Vector3 playerPosition ) {
        _position = playerPosition;
        // Normalizing the "forward vector"
        _dir = Vector3.Normalize( new Vector3( mouseDirection.x , 1 , mouseDirection.y ) - _position );

        KillEnemy( _isTouching );
    }


    private void Update() {
        // Updates the range of the attack if it was modified.
        _radius = PlayerManager.instance.weapons[ 0 ].radius;
        this.GetComponent<SphereCollider>().radius = _radius;
    }

    private void OnTriggerEnter( Collider other ) {
        // If an enemy is in the range of melee atack imputs its position, gameobject, and set its touching true.
        if( other.CompareTag( "Enemy" ) ) {
            Debug.Log( "Dentro" );
            _isTouching = true;
            _enemy = other.gameObject;
            _enemypos = other.transform.position;
        }
    }
    // If the enemy get out of range it nulls its values and set the bool false.
    private void OnTriggerExit( Collider other ) { _isTouching = false; Debug.Log( "Fora" ); _enemy = null; _enemypos = Vector3.zero; }

    private void KillEnemy( bool isOnRange ) {
        if( !isOnRange )
            return;

        if( Vector3.Dot( _dir , Vector3.Normalize( _enemypos - _position ) ) > trashhold ) {
            Debug.Log( "O inimigo está na frente" );
            _enemy.GetComponent<EnemyBehavior>().Destroy();
        }
    }

}
*/