using System;
using System.Runtime.Serialization;
using DinningHall.Helpers.Enums;

namespace DinningHall.Models
{
    public class CookingApparatus
    {
        public long Id;
        public CookingApparatusType Type;
        
        private static ObjectIDGenerator idGenerator = new ObjectIDGenerator();
        
        public CookingApparatus()
        {
            Id = idGenerator.GetId(this, out bool firstTime);
        }

    }
}
