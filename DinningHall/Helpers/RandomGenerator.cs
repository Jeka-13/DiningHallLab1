using System;

namespace DinningHall.Helpers
{
    public class RandomGenerator
    {
        private static  readonly Random Random = new Random(DateTime.Now.Millisecond);

        public static int GenerateTime(int max, int min = 0)
        {
            return Random.Next(min * Configurator.TIME_UNIT, max * Configurator.TIME_UNIT);
        }

        public static int GenerateNumber(int max, int min = 1)
        {
            return Random.Next(min, max + 1);
        }
    }
}