using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace thingGame
{
   public class GunBase : MonoBehaviour, IGun
   {
      private void Start()
      {
         CurrentAmmoCount = scriptable.MaxAmmo;
         CurrentMagCount = scriptable.MagazineCapacity;
      }

      public virtual void DoReload()
      {
         CurrentMagCount = scriptable.MagazineCapacity; // TODO add 0 prevention
         CurrentAmmoCount -= scriptable.MagazineCapacity;
         //TODO add waiting time
      }

      public virtual void Fire()
      {
         if (CurrentMagCount > 1)
         {
            CurrentMagCount--;
            GameObject bullet = Instantiate(BulletPrefab, BarrelPos.position, Quaternion.identity);
            // TODO add bullet dmg
         }
         else
         {
            DoReload();
         }
      }

      public void OnPickup(GameObject player)
      {
      }

      [SerializeField] private ScriptableGun scriptable;
      [SerializeField] private Transform BarrelPos;
      [SerializeField] private GameObject BulletPrefab;
      private int CurrentMagCount;
      private int CurrentAmmoCount;
   }
}