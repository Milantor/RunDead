using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class ModificableFloat
{
    public ModificableFloat(float value) => OriginalValue = value;

    public void AddMultiplier(object author, float value) =>
        Multipliers.Add(author, value);
    public void AddAdditional(object author, float value) =>
        Additionals.Add(author, value);

    public void RemoveMultiplier(object author) =>
        Multipliers.Remove(author);
    public void RemoveAdditional(object author) =>
        Additionals.Remove(author);

    Dictionary<object, float> Multipliers = new();
    Dictionary<object, float> Additionals = new();

    [SerializeField]
    public float OriginalValue;

    public static implicit operator float(ModificableFloat modificableFloat) => modificableFloat.Value;
    public float Value
    {
        get
        {
            var value = OriginalValue;
            foreach (var additionValue in Additionals.Values)
                value += additionValue;
            foreach (var multiplierValue in Multipliers.Values)
                value *= multiplierValue; 
            return value;
        }
    }
}

