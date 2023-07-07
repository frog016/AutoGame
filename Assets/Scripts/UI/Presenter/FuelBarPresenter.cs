namespace UI.Presenter
{
    public class FuelBarPresenter : CarStatePresenter
    {
        protected override void Initialize()
        {
            UpdateProgress(Car.FuelTank.FuelAmount);
        }

        protected override void Subscribe()
        {
            Car.FuelTank.Changed += UpdateProgress;
        }

        protected override void Unsubscribe()
        {
            Car.FuelTank.Changed -= UpdateProgress;
        }

        private void UpdateProgress(float value)
        {
            UpdateProgress(value, Car.FuelTank.FuelCapacity);
        }
    }
}