using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MoreMountains.InventoryEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ChangeWeapon : MonoBehaviour
{
    public CharacterInventory _getInventory;
    //public InventoryItem[] _getItem;
    public string[] _weaponName = { "MeleeWeapon", "WeaponTiro", "ShieldWeapon" };
    public static int currentWeapon = 1;
    public MMF_Player levelEffectChange;



    // Start is called before the first frame update
    void Start()
    {
        _weaponName[2] = "ShieldWeapon";
        currentWeapon = 1;
        //_getInventory = GetComponent<Inventory>();
        
    }


    // Update is called once per frame
    void Update()
    {
        if (UpgradesScript._shieldUpgraded)
        {
            _weaponName[2] = "SecondShield";
            if(currentWeapon == 2)
            {
                _getInventory.EquipWeapon(_weaponName[2]);

                UpgradesScript._shieldUpgraded = false;
            }
            
        }

        if (UpgradesScript._tiroUpgraded)
        {
            if(currentWeapon == 1) 
            {
                _getInventory.EquipWeapon(_weaponName[1]);

                UpgradesScript._tiroUpgraded = false;
            
            }
        }

        if (UpgradesScript._meleeUpgraded)
        {
            if(currentWeapon == 0) 
            {
                _getInventory.EquipWeapon(_weaponName[0]);

                UpgradesScript._meleeUpgraded = false;
            
            }
        }

        if (Input.GetButtonDown("Player1_Inventory_Right"))
        {

            levelEffectChange.PlayFeedbacks();

            if (currentWeapon < 2)
            {
                currentWeapon++;
                _getInventory.EquipWeapon(_weaponName[currentWeapon]);
            }
            else
            {
                currentWeapon = 0;
                _getInventory.EquipWeapon(_weaponName[currentWeapon]);
            }


        }

        if (Input.GetButtonDown("Player1_Inventory_Left"))
        {

            levelEffectChange.PlayFeedbacks();

            if (currentWeapon > 0)
            {
                currentWeapon--;
                _getInventory.EquipWeapon(_weaponName[currentWeapon]);
            }
            else
            {
                currentWeapon = 2;
                _getInventory.EquipWeapon(_weaponName[currentWeapon]);
            }
        }

        
        
        
        
    }

    IEnumerator BeginGame()
    {
        yield return new WaitForSeconds(1);
        _getInventory.EquipWeapon(_weaponName[currentWeapon]);
        StopCoroutine(BeginGame());
    }
}

