using System.Collections;
using MoreMountains.Tools;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

namespace MoreMountains.TopDownEngine
{
    public class ShieldWeaponBehavior : Weapon
    {
        //public Projectile _projectile;
        public float _speed;
        protected BoxCollider _collider;
        protected Animator _animator;
        public GameObject _particleSystem;
        public MMF_Player _player;

        public override void Initialization()
        {
            base.Initialization();
            //_weaponAim = GetComponent<WeaponAim>();
            _collider = GetComponent<BoxCollider>();
            _animator = GetComponent<Animator>();
            
        }

        protected override void Update()
        {
            
            if(this.gameObject.layer == 6)
            {
                if (_animator.GetBool("Shooting") == true)
                {
                    _collider.enabled = true;
                    _particleSystem.SetActive(true);
                    _player.enabled = true;

                }
                else
                {
                    _collider.enabled = false;
                    _particleSystem.SetActive(false);
                    _player.enabled = false;

                }
            }
            
            
                
            
        }

        

        /*private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "EnemyBullet")
            {
                _projectile = other.GetComponent<Projectile>();
                _speed = _projectile.Speed;
                _projectile.Speed = _speed*-1;
            }
        }*/

    }
}
