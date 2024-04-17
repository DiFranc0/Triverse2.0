/*********************************************

    Player Manager Class

    There is a public static PlayerStats instance called 'instance'
    that can be accessed through all script using 'PlayerManager.instance'

*********************************************/

using UnityEditor;
using UnityEngine;

/*public class PlayerManager : MonoBehaviour {
     
    [Header("Camera")]
    public Camera cam;

    [Header("Player Status")]
    public PlayerStats _playerStats;                     // Player Stats aidna não tem um inicializador pelo inspector

    [Header("Weapons")]
    public Weapon[] weapons = new Weapon[3];        //[0] Melee - [1] Ranged - [2] Shield

    private float _angleRotation;
    private Vector2 _mousePosition;
    private Vector3 _movement;
    private CharacterController _characterController;
    private LayerMask _layerMask;

    GameObject shield;

    public static PlayerManager instance;

    private void Awake() {
        instance = this;
        _playerStats = new PlayerStats();
        _layerMask = LayerMask.GetMask("Floor");
        DontDestroyOnLoad(instance);
    }

    private void OnEnable() {
        _characterController = GetComponent<CharacterController>();
        shield = Instantiate(weapons[2].weaponPrefab , weapons[2].weaponSpawn);         //[0] Melee - [1] Ranged - [2] Shield
        shield.SetActive(false);
    }

    void Update() {
        _movement = MovementInput();
        MouseRotation();
        if ( Input.GetButtonDown("Fire1") ) { Attack(); }
        if ( Input.GetButtonDown("ChangeRight") ) { ChangeWeapon(1); }
        if ( Input.GetButtonDown("ChangeLeft") ) { ChangeWeapon(-1); }
        if ( _playerStats.GetAttackType() == AttackType.Shield ) { shield.SetActive(true); }
        else { shield.SetActive(false); }
    }

    private void FixedUpdate() => MovementOutput(); 


    #region Methods

    /// <summary>
    ///  Inputs the mouse position and rotates the player towards it.
    /// </summary>
    void MouseRotation() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if ( Physics.Raycast(ray , out hit , Mathf.Infinity , _layerMask) ) {
            _angleRotation = Mathf.Atan2(hit.point.x - transform.position.x , hit.point.z - transform.position.z) * Mathf.Rad2Deg;
            _mousePosition = new Vector2( hit.point.x, hit.point.z);
        }
    }


    /// <summary>
    /// It takes the player´s input and movement speed.
    /// </summary>
    /// <returns>
    ///     Returns a normalized Vector3 multiplied by the movement speed.
    /// </returns>
    Vector3 MovementInput() { return new Vector3(Input.GetAxisRaw("Horizontal") , 0f , Input.GetAxisRaw("Vertical")).normalized * _playerStats.moveSpeed; }


    /// <summary>
    ///  It output the players movement feedback.
    /// </summary>
    void MovementOutput() {
        _characterController.Move(_movement * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation , Quaternion.Euler(0 , _angleRotation , 0) , .2f);
    }

    /// <summary>
    /// Deals with all attack beahavior.
    /// </summary>
    void Attack() {
        if ( _playerStats.GetAttackType() == AttackType.Ranged ) {
            GameObject bullet = Instantiate(weapons[1].weaponPrefab , weapons[1].weaponSpawn.position , Quaternion.Euler(0 , _angleRotation , 0));          //[0] Melee - [1] Ranged - [2] Shield
            bullet.GetComponent<BulletBehavior>().SetSpeed(weapons[1].weaponSpeed);         //[0] Melee - [1] Ranged - [2] Shield
            Destroy(bullet , 5);
        }

        if (_playerStats.GetAttackType() == AttackType.Melee) {
            // Pass mouse Vector2 to make a dot product at melee weapon script.
            GameObject MeleeAtack = weapons[0].weaponSpawn.gameObject;
            MeleeAtack.GetComponent<MeleeWeaponBehavior>().Attack(_mousePosition, transform.position);

        }
    }

    /// <summary>
    /// Deals with all changinbg weapon behaviors
    /// </summary>
    /// <param name="i"></param>
    void ChangeWeapon(int i) {
        if ( i < 0 ) {
            switch ( _playerStats.GetAttackType() ) {
                case AttackType.Melee:
                _playerStats.SetAttackType(AttackType.Shield);
                Debug.Log("Shield");
                break;

                case AttackType.Shield:
                _playerStats.SetAttackType(AttackType.Ranged);
                Debug.Log("Ranged");
                break;

                case AttackType.Ranged:
                _playerStats.SetAttackType(AttackType.Melee);
                Debug.Log("Melee");
                break;
            }
        }

        if ( i > 0 ) {
            switch ( _playerStats.GetAttackType() ) {
                case AttackType.Melee:
                _playerStats.SetAttackType(AttackType.Ranged);
                Debug.Log("Ranged");
                break;
                case AttackType.Ranged:
                _playerStats.SetAttackType(AttackType.Shield);
                Debug.Log("Shield");
                break;
                case AttackType.Shield:
                _playerStats.SetAttackType(AttackType.Melee);
                Debug.Log("Melee");
                break;
            }
        }
    }

    /// <summary>
    /// Class to set the behavior of player death.
    /// </summary>
    void Desstroy() {
        Debug.Log( " Você Morreu!" );
    }


    #endregion

    /// <summary>
    /// Class to show in editor the melee range
    /// </summary>
    private void OnDrawGizmos() => Handles.DrawWireDisc(transform.position, Vector3.up, weapons[0].radius);
}

public enum AttackType {
    Melee = 0,
    Ranged = 1,
    Shield = 2,
}
    */