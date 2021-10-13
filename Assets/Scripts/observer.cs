namespace thingGame
{
   public interface IObserver
   {
      abstract void OnNotify(IObservable observable);
   }

   public interface IObservable
   {
      abstract void Subscribe(IObserver observer);

      abstract void Notify();
   }
}