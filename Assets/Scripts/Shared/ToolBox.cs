using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ToolBox
{
        private static float GetMeanDiff(List<int> stateList)
        {
            List<int> nonZeroStateList = CleanUpListInt(stateList);

            float span = (float)nonZeroStateList.Count;

            List<float> diffs = new List<float>();
            float meanState = 0;
            float stateSum = SumListInt(stateList);
            meanState = stateSum / span;
            float totalDiff = 0;
            foreach (var state in nonZeroStateList)
            {
                totalDiff += Mathf.Abs((float)(state) - meanState);
            }
            float meanDiff = totalDiff / span;

            return meanDiff;
        }

        public static float GetBalance(int[] stateCollection)
        {
            // convert array to list and exclude all zeroes from the calculation
            List<int> stateList = stateCollection.OfType<int>().ToList();

            float meanDiff = GetMeanDiff(stateList);
            float maxStat = 0;
            foreach (var stat in stateList)
            {
                maxStat = Mathf.Max(maxStat, stat);
            }
            float balance = 1 - (meanDiff / maxStat); // should return 1 for full balance
            return balance;
        }

        public static float GetDisbalance(int[] stateCollection)
        {
            // convert array to list and exclude all zeroes from the calculation
            List<int> stateList = stateCollection.OfType<int>().ToList();

            float meanDiff = GetMeanDiff(stateList);
            // Debug.Log($"Mean diff: {meanDiff}");
            float maxStat = 0;
            foreach (var stat in stateList)
            {
                maxStat = Mathf.Max(maxStat, stat);
            }
            float disbalance = (meanDiff / maxStat); // should return 1 for full disbalance
            // Debug.Log($"Disbalance: {disbalance}");
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
            float result = (input-3)/(1+Mathf.Abs(input-3)) + 1.666666f; // \\frac{x-3}{1+\left|x-3\right|}+1.6666666666666 - THAT APPEARS TO BE WORKING; NEED TO PLOT THIS THINGS OUT SOMEWHERE
            return result;
        }

        public static int SumListInt(List<int> list)
        {
            int sum = 0;
            foreach (int item in list)
            {
                sum+= item;
            }
            return sum;
        }

        public static List<int> CleanUpListInt(List<int> list)
        {
            List<int> cleanList= new List<int>();
            foreach (int state in list)
            {
                if (state != 0)
                {
                    cleanList.Add(state);
                }
            }

            return cleanList;
        }
}

// (2/Pi)*arctan( (Ping/2)*x - 3) + 1.8
