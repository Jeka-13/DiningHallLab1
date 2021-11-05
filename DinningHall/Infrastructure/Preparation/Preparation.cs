using System.Collections.Generic;
using System.Linq;
using DinningHall.Helpers.Enums;
using DinningHall.Models;

namespace DinningHall.Infrastructure.Preparation
{
    public class Preparation
    {
        public static void PrepareTables(List<Table> tables, int amount)
        {
            tables.AddRange((new Table[amount]).Select(o => new Table()));
        }

        public static void PrepareWaiters(List<Waiter> waiters, int amount)
        {
            for (int i = 0; i < amount; i++) { waiters.Add(new Waiter()); }
        }

        public static void PrepareMenu(List<Food> menu)
        {
            menu.AddRange(new Food[]
            {
                new Food
                {
                    Id = 1,
                    Name = "Pizza",
                    PreparitionTime = 20,
                    Comlexity = 2,
                    CookingApparatus = CookingApparatusType.Oven
                },
                new Food
                {
                    Id = 2,
                    Name = "Salad",
                    PreparitionTime = 10,
                    Comlexity = 1,
                    CookingApparatus = null
                },
                new Food
                {
                    Id = 3,
                    Name = "Zeama",
                    PreparitionTime = 7,
                    Comlexity = 1,
                    CookingApparatus = CookingApparatusType.Stove
                },
                new Food
                {
                    Id = 4,
                    Name = "Scallop Sashami with Meyer Lemon Confit",
                    PreparitionTime = 32,
                    Comlexity = 3,
                    CookingApparatus = null
                },
                new Food
                {
                    Id = 5,
                    Name = "Island Duck with Mulberry Mustard",
                    PreparitionTime = 35,
                    Comlexity = 3,
                    CookingApparatus = CookingApparatusType.Oven
                },
                new Food
                {
                    Id = 6,
                    Name = "Waffles",
                    PreparitionTime = 10,
                    Comlexity = 1,
                    CookingApparatus = CookingApparatusType.Stove
                },
                new Food
                {
                    Id = 7,
                    Name = "Aubergine",
                    PreparitionTime = 20,
                    Comlexity = 2,
                    CookingApparatus = null
                },
                new Food
                {
                    Id = 8,
                    Name = "Lasagna",
                    PreparitionTime = 30,
                    Comlexity = 2,
                    CookingApparatus = CookingApparatusType.Oven
                },
                new Food
                {
                    Id = 9,
                    Name = "Burger",
                    PreparitionTime = 15,
                    Comlexity = 1,
                    CookingApparatus = CookingApparatusType.Oven
                },
                new Food
                {
                    Id = 10,
                    Name = "Gyros",
                    PreparitionTime = 15,
                    Comlexity = 1,
                    CookingApparatus = null
                }
            });
        }
    }
}