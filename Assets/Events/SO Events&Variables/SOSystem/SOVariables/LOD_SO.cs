using System;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "LOD_SO", menuName = "SO/Variables/LOD_SO")]
    public class LOD_SO : VariableSO<LevelOfDifficulty.Difficulty>
    {
        public LevelOfDifficulty.Difficulty LOD_Value;

        public override void SetValue(string value)
        {
            var parsedVal = LevelOfDifficulty.Difficulty.Normal;
            if (LevelOfDifficulty.Difficulty.TryParse(value, out parsedVal))
            {
                SetValue(parsedVal);
            }
        }

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.ToString();
        }
    }
}
