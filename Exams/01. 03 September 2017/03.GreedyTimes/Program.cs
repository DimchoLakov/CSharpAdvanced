using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03.GreedyTimes
{
    class Program
    {
        static void Main()
        {
            BigInteger bagCapacity = BigInteger.Parse(Console.ReadLine());

            string[] jewels = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Dictionary<string, BigInteger>> bagItems = new Dictionary<string, Dictionary<string, BigInteger>>();

            bagItems["Gold"] = new Dictionary<string, BigInteger>();
            bagItems["Gem"] = new Dictionary<string, BigInteger>();
            bagItems["Cash"] = new Dictionary<string, BigInteger>();

            for (int i = 0; i < jewels.Length; i += 2)
            {
                string treasure = jewels[i];
                BigInteger quantity = BigInteger.Parse(jewels[i + 1]);

                if (jewels[i].ToLower().Equals("gold") && !IsExceedingBagsCapacity(bagItems, quantity, bagCapacity))
                {
                    TryAddGoldToBag(treasure, quantity, bagItems);
                }
                else if (treasure.Length >= 4 && jewels[i].ToLower().EndsWith("gem") && !IsExceedingBagsCapacity(bagItems, quantity, bagCapacity))
                {
                    TryAddGemToBag(treasure, quantity, bagItems);
                }
                else if (treasure.Length == 3 && !IsExceedingBagsCapacity(bagItems, quantity, bagCapacity))
                {
                    TryAddCashToBag(treasure, quantity, bagItems);
                }
            }

            PrintResult(bagItems);
        }

        static void PrintResult(Dictionary<string, Dictionary<string, BigInteger>> bagItems)
        {
            Dictionary<string, Dictionary<string, BigInteger>> sortedBag = bagItems
                .Where(x => x.Value.Keys.Count > 0)
                .OrderByDescending(item => item.Value.Values.Sum(i => (long)i))
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (KeyValuePair<string, Dictionary<string, BigInteger>> item in sortedBag)
            {
                BigInteger totalAmountByType = sortedBag[item.Key].Values.Sum(x => (long)x);

                Console.WriteLine($"<{item.Key}> ${totalAmountByType}");

                Dictionary<string, BigInteger> sortedItems = item.Value
                    .OrderByDescending(name => name.Key)
                    .ThenBy(amount => amount.Value)
                    .ToDictionary(k => k.Key, v => v.Value);

                foreach (KeyValuePair<string, BigInteger> nameAndQuantity in sortedItems)
                {
                    Console.WriteLine($"##{nameAndQuantity.Key} - {nameAndQuantity.Value}");
                }
            }
        }

        static bool IsExceedingBagsCapacity(Dictionary<string, Dictionary<string, BigInteger>> bagItems, BigInteger quantity, BigInteger bagCapacity)
        {
            return bagItems.Sum(x => x.Value.Values.Sum(w => (long)w)) + quantity > bagCapacity;
        }

        static void TryAddCashToBag(string treasure, BigInteger quantity, Dictionary<string, Dictionary<string, BigInteger>> bagItems)
        {
            BigInteger gemAmount = bagItems["Gem"].Values.Sum(x => (long)x);
            BigInteger cashAmount = bagItems["Cash"].Values.Sum(x => (long)x);

            if (gemAmount >= cashAmount + quantity)
            {
                if (!bagItems["Cash"].ContainsKey(treasure))
                {
                    bagItems["Cash"].Add(treasure, quantity);
                }
                else
                {
                    bagItems["Cash"][treasure] += quantity;
                }
            }
        }

        static void TryAddGemToBag(string treasure, BigInteger quantity, Dictionary<string, Dictionary<string, BigInteger>> bagItems)
        {
            BigInteger goldAmount = bagItems["Gold"].Values.Sum(x => (long)x);
            BigInteger gemAmount = bagItems["Gem"].Values.Sum(x => (long)x);
            BigInteger cashAmount = bagItems["Cash"].Values.Sum(x => (long)x);

            if (gemAmount + quantity >= cashAmount && goldAmount >= gemAmount + quantity)
            {
                if (!bagItems["Gem"].ContainsKey(treasure))
                {
                    bagItems["Gem"].Add(treasure, quantity);
                }
                else
                {
                    bagItems["Gem"][treasure] += quantity;
                }
            }
        }

        static void TryAddGoldToBag(string treasure, BigInteger quantity, Dictionary<string, Dictionary<string, BigInteger>> bagItems)
        {
            BigInteger goldAmount = bagItems["Gold"].Values.Sum(x => (long)x);
            BigInteger gemAmount = bagItems["Gem"].Values.Sum(x => (long)x);

            if (goldAmount + quantity >= gemAmount)
            {
                if (!bagItems["Gold"].ContainsKey(treasure))
                {
                    bagItems["Gold"].Add(treasure, quantity);
                }
                else
                {
                    bagItems["Gold"][treasure] += quantity;
                }
            }
        }
    }
}
