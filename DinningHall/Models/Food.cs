using System;
using DinningHall.Helpers.Enums;

namespace DinningHall.Models
{
    public class Food
    {
        public long Id;
        public string Name;
        public int PreparitionTime;
        public int Comlexity;
        public CookingApparatusType? CookingApparatus;
    }
}