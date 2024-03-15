using System;
using System.Data;

public class ResultCalculator
{
    public bool CalculateResult(string equation, int expectedAnswer)
    {
        try
        {
            double result = Convert.ToDouble(new DataTable().Compute(equation, ""));
            return Math.Abs(result - expectedAnswer) < 0.001;
        }
        catch
        {
            return false;
        }
    }
}
