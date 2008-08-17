using System.Collections.Generic;
namespace iWoWArm {
    public class Utility {
        private Utility() {}

        public static T GetStatisticalMode<T>(T[] array) {
            Dictionary<T, int> dictionary = new Dictionary<T, int>();

            // get a count of how often each item in the array occurs
            foreach (T item in array) {
                if (dictionary.ContainsKey(item)) {
                    dictionary[item] = dictionary[item] + 1;
                } else {
                    dictionary.Add(item, 1);
                }
            }

            // get the first largest mode encountered
            int largestOccurance = 0;
            T largestOccuranceKey = dictionary.Keys.GetEnumerator().Current;
            foreach (T key in dictionary.Keys) {
                if (dictionary[key] > largestOccurance) {
                    largestOccurance = dictionary[key];
                    largestOccuranceKey = key;
                }
            }

            return largestOccuranceKey;
        }

    }
}