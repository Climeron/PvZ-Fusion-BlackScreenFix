using System.Globalization;
using System.IO;
using ClimeronToolsForPvZ.Extensions;
using HarmonyLib;
using Il2Cpp;
using UnityEngine;

namespace BlackScreenFix.Patches
{
    [HarmonyPatch(typeof(PlantDataLoader))]
    public static class PlantDataLoaderPatches
    {
        [HarmonyPatch(nameof(PlantDataLoader.LoadPlantData))]
        [HarmonyPrefix]
        private static bool LoadPlantData()
        {
            string text = Resources.Load<TextAsset>("plant_data").text;
            StringReader reader = new(text);
            bool firstLine = true;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }
                PlantDataLoader.PlantData_ data = new();
                string[] stringValuesArray = line.Split(',');
                if (IntTryParse(stringValuesArray[0], out int plantType))
                    data.field_Public_Int32_0 = plantType;
                if (FloatTryParse(stringValuesArray[1], out float attackInterval))
                    data.field_Public_Single_0 = attackInterval;
                if (FloatTryParse(stringValuesArray[2], out float productionInterval))
                    data.field_Public_Single_1 = productionInterval;
                if (IntTryParse(stringValuesArray[3], out int attackDamage))
                    data.field_Public_Int32_1 = attackDamage;
                if (IntTryParse(stringValuesArray[4], out int maxHealth))
                    data.field_Public_Int32_2 = maxHealth;
                if (FloatTryParse(stringValuesArray[5], out float cooldown))
                    data.field_Public_Single_2 = cooldown;
                if (IntTryParse(stringValuesArray[6], out int price))
                    data.field_Public_Int32_3 = price;
                PlantDataLoader.plantData[data.field_Public_Int32_0] = data;
            }
            return false;
        }
        private static bool IntTryParse(string s, out int result)
        {
            if (int.TryParse(s, out result))
                return true;
            $"[Parsing] Can't parse string {s} to <int>".Print();
            return false;
        }
        private static bool FloatTryParse(string s, out float result)
        {
            if (float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
                return true;
            $"[Parsing] Can't parse string {s} to <float>".Print();
            return false;
        }
    }
}
