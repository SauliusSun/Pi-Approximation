namespace Client.Domain
{
    public interface IPiCalculationMethod
    {
        void Calculate(int durationInSeconds);

        double GetResult();
    }
}
