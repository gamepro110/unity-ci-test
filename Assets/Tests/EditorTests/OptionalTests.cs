using NUnit.Framework;
using thingGame;

public class OptionalTests
{
   [Test]
   public void NullTest()
   {
      Optional<int> a = new Optional<int>(null);

      Assert.AreEqual(null, a.Value);
   }

   [Test]
   public void ValueTest()
   {
      Optional<int> a = new Optional<int>(10);

      Assert.AreEqual(10, a.Value);
   }

   [Test]
   public void EnabledFalseTest()
   {
      Optional<int> a = new Optional<int>(10, false);

      Assert.AreEqual(null, a.Value);
   }

   [Test]
   public void EnabledTrueTest()
   {
      Optional<int> a = new Optional<int>(null, true);

      Assert.AreEqual(null, a.Value);
   }
}