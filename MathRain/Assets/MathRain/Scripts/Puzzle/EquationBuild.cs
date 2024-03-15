using UnityEngine;

public class EquationBuilder
{
    public string Equation { get; private set; }
    private Transform _rowTransform;

    public EquationBuilder(Transform rowTransform)
    {
        _rowTransform = rowTransform;
    }

    public void BuildEquation()
    {
        Equation = "";

        for (int i = 1; i < _rowTransform.childCount; i++)
        {
            var childName = _rowTransform.GetChild(i).name;
            Equation += childName != "клетка" ? childName : "x";
        }
    }
}