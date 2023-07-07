namespace UI.Presenter
{
    public class HealthBarPresenter : CarStatePresenter
    {
        protected override void Initialize()
        {
            UpdateProgress(Car.Health.Health);
        }

        protected override void Subscribe()
        {
            Car.Health.Changed += UpdateProgress;
        }

        protected override void Unsubscribe()
        {
            Car.Health.Changed -= UpdateProgress;
        }

        private void UpdateProgress(int value)
        {
            UpdateProgress(value, Car.Health.MaxHealth);
        }
    }
}
