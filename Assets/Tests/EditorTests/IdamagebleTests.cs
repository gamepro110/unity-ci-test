using NUnit.Framework;
using thingGame;
using UnityEngine;

public class IdamagebleTests
{
   [Test]
   public void OnHeal()
   {
      GameObject gameObject = new GameObject(
          "test",
          typeof(PlayerDamageble)
          );
      Damageble player = gameObject.GetComponent<PlayerDamageble>();
      player.SetMaxHitpoints(10);
      player.SetHitpoints(2);
      Assert.AreEqual(2, player.GetHitpoints);
      player.DoHeal(5);
      Assert.AreEqual(7, player.GetHitpoints);
   }

   [Test]
   public void OnDamage()
   {
      GameObject obj = new GameObject(
          "test",
          typeof(PlayerDamageble)
          );
      Damageble player = obj.GetComponent<PlayerDamageble>();
      player.SetMaxHitpoints(10);
      player.SetHitpoints(10);
      Assert.AreEqual(10, player.GetHitpoints);
      player.DoDamage(2);
      Assert.AreEqual(8, player.GetHitpoints);
   }
}