using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradesScript : MonoBehaviour, MMEventListener<MMGameEvent>
{
    public ProjectileWeapon _myWeapon;
    public MeleeWeapon _meleeWeapon;
    public ShieldWeaponBehavior _shieldWeapon;
    public GameObject _upgradeScreen;
    public static bool _shieldUpgraded = false;
    public static bool _tiroUpgraded = false;
    public static bool _meleeUpgraded = false;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Initialization();
        _shieldUpgraded = false;
        _meleeUpgraded = false;
        _tiroUpgraded = false;

    }

    private void OnEnable()
    {
        this.MMEventStartListening<MMGameEvent>();
    }

    private void OnDisable()
    {
        this.MMEventStopListening<MMGameEvent>();
    }

    public void OnMMEvent(MMGameEvent deathReset)
    {
        if(deathReset.EventName == "DeathReset")
        {
            _myWeapon.ProjectilesPerShot = 1;
            _myWeapon.Spread = new Vector3(0, 0, 0);

            _meleeWeapon.MinDamageCaused = 15;
            _meleeWeapon.MaxDamageCaused = 15;
            _meleeWeapon.Knockback = DamageOnTouch.KnockbackStyles.NoKnockback;
        }
    }




    protected virtual void Initialization()
    {
        _myWeapon.ProjectilesPerShot = 1;
        _myWeapon.Spread = new Vector3(0, 0, 0);

        _meleeWeapon.MinDamageCaused = 15;
        _meleeWeapon.MaxDamageCaused = 15;
        _meleeWeapon.Knockback = DamageOnTouch.KnockbackStyles.NoKnockback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeWeaponTiro()
    {

        _myWeapon.ProjectilesPerShot = 5;
        _myWeapon.Spread = new Vector3(0, 10, 0);
        _tiroUpgraded = true;
        _upgradeScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void UpgradeWeaponMelee() 
    {

        _meleeWeapon.MinDamageCaused = 20;
        _meleeWeapon.MaxDamageCaused = 20;
        _meleeWeapon.Knockback = DamageOnTouch.KnockbackStyles.AddForce;
        _meleeUpgraded = true;
        _upgradeScreen.SetActive(false);
        Time.timeScale = 1;

    }

    public void UpgradeShield()
    {
        _shieldUpgraded = true;
        _upgradeScreen.SetActive(false);
        Time.timeScale = 1;
    }

}
