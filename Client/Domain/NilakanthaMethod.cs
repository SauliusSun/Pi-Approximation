using System;

namespace Client.Domain
{
    public class NilakanthaMethod : IPiCalculationMethod
    {
        public void Calculate(int durationInSeconds)
        {
            throw new NotImplementedException();
        }

        public double GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
