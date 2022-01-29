using EthContract.Models;

namespace EthContract
{
    public static class RegionsManager
    {
        public static List<Region> Regions = new List<Region>
        {
            new Region
            {
                Id = 0,
                Label = "Россия",
                Childs = new List<Region>()
                {
                    new Region
                    {
                        Id = 0,
                        Label = "Санкт-Петербург"
                    },
                    new Region
                    {
                        Id = 1,
                        Label = "Москва"
                    },
                    new Region
                    {
                        Id = 2,
                        Label = "Новосибирск"
                    },
                }
            },
            new Region
            {
                Id = 1,
                Label = "Белорусь",
                Childs = new List<Region>()
                {
                    new Region
                    {
                        Id = 0,
                        Label = "Минск"
                    },
                    new Region
                    {
                        Id = 1,
                        Label = "Гомель"
                    },
                    new Region
                    {
                        Id = 2,
                        Label = "Могилев"
                    },
                }
            },
            new Region
            {
                Id = 2,
                Label = "США",
                Childs = new List<Region>()
                {
                    new Region
                    {
                        Id = 0,
                        Label = "Вашингтон"
                    },
                    new Region
                    {
                        Id = 1,
                        Label = "Лас-Вегас"
                    }
                }
            }
        };
    }
}
