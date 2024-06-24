using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Models
{
    public partial class ChartDataRepository
    {
        public static List<CompanyModel> Companies()
        {
            return new List<CompanyModel>()
            {
                new CompanyModel(){
                    CompanyName = "Company A",
                    Sales = 100M,
                    Products = new List<ProductModel>()
                    {
                        new ProductModel(){ProductName = "Product 1", Sales = 80M},
                        new ProductModel(){ProductName = "Product 2", Sales = 20M},
                    }
                },
                new CompanyModel() {
                    CompanyName = "Company B" ,
                    Sales = 200M,
                    Products = new List<ProductModel>()
                    {
                        new ProductModel(){ProductName = "Product 1", Sales = 40M},
                        new ProductModel(){ProductName = "Product 2", Sales = 160M},
                    }
                }
            };
        }

        public static List<VehicleMake> VehicleMakes()
        {
            return new List<VehicleMake> {
                new VehicleMake { Company = "Tesla", Count = 314159 },
                new VehicleMake { Company = "VW", Count = 112645  },
            };
        }

        public static Dictionary<string, List<VehicleModel>> VehicleModels()
        {
            var vehiclesByModel = new Dictionary<string, List<VehicleModel>>
            {
                {
                    "Tesla",
                    new List<VehicleModel>()
                    {
                        new VehicleModel { Model = "Model 3", Count = 225350},
                        new VehicleModel { Model = "Model Y", Count = 40159}
                    }
                },

                {
                    "VW",
                    new List<VehicleModel>()
                    {
                        new VehicleModel { Model = "ID.3", Count = 60274},
                        new VehicleModel { Model = "ID.4", Count = 20302}
                    }
                }
            };

            return vehiclesByModel;
        }

        public static Dictionary<string, List<Quarter>> VehicleQuarters()
        {
            var vehiclesByModel = new Dictionary<string, List<Quarter>>
            {
                {
                    "Model 3",
                    new List<Quarter>()
                    {
                        new Quarter { Period = "2022 Q1", Count = 97436},
                        new Quarter { Period = "2022 Q2", Count = 103436},
                        new Quarter { Period = "2022 Q3", Count = 113461}
                    }
                },

                {
                    "Model Y",
                    new List<Quarter>()
                    {
                        new Quarter { Period = "2022 Q1", Count = 7738},
                        new Quarter { Period = "2022 Q2", Count = 11932},
                        new Quarter { Period = "2022 Q3", Count = 20489}
                    }
                },

                {
                    "ID.3",
                    new List<Quarter>()
                    {
                        new Quarter { Period = "2022 Q1", Count = 18164},
                        new Quarter { Period = "2022 Q2", Count = 20087},
                        new Quarter { Period = "2022 Q3", Count = 22023}
                    }
                },

                {
                    "ID.4",
                    new List<Quarter>()
                    {
                        new Quarter { Period = "2022 Q1", Count = 5841},
                        new Quarter { Period = "2022 Q2", Count = 6715},
                        new Quarter { Period = "2022 Q3", Count = 7746}
                    }
                }
            };

            return vehiclesByModel;
        }
    }
}
