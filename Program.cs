using System;

namespace FindMaxFromStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find the maximum possible number");
            Console.WriteLine("Example if input = [\"54\",\"60\",\"548\",\"546\"]");
            Console.WriteLine("Then the output would be \"6054854654\"");
            //string[] r1 = permutations(new string[]{"1","2","3"});
            //string[] r2 = permutations(new string[]{"1","2","3","4"});
            string[] t1 = new string[] {"54","60","548","546"};
            string t1_m = "6054854654";

            string[] t2 = new string[] {"1","2","3","4"};
            string t2_m = "4321";

            string[] t3 = new string[] {"0","50","99","100"};
            string t3_m = "99501000";

            if(findMax(t1).Equals(t1_m)) {
                Console.WriteLine("T1 passed");
            } else {
                Console.WriteLine("T1 failed");
            }

            if(findMax(t2).Equals(t2_m)) {
                Console.WriteLine("T2 passed");
            } else {
                Console.WriteLine("T2 failed");
            }

            if(findMax(t3).Equals(t3_m)) {
                Console.WriteLine("T3 passed");
            } else {
                Console.WriteLine("T3 failed");
            }

        }


        public static string findMax(string[] vals) {
            string[] perms = permutations(vals);
            long max = 0;
            foreach(string perm in perms) {
                long val = Convert.ToInt64(perm);
                if(val > max) {
                    max = val;
                }
            }
            return max.ToString();
        }

        public static string[] permutations(string[] vals) {
            string[] perms;
            if(vals.Length <= 2) {
                perms = new string[2];
                perms[0] = vals[0] + vals[1];
                perms[1] = vals[1] + vals[0];
                return perms;
            }

            //Create a new array of size !N where N is the size of vals array
            perms = new string[factorial(vals.Length)];
            int permsCount = 0;
            for(int i = 0; i < vals.Length; i++) {
                string thisVal = vals[i];
                string[] subVals = new string[vals.Length - 1];
                int z = 0;
                for(int j = 0; j < vals.Length; j++) {
                    if(j == i) {
                        continue;
                    }
                    subVals[z] = vals[j];
                    z++;
                }
                string[] subPerm = permutations(subVals);
                foreach(string subPermVal in subPerm) {
                    perms[permsCount] = thisVal + subPermVal;
                    permsCount++;
                }
            }
            return perms;
        }

        public static int factorial(int val) {
            int f = 1;
            for (int i = 1; i <= val; i++) {
                f = f * i;
            }
            return f;
        }

    }
}
