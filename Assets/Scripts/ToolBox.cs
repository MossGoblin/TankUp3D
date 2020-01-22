using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ToolBox
{
        private static float GetMeanDiff(int[] stateCollection)
        {
            int span = stateCollection.Length;
            List<float> diffs = new List<float>();
            float meanState = 0;
            float stateSum = 0;
            foreach (var state in stateCollection)
            {
                stateSum += (float)state;
            }
            meanState = stateSum / span;
            float totalDiff = 0;
            foreach (var state in stateCollection)
            {
                totalDiff += Mathf.Abs((float)(state) - meanState);
            }
            float meanDiff = totalDiff / span;

            return meanDiff;
        }

        public static float GetBalance(int[] stateCollection)
        {
            float meanDiff = GetMeanDiff(stateCollection);
            float maxStat = 0;
            foreach (var stat in stateCollection)
            {
                maxStat = Mathf.Max(maxStat, stat);
            }
            float balance = 1 - (meanDiff / maxStat); // should return 1 for full balance
            return balance;
        }

        public static float GetDisbalance(int[] stateCollection)
        {
            float meanDiff = GetMeanDiff(stateCollection);
            float maxStat = 0;
            foreach (var stat in stateCollection)
            {
                maxStat = Mathf.Max(maxStat, stat);
            }
            float disbalance = (meanDiff / maxStat); // should return 1 for full disbalance
            return disbalance;
        }

        public static float Sigmoid(float input)
        {
            // use \arctan\left(x-3\right)+2.25
            // check \arctan\left(x-3\right)+2.25 at https://www.desmos.com/calculator

            // float result = Mathf.Atan((input/2) - 3) + 2.25f; // \arctan\left(x-3\right)+2.25
            // float result = (2/Mathf.PI) * (Mathf.Atan(Mathf.PI/2 * input - 3)) + 1.8494549f; // \frac{2}{\pi}\arctan\left(\frac{\pi}{2}x-3\right)+1.8 - NOT CORRECT!
            if (input == 2)
            {
                input += 0.01f;
            }
            float result = (input-3)/(1+Mathf.Abs(input-3)) + 1.666666f; // \\frac{x-3}{1+\left|x-3\right|}+1.6666666666666
            return result;
        }
}

// (2/Pi)*arctan( (Ping/2)*x - 3) + 1.8
