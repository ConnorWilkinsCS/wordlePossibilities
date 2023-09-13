using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drewsfuckinstringconfigtask
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Input the ruleset: ");
            string ruleset = Console.ReadLine();

            int answer = wordlepossibilities(ruleset);
            Console.WriteLine("There are " + answer + " possible correct combinations");
        }

        public static int wordlepossibilities(string ruleset)
        {
            //plan:
            int counter = 0;
            int zeroCounter = 0;
            int twoCounter = 0;
            int oneCounter = 0;
            //parse the string into an array
            int[] rulesetArr = new int[ruleset.Length]; //cast to ints so it can process the ints in the ruleset
            for (int i = 0; i < ruleset.Length; i++)
            {
                rulesetArr[i] = ruleset[i];
            }
            //loop for each element/2 cuz letternum combo
            for (int i = 1; i <= ruleset.Length / 2; i = i + 1)
            {
                if (rulesetArr[i] == 0) //if 0, its grey
                {
                    zeroCounter++;
                }
                if (rulesetArr[i] == 1) //if 1, its yellow
                {
                    oneCounter++;
                }
                if (rulesetArr[i] == 2) //if 2, its green
                {
                    counter++;
                    twoCounter++;
                }
            }
            counter = counter + (ruleset.Length/2 - (1 + oneCounter + twoCounter)); //this is how many spots can be taken other than 1 and 2 spots
            if (zeroCounter > 0)
            {
                counter = counter + (26 - zeroCounter - twoCounter); //both of these could be fucking wrong im too scrambled to get the logic right
            }

        return counter;

        }
    }
}

/*you are tasked with finding the number of possible configurations of characters that would result in a correct 
configuration of characters.

given an input string with the following rules:
given an input string comprised of one or more lines "L" of 2 character sections "S" where
the section length of "S" is "S >= L" , and the 2 character sections are made up of a letter followed by a 0, 1, or 2.

Examples of inputs are as follows;
"a0b0c1d2e0" <- 1 line of 5 sections
"a0b0c1d2,e0c1f0g0" <- 2 lines of 4 sections
"a0b0c1,d0c1e1,c2,e2,f0" <- 3 lines of 3 sections

each digit within a section refers to one of 3 possiblities
    a section with a 0 means that the character is not in any possible correct configurations (grey)
    a section with a 1 means that the character is in all possible correct configurations but not in that index location (yellow)
    a section with a 2 means that the character is in all possible correct configurations at that location (green)

a correct configuration of chracters would be a scenario where all characters are possibly in a location that would be correct

you are to determine the number of correct possible configurations of characters according to these rules

Examples:
ruleset1 = "a1b1c1,c1a1b1"
>>> wordlepossibilites(ruleset1)
>>> 1

>>> ruleset2 = "a2b0"
>>> wordlepossibilities(ruleset2)
>>> 24*/