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
}
