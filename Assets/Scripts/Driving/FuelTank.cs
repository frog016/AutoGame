using System;

namespace Driving
{
    public class FuelTank
    {
        public float FuelAmount { get; private set; }
        public float FuelCapacity { get; }
        public event Action<float> Changed;

        public FuelTank(float capacity)
        {
            FuelCapacity = capacity;
            FuelAmount = capacity;
        }

        public void Consume(float amount)
        {
            AssertPositive(amount);

            if (IsFuelEnough(amount) == false)
                throw new ArgumentOutOfRangeException($"Amount ({amount}) can't be larger than fuel amount ({FuelAmount}).");

            FuelAmount -= amount;
            Changed?.Invoke(FuelAmount);
        }

        public void Refuel(float amount)
        {
            AssertPositive(amount);

        }

        public bool IsFuelEnough(float amount)
        {
            return amount <= FuelAmount;
        }

        private static void AssertPositive(float amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException($"Amount ({amount}) can't be negative.");
        }
    }
}