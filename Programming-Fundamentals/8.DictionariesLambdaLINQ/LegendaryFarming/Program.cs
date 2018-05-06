using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> materials = new Dictionary<string, Dictionary<string, int>>();
            materials.Add("keyMaterials", new Dictionary<string, int>());
            materials.Add("junk", new Dictionary<string, int>());

            string[] keyMaterials = { "fragments", "motes", "shards" };
            foreach (var keyMaterial in keyMaterials)
            {
                materials["keyMaterials"][keyMaterial] = 0;
            }

            string obtainedItem = null;
            string materialToModify = null;
            bool obtained = false;

            while (obtained == false)
            {
                string input = Console.ReadLine();

                string[] currentMaterials = input.ToLower().Split(' ');

                for (int i = 0; i < currentMaterials.Length; i += 2)
                {
                    int ammount = int.Parse(currentMaterials[i]);
                    string type = currentMaterials[i + 1];

                    if (type == "shards" || type == "fragments" || type == "motes")
                    {
                        materials["keyMaterials"][type] += ammount;
                    }
                    else
                    {
                        if (materials["junk"].ContainsKey(type))
                        {
                            materials["junk"][type] += ammount;
                        }
                        else
                        {
                            materials["junk"].Add(type, ammount);
                        }
                    }

                    foreach (var keyMaterial in materials["keyMaterials"])
                    {
                        if (keyMaterial.Value >= 250)
                        {
                            materialToModify = keyMaterial.Key;

                            switch (keyMaterial.Key)
                            {
                                case "shards": obtainedItem = "Shadowmourne"; break;
                                case "motes": obtainedItem = "Dragonwrath";  break;
                                case "fragments": obtainedItem = "Valanyr";  break;
                            }
                            obtained = true;
                        }
                    }

                    if (obtained)
                    {
                        break;
                    }
                }
            }

            materials["keyMaterials"][materialToModify] -= 250;

            Console.WriteLine($"{obtainedItem} obtained!");

            foreach (var keyMaterial in materials["keyMaterials"].OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
            }

            foreach (var junk in materials["junk"].OrderBy(x => x.Key))
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }
    }
}
