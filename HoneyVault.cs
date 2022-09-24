using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive
{
    internal static class HoneyVault
    {
        const float NECTAR_CONVERSION_RATIO = .19f;
        const float LOW_LEVEL_WARNING = 10f;
        public static string StatusReport
        {
            get
            {
                string s = $"Miód: {Honey}";
                if (Honey < LOW_LEVEL_WARNING)
                    s += "\nMAŁO MIODU - DODAJ PRODUCENTÓW MIODU!!";

                s += $"\nNektar: {Nectar}";
                if (Nectar < LOW_LEVEL_WARNING)
                    s += "\nMAŁO NEKTARU - DODAJ PRODUCENTÓW NEKTARU!!";

                return s;
            }
        }
        public static float Honey
        {
            get => honey;
            set => honey = value;
        }
        public static float Nectar
        {
            get => nectar;
            set => nectar = value;
        }

        private static float honey = 25f;
        private static float nectar = 100f;





        public static void CollectNectar(float nectarToCollect)
        {
            if (nectarToCollect > 0)
            {
                Nectar += nectarToCollect;
            }

        }

        public static void ConvertNectarToHoney(float nectarToConvert)
        {

            if (nectarToConvert <= Nectar)
            {
                Honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
                Nectar -= nectarToConvert;
            }
            else
            {
                Honey += Nectar * NECTAR_CONVERSION_RATIO;
                Nectar = 0;
            }

        }

        public static bool ConsumeHoney(float honeyToEat)
        {
            if (honeyToEat < 0)
            {
                Console.WriteLine("Miód do zjedzenia nie może być ujemny");
                return false;
            }

            if (honeyToEat <= Honey)
            {
                Honey -= honeyToEat;
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
