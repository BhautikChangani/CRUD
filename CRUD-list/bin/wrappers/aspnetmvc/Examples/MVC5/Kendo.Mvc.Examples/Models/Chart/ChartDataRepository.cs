using System.Collections.Generic;
using System;
using Kendo.Mvc.Examples.Models.Chart;

namespace Kendo.Mvc.Examples.Models
{
    public partial class ChartDataRepository
    {
        public static IList<AprilSales> AprilSalesData() 
        {
            return new AprilSales[]
            {
                new AprilSales(2373, 5000, "1"),
                new AprilSales(3283, 5250, "2"),
                new AprilSales(4532, 5500, "3"),
                new AprilSales(4620, 5750, "4"),
                new AprilSales(6504, 6000, "5"),
                new AprilSales(6715, 6250, "6"),
                new AprilSales(6234, 6500, "7"),
                new AprilSales(6750, 6750, "8"),
                new AprilSales(6300, 7000, "9"),
                new AprilSales(6459, 7250, "10"),
                new AprilSales(8305, 7500, "11"),
                new AprilSales(7222, 7750, "12"),
                new AprilSales(6734, 8000, "13"),
                new AprilSales(7863, 8250, "14"),
                new AprilSales(8743, 8500, "15"),
                new AprilSales(8846, 8750, "16"),
                new AprilSales(8567, 9000, "17"),
                new AprilSales(8193, 9250, "18"),
                new AprilSales(9458, 9500, "19"),
                new AprilSales(9254, 9750, "20"),
                new AprilSales(10234, 10000, "21"),
                new AprilSales(9608, 10250, "22"),
                new AprilSales(9350, 10500, "23"),
                new AprilSales(8842, 10500, "24"),
                new AprilSales(8349, 10500, "25"),
                new AprilSales(8846, 10500, "26"),
                new AprilSales(9567, 10500, "27"),
                new AprilSales(10734, 10500, "28"),
                new AprilSales(10124, 10500, "29"),
                new AprilSales(9680, 10500, "30"),
            };
        }

        public static IList<PricePerformance> PricePerformanceData()
        {
            return new List<PricePerformance>
            {
                new PricePerformance {
                    Family = "Pentium",
                    Model = "D 820",
                    Price = 105,
                    Performance = 100
                },
                
                new PricePerformance {
                    Family = "Pentium",
                    Model = "D 915",
                    Price = 120,
                    Performance = 102
                }, 
                
                new PricePerformance {
                    Family = "Pentium",
                    Model = "D 945",
                    Price = 160,
                    Performance = 118
                }, 
                
                new PricePerformance {
                    Family = "Pentium",
                    Model = "XE 965",
                    Price = 1000,
                    Performance = 137
                }, 
                
                new PricePerformance {
                    Family = "Core 2 Duo",
                    Model = "E6300",
                    Price = 185,
                    Performance = 134
                }, 
                
                new PricePerformance {
                    Family = "Core 2 Duo",
                    Model = "E6400",
                    Price = 210,
                    Performance = 143
                }, 
                
                new PricePerformance {
                    Family = "Core 2 Duo",
                    Model = "E6600",
                    Price = 305,
                    Performance = 163
                }, 
                
                new PricePerformance {
                    Family = "Core 2 Duo",
                    Model = "E6700",
                    Price = 530,
                    Performance = 177
                }, 
                
                new PricePerformance {
                    Family = "Core 2 Extreme",
                    Model = "X6800",
                    Price = 1000,
                    Performance = 190
                }, 
                
                new PricePerformance {
                    Family = "Athlon 64",
                    Model = "X2 3800+",
                    Price = 148,
                    Performance = 115
                }, 
            
                new PricePerformance {
                    Family = "Athlon 64",
                    Model = "X2 4200+",
                    Price = 170,
                    Performance = 125
                }, 
                
                new PricePerformance {
                    Family = "Athlon 64",
                    Model = "X2 4600+",
                    Price = 205,
                    Performance = 138
                }, 
                
                new PricePerformance {
                    Family = "Athlon 64",
                    Model = "X2 5000+",
                    Price = 290,
                    Performance = 143
                }, 
                
                new PricePerformance {
                    Family = "Athlon 64",
                    Model = "FX-62",
                    Price = 800,
                    Performance = 147
                }
            };
        }

        public static IList<SiteOptimizationItem> BeforeOptimizationData()
        {
            return new List<SiteOptimizationItem>
            {
                new SiteOptimizationItem{
                    Description= "All Visitors",
                    Visitors= 23945
                }, 
                new SiteOptimizationItem{
                    Description= "Tried the Demos",
                    Visitors= 19156
                }, 
                new SiteOptimizationItem{
                    Description= "Downloaded",
                    Visitors= 13984
                }, 
                new SiteOptimizationItem{
                    Description= "Requested a Quote",
                    Visitors= 3216
                }, 
                new SiteOptimizationItem{
                    Description= "Purchased",
                    Visitors= 1673
                }
            };
        }

        public static IList<SiteOptimizationItem> AfterOptimizationData()
        {
            return new List<SiteOptimizationItem>
            {
                new SiteOptimizationItem{
                    Description= "All Visitors",
                    Visitors= 28536
                },
                new SiteOptimizationItem{
                    Description= "Tried the Demos",
                    Visitors= 26539
                },
                new SiteOptimizationItem{
                    Description= "Downloaded",
                    Visitors= 23088
                },
                new SiteOptimizationItem{
                    Description= "Requested a Quote",
                    Visitors= 13853
                },
                new SiteOptimizationItem{
                    Description= "Purchased",
                    Visitors= 9697
                }
            };
        }

        public static IList<EngineDataPoint> EngineData()
        {
            return new EngineDataPoint[]
            {
                new EngineDataPoint(1000, 50,  10),
                new EngineDataPoint(1500, 65,  19),
                new EngineDataPoint(2000, 80,  30),
                new EngineDataPoint(2500, 92,  44),
                new EngineDataPoint(3000, 104, 59),
                new EngineDataPoint(3500, 114, 76),
                new EngineDataPoint(4000, 120, 91),
                new EngineDataPoint(4500, 125, 107),
                new EngineDataPoint(5000, 130, 124),
                new EngineDataPoint(5500, 133, 139),
                new EngineDataPoint(6000, 130, 149),
                new EngineDataPoint(6500, 122, 151),
                new EngineDataPoint(7000, 110, 147)
            };
        }

        public static IList<InternetUsers> InternetUsers()
        {
            return new InternetUsers[] {
                new InternetUsers(1994,4.9,"United States"),
                new InternetUsers(1995,9.2,"United States"),
                new InternetUsers(1996,16.4,"United States"),
                new InternetUsers(1997,21.6,"United States"),
                new InternetUsers(1998,30.1,"United States"),
                new InternetUsers(1999,35.9,"United States"),
                new InternetUsers(2000,43.1,"United States"),
                new InternetUsers(2001,49.2,"United States"),
                new InternetUsers(2002,59.0,"United States"),
                new InternetUsers(2003,61.9,"United States"),
                new InternetUsers(2004,65,"United States"),
                new InternetUsers(2005,68.3,"United States"),
                new InternetUsers(2006,69.2,"United States"),
                new InternetUsers(2007,75.3,"United States"),
                new InternetUsers(2008,74.2,"United States"),
                new InternetUsers(2009,71.2,"United States"),
                new InternetUsers(2010,74.2,"United States"),
                new InternetUsers(2011,78.2,"United States")
            };
        }

        public static IList<GrandSlam> GrandSlam()
        {
            return new GrandSlam[] {
                new GrandSlam(2003, 13, 3, "MIN: 13"),
                new GrandSlam(2004, 22, 1),
                new GrandSlam(2005, 24, 2),
                new GrandSlam(2006, 27, 1, "MAX: 27"),
                new GrandSlam(2007, 26, 1),
                new GrandSlam(2008, 24, 3),
                new GrandSlam(2009, 26, 2),
                new GrandSlam(2010, 20, 3),
                new GrandSlam(2011, 20, 4),
                new GrandSlam(2012, 19, 3),
            };
        }

        public static IEnumerable<ElectricityProduction> SpainElectricityProduction()
        {
            return new ElectricityProduction[] {
                new ElectricityProduction("2000", 18, 31807, 4727, 62206),
                new ElectricityProduction("2001", 24, 43864, 6759, 63708),
                new ElectricityProduction("2002", 30, 26270, 9342, 63016),
                new ElectricityProduction("2003", 41, 43897, 12075, 61875),
                new ElectricityProduction("2004", 56, 34439, 15700, 63606),
                new ElectricityProduction("2005", 41, 23025, 21176, 57539),
                new ElectricityProduction("2006", 119, 29831, 23297, 60126),
                new ElectricityProduction("2007", 508, 30522, 27568, 55103),
                new ElectricityProduction("2008", 2578, 26112, 32203, 58973)
            };
        }

        public static IList<ScreenResolution> WorldScreenResolution()
        {
            return new ScreenResolution[] {
                new ScreenResolution() {Year = "2000",Resolution = "1024x768",Share = 25,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2000",Resolution = "Other",Share = 75,VisibleInLegend = false,OrderNumber = 2},
                new ScreenResolution() {Year = "2001",Resolution = "1024x768",Share = 29,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2001",Resolution = "Other",Share = 71,VisibleInLegend = false,OrderNumber = 2},
                new ScreenResolution() {Year = "2002",Resolution = "1024x768",Share = 34,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2002",Resolution = "Other",Share = 66,VisibleInLegend = false,OrderNumber = 2},
                new ScreenResolution() {Year = "2003",Resolution = "1024x768",Share = 40,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2003",Resolution = "Other",Share = 60,VisibleInLegend = false,OrderNumber = 2},
                new ScreenResolution() {Year = "2004",Resolution = "1024x768",Share = 47,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2004",Resolution = "Other",Share = 53,VisibleInLegend = false,OrderNumber = 2},
                new ScreenResolution() {Year = "2005",Resolution = "1024x768",Share = 53,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2005",Resolution = "Other",Share = 47,VisibleInLegend = false,OrderNumber = 2},
                new ScreenResolution() {Year = "2006",Resolution = "1024x768",Share = 57,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2006",Resolution = "Other",Share = 43,VisibleInLegend = false,OrderNumber = 2},
                new ScreenResolution() {Year = "2007",Resolution = "1024x768",Share = 54,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2007",Resolution = "Other",Share = 46,VisibleInLegend = false,OrderNumber = 2},
                new ScreenResolution() {Year = "2008",Resolution = "1024x768",Share = 48,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2008",Resolution = "Other",Share = 52,VisibleInLegend = false,OrderNumber = 2},
                new ScreenResolution() {Year = "2009",Resolution = "1024x768",Share = 36,VisibleInLegend = false,OrderNumber = 1},
                new ScreenResolution() {Year = "2009",Resolution = "Other",Share = 64,VisibleInLegend = false,OrderNumber = 2}
            };
        }

        public static IEnumerable<ElectricitySource> SpainElectricityBreakdown()
        {
            return new ElectricitySource[] {
                new ElectricitySource("Hydro", 22) { Explode = true },
                new ElectricitySource("Solar", 2),
                new ElectricitySource("Nuclear", 49),
                new ElectricitySource("Wind", 27)
            };
        }

        public static IList<Medals> Medals()
        {
            return new Medals[] {
                new Medals(1984,1,10,"Japan"),
                new Medals(1988,1,4,"Japan"),
                new Medals(1992,1,3,"Japan"),
                new Medals(1996,1,3,"Japan"),
                new Medals(2000,1,5,"Japan"),
                new Medals(2004,1,16,"Japan"),
                new Medals(2008,1,9,"Japan"),
                new Medals(2012,1,7,"Japan"),
                new Medals(1984,2,8,"Japan"),
                new Medals(1988,2,3,"Japan"),
                new Medals(1992,2,8,"Japan"),
                new Medals(1996,2,6,"Japan"),
                new Medals(2000,2,8,"Japan"),
                new Medals(2004,2,9,"Japan"),
                new Medals(2008,2,6,"Japan"),
                new Medals(2012,2,14,"Japan"),
                new Medals(1984,3,14,"Japan"),
                new Medals(1988,3,7,"Japan"),
                new Medals(1992,3,11,"Japan"),
                new Medals(1996,3,5,"Japan"),
                new Medals(2000,3,5,"Japan"),
                new Medals(2004,3,12,"Japan"),
                new Medals(2008,3,10,"Japan"),
                new Medals(2012,3,17,"Japan") 
            };
        }

        public static IList<BlogComments> BlogComments()
        {
            return new BlogComments[] {
                 new BlogComments("My blog", 1, 3),
                 new BlogComments("My blog", 2, 7),
                 new BlogComments("My blog", 3, 12),
                 new BlogComments("My blog", 4, 15),
                 new BlogComments("My blog", 5, 6),
                 new BlogComments("My blog", 6, 23),
                 new BlogComments("My blog", 7, 12),
                 new BlogComments("My blog", 8, 10),
                 new BlogComments("My blog", 9, 17),
                 new BlogComments("My blog", 10, 13),
                 new BlogComments("My blog", 11, 14),
                 new BlogComments("My blog", 12, 15),
                 new BlogComments("My blog", 13, 3),
                 new BlogComments("My blog", 14, 6),
                 new BlogComments("My blog", 15, 23),
                 new BlogComments("My blog", 16, 25),
                 new BlogComments("My blog", 17, 21),
                 new BlogComments("My blog", 18, 18),
                 new BlogComments("My blog", 19, 17),
                 new BlogComments("My blog", 20, 16),
                 new BlogComments("My blog", 21, 11),
                 new BlogComments("My blog", 22, 3),
                 new BlogComments("My blog", 23, 8),
                 new BlogComments("My blog", 24, 5),
                 new BlogComments("My blog", 25, 4),
                 new BlogComments("My blog", 26, 1),
                 new BlogComments("My blog", 27, 7),
                 new BlogComments("My blog", 28, 6),
                 new BlogComments("My blog", 29, 3),
                 new BlogComments("My blog", 30, 6) 
            };
        }

        public static IList<JobGrowth> JobGrowthData()
        {
            return new JobGrowth[] {
                new JobGrowth {
                    Growth = -2500,
                    Jobs = 50000,
                    Applications = 500000,
                    Company = "Microsoft"
                }, new JobGrowth {
                    Growth = 500,
                    Jobs = 110000,
                    Applications = 7600000,
                    Company = "Starbucks"
                }, new JobGrowth {
                    Growth = 7000,
                    Jobs = 19000,
                    Applications = 700000,
                    Company = "Google"
                }, new JobGrowth {
                    Growth = 1400,
                    Jobs = 150000,
                    Applications = 700000,
                    Company = "Publix Super Markets"
                }, new JobGrowth {
                    Growth = 2400,
                    Jobs = 30000,
                    Applications = 300000,
                    Company = "PricewaterhouseCoopers"
                }, new JobGrowth {
                    Growth = 2450,
                    Jobs = 34000,
                    Applications = 90000,
                    Company = "Cisco"
                }, new JobGrowth {
                    Growth = 2700,
                    Jobs = 34000,
                    Applications = 400000,
                    Company = "Accenture"
                }, new JobGrowth {
                    Growth = 2900,
                    Jobs = 40000,
                    Applications = 450000,
                    Company = "Deloitte"
                }, new JobGrowth {
                    Growth = 3000,
                    Jobs = 55000,
                    Applications = 900000,
                    Company = "Whole Foods Market"
                }
            };
        }

        public static IList<JobGrowth> JobGrowthDataComparative()
        {
            return new JobGrowth[] {
                new JobGrowth {
                    Growth = -2500,
                    Jobs = 50000,
                    Applications = 500000,
                    Company = "Microsoft",
                    Year = 2011
                }, new JobGrowth {
                    Growth = 500,
                    Jobs = 110000,
                    Applications = 7600000,
                    Company = "Starbucks",
                    Year = 2011
                }, new JobGrowth {
                    Growth = 7000,
                    Jobs = 19000,
                    Applications = 700000,
                    Company = "Google",
                    Year = 2011
                }, 
                new JobGrowth {
                    Growth = -2000,
                    Jobs = 60000,
                    Applications = 900000,
                    Company = "Microsoft",
                    Year = 2012
                }, new JobGrowth {
                    Growth = 4000,
                    Jobs = 130000,
                    Applications = 8600000,
                    Company = "Starbucks",
                    Year = 2012
                }, new JobGrowth {
                    Growth = 9000,
                    Jobs = 29000,
                    Applications = 2200000,
                    Company = "Google",
                    Year = 2012
                }
            };
        }

        public static IList<MarriagesDivorcesData> MarriagesDivorcesStats()
        {
            return new MarriagesDivorcesData[] {
                new MarriagesDivorcesData {
                    State = "Alabama",
                    Marriages = 7,
                    Divorces = 3.7,
                    Population = 4627851
                },
                new MarriagesDivorcesData {
                    State = "Alaska",
                    Marriages = 6.9,
                    Divorces = 3.6,
                    Population = 686293
                },
                new MarriagesDivorcesData {
                    State = "Arizona",
                    Marriages = 5.8,
                    Divorces = 2.5,
                    Population = 6500180
                },
                new MarriagesDivorcesData {
                    State = "Arkansas",
                    Marriages = 10.2,
                    Divorces = 5.7,
                    Population = 2855390
                },
                new MarriagesDivorcesData {
                    State = "California",
                    Marriages = 8.1,
                    Divorces = 4.1,
                    Population = 36756666
                },
                new MarriagesDivorcesData {
                    State = "Colorado",
                    Marriages = 12.1,
                    Divorces = 3.2,
                    Population = 4861515
                },
                new MarriagesDivorcesData {
                    State = "Connecticut",
                    Marriages = 7,
                    Divorces = 3.2,
                    Population = 3501252
                },
                new MarriagesDivorcesData {
                    State = "Delaware",
                    Marriages = 5.5,
                    Divorces = 1.9,
                    Population = 873092
                },
                new MarriagesDivorcesData {
                    State = "Florida",
                    Marriages = 7.8,
                    Divorces = 3.6,
                    Population = 18328340
                },
                new MarriagesDivorcesData {
                    State = "Georgia",
                    Marriages = 15.1,
                    Divorces = 5.2,
                    Population = 9685744
                },
                new MarriagesDivorcesData {
                    State = "Hawaii",
                    Marriages = 12.6,
                    Divorces = 6,
                    Population = 1288198
                },
                new MarriagesDivorcesData {
                    State = "Idaho",
                    Marriages = 15.7,
                    Divorces = 7.1,
                    Population = 1523816
                },
                new MarriagesDivorcesData {
                    State = "Illinois",
                    Marriages = 6.4,
                    Divorces = 1.9,
                    Population = 12901563
                },
                new MarriagesDivorcesData {
                    State = "Indiana",
                    Marriages = 6.9,
                    Divorces = 4.9,
                    Population = 6376792
                },
                new MarriagesDivorcesData {
                    State = "Iowa",
                    Marriages = 8.2,
                    Divorces = 2,
                    Population = 3002555
                },
                new MarriagesDivorcesData {
                    State = "Kansas",
                    Marriages = 8.1,
                    Divorces = 1.3,
                    Population = 2802134
                },
                new MarriagesDivorcesData {
                    State = "Kentucky",
                    Marriages = 9.2,
                    Divorces = 7.1,
                    Population = 4269245
                },
                new MarriagesDivorcesData {
                    State = "Louisiana",
                    Marriages = 7.1,
                    Divorces = 1.8,
                    Population = 4410796
                },
                new MarriagesDivorcesData {
                    State = "Maine",
                    Marriages = 9.6,
                    Divorces = 4.2,
                    Population = 1316456
                },
                new MarriagesDivorcesData {
                    State = "Maryland",
                    Marriages = 6.3,
                    Divorces = 3.5,
                    Population = 5633597
                },
                new MarriagesDivorcesData {
                    State = "Massachusetts",
                    Marriages = 13.1,
                    Divorces = 8,
                    Population = 6497967
                },
                new MarriagesDivorcesData {
                    State = "Michigan",
                    Marriages = 8.1,
                    Divorces = 2.9,
                    Population = 10003422
                },
                new MarriagesDivorcesData {
                    State = "Minnesota",
                    Marriages = 9.5,
                    Divorces = 4.5,
                    Population = 5220393
                },
                new MarriagesDivorcesData {
                    State = "Mississippi",
                    Marriages = 6.7,
                    Divorces = 2.9,
                    Population = 2938618
                },
                new MarriagesDivorcesData {
                    State = "Missouri",
                    Marriages = 16.6,
                    Divorces = 3.1,
                    Population = 5911605
                },
                new MarriagesDivorcesData {
                    State = "Montana",
                    Marriages = 15,
                    Divorces = 9.1,
                    Population = 967440
                },
                new MarriagesDivorcesData {
                    State = "Nebraska",
                    Marriages = 13.3,
                    Divorces = 1.2,
                    Population = 1783432
                },
                new MarriagesDivorcesData {
                    State = "Nevada",
                    Marriages = 21.2,
                    Divorces = 8.5,
                    Population = 2600167
                },
                new MarriagesDivorcesData {
                    State = "New Hampshire",
                    Marriages = 11.8,
                    Divorces = 7.1,
                    Population = 1315809
                },
                new MarriagesDivorcesData {
                    State = "New Jersey",
                    Marriages = 15.1,
                    Divorces = 7.4,
                    Population = 8682661
                },
                new MarriagesDivorcesData {
                    State = "New Mexico",
                    Marriages = 3.1,
                    Divorces = 4.8,
                    Population = 1984356
                },
                new MarriagesDivorcesData {
                    State = "New York",
                    Marriages = 17.3,
                    Divorces = 9.1,
                    Population = 19490297
                },
                new MarriagesDivorcesData {
                    State = "North Carolina",
                    Marriages = 13.1,
                    Divorces = 1.6,
                    Population = 9222414
                },
                new MarriagesDivorcesData {
                    State = "North Dakota",
                    Marriages = 5.8,
                    Divorces = 2.5,
                    Population = 641481
                },
                new MarriagesDivorcesData {
                    State = "Ohio",
                    Marriages = 18.9,
                    Divorces = 7.9,
                    Population = 11485910
                },
                new MarriagesDivorcesData {
                    State = "Oklahoma",
                    Marriages = 9.1,
                    Divorces = 4.1,
                    Population = 3642361
                },
                new MarriagesDivorcesData {
                    State = "Oregon",
                    Marriages = 7,
                    Divorces = 3.4,
                    Population = 3790060
                },
                new MarriagesDivorcesData {
                    State = "Pennsylvania",
                    Marriages = 9.1,
                    Divorces = 2.6,
                    Population = 12448279
                },
                new MarriagesDivorcesData {
                    State = "Rhode Island",
                    Marriages = 6.8,
                    Divorces = 2.9,
                    Population = 1050788
                },
                new MarriagesDivorcesData {
                    State = "South Carolina",
                    Marriages = 16,
                    Divorces = 2.6,
                    Population = 4479800
                },
                new MarriagesDivorcesData {
                    State = "South Dakota",
                    Marriages = 6.7,
                    Divorces = 2.7,
                    Population = 804194
                },
                new MarriagesDivorcesData {
                    State = "Tennessee",
                    Marriages = 18.1,
                    Divorces = 1.6,
                    Population = 6214888
                },
                new MarriagesDivorcesData {
                    State = "Texas",
                    Marriages = 7.1,
                    Divorces = 0.8,
                    Population = 24326974
                },
                new MarriagesDivorcesData {
                    State = "Utah",
                    Marriages = 19.4,
                    Divorces = 3.4,
                    Population = 2736424
                },
                new MarriagesDivorcesData {
                    State = "Vermont",
                    Marriages = 14.1,
                    Divorces = 3.4,
                    Population = 621270
                },
                new MarriagesDivorcesData {
                    State = "Virginia",
                    Marriages = 10,
                    Divorces = 3.1,
                    Population = 7769089
                },
                new MarriagesDivorcesData {
                    State = "Washington",
                    Marriages = 7.5,
                    Divorces = 3.4,
                    Population = 6549224
                },
                new MarriagesDivorcesData {
                    State = "West Virginia",
                    Marriages = 8.3,
                    Divorces = 2.8,
                    Population = 1814468
                },
                new MarriagesDivorcesData {
                    State = "Wisconsin",
                    Marriages = 7.9,
                    Divorces = 2.4,
                    Population = 5627967
                },
                new MarriagesDivorcesData {
                    State = "Wyoming",
                    Marriages = 9.5,
                    Divorces = 4,
                    Population = 532668
                }
            };
        }

        public static IList<DatePoint> DatePoints() 
        {
            return new DatePoint[]
            {
                new DatePoint(30, DateTime.Parse("2011/12/20")),
                new DatePoint(50, DateTime.Parse("2011/12/21")),
                new DatePoint(45, DateTime.Parse("2011/12/22")),
                new DatePoint(40, DateTime.Parse("2011/12/23")),
                new DatePoint(35, DateTime.Parse("2011/12/24")),
                new DatePoint(40, DateTime.Parse("2011/12/25")),
                new DatePoint(42, DateTime.Parse("2011/12/26")),
                new DatePoint(40, DateTime.Parse("2011/12/27")),
                new DatePoint(35, DateTime.Parse("2011/12/28")),
                new DatePoint(43, DateTime.Parse("2011/12/29")),
                new DatePoint(38, DateTime.Parse("2011/12/30")),
                new DatePoint(30, DateTime.Parse("2011/12/31")),
                new DatePoint(48, DateTime.Parse("2012/01/01")),
                new DatePoint(50, DateTime.Parse("2012/01/02")),
                new DatePoint(55, DateTime.Parse("2012/01/03")),
                new DatePoint(35, DateTime.Parse("2012/01/04")),
                new DatePoint(30, DateTime.Parse("2012/01/05"))  
            };
        }

        public static IList<DownloadSpeed> DownloadSpeeds()
        {
            return new DownloadSpeed[]
            {
                new DownloadSpeed(30, 35, 80, 90, "Monday"),
                new DownloadSpeed(60, 70, 60, 70, "Tuesday"),
                new DownloadSpeed(50, 60, 70, 100, "Wednesday"),
                new DownloadSpeed(30, 50, 100, 140, "Thursday"),
                new DownloadSpeed(40, 50, 90, 110, "Friday"),
                new DownloadSpeed(50, 60, 80, 100, "Saturday"),
                new DownloadSpeed(30, 40, 50, 70, "Sunday")
            };
        }

        public static IList<Forecast> ForecastData()
        {
            return new List<Forecast>()
            {
                new Forecast 
                {
                    Temperature = 15,
                    Weather = "cloudy",
                    Day = "Monday"
                }, 
                new Forecast 
                {
                    Temperature = 16,
                    Weather = "rainy",
                    Day = "Tuesday"
                }, 
                new Forecast 
                {
                    Temperature = 20,
                    Weather = "cloudy",
                    Day = "Wednesday"
                }, 
                new Forecast 
                {
                    Temperature = 23,
                    Weather = "sunny",
                    Day = "Thursday"
                }, 
                new Forecast 
                {
                    Temperature = 17,
                    Weather = "cloudy",
                    Day = "Friday"
                }, 
                new Forecast 
                {
                    Temperature = 20,
                    Weather = "sunny",
                    Day = "Saturday"
                }, 
                new Forecast 
                {
                    Temperature = 25,
                    Weather = "sunny",
                    Day = "Sunday"
                } 

            };
        }

        public static IList<ChartCategoryPoint> PanAndZoomData()
        {
            IList<ChartCategoryPoint> data = new List<ChartCategoryPoint>();
            Random random = new Random(0);
            for (var i = 0; i < 100; i++) 
            {
                var value = random.Next(0, 11);
                data.Add( new ChartCategoryPoint
                {
                    Category = "C" + i,
                    Value = value
                });
            }

            return data;
        }

        public static IList<ChartScatterPoint> SineInterval(double min, double max)
        {
            IList<ChartScatterPoint> data = new List<ChartScatterPoint>();
            var step = Math.PI / 4;
            for (var i = min; i < max; i += step)
            {
                data.Add(new ChartScatterPoint
                {
                    X = i,
                    Y = Math.Sin(i)
                });
            }

            return data;
        }

        public static IList<SalesPerQuarterViewModel> SalesPerQuarter()
        {
            return new List<SalesPerQuarterViewModel>()
            {
                new SalesPerQuarterViewModel
                {
                    Period = "2010 Q1",
                    Date = new DateTime(2010, 1, 1),
                    Amount = 4485.0
                },
                new SalesPerQuarterViewModel
                {
                   Period = "2010 Q2",
                   Date = new DateTime(2010, 4, 1),
                   Amount = 4409.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2010 Q3",
                    Date = new DateTime(2010, 7, 1),
                    Amount = 4469.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2010 Q4",
                    Date = new DateTime(2010, 10, 1),
                    Amount = 4682.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2011 Q1",
                    Date = new DateTime(2011, 1, 1),
                    Amount = 5610.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2011 Q2",
                    Date = new DateTime(2011, 4, 1),
                    Amount = 6580.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2011 Q3",
                    Date = new DateTime(2011, 7, 1),
                    Amount = 7534.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2011 Q4",
                    Date = new DateTime(2011, 10, 1),
                    Amount = 7894.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2012 Q1",
                    Date = new DateTime(2012, 1, 1),
                    Amount = 8748.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2012 Q2",
                    Date = new DateTime(2012, 4, 1),
                    Amount = 10223.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2012 Q3",
                    Date = new DateTime(2012, 7, 1),
                    Amount = 10797.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2012 Q4",
                    Date = new DateTime(2012, 10, 1),
                    Amount = 12295.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2013 Q1",
                    Date = new DateTime(2013, 1, 1),
                    Amount = 13153.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2013 Q2",
                    Date = new DateTime(2013, 4, 1),
                    Amount = 14628.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2013 Q3",
                    Date = new DateTime(2013, 7, 1),
                    Amount = 16779.0
                },
                new SalesPerQuarterViewModel
                {
                   Period = "2013 Q4",
                   Date = new DateTime(2013, 10, 1),
                   Amount = 18710.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2014 Q1",
                    Date = new DateTime(2014, 1, 1),
                    Amount = 22219.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2014 Q2",
                    Date = new DateTime(2014, 4, 1),
                    Amount = 25886.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2014 Q3",
                    Date = new DateTime(2014, 7, 1),
                    Amount = 31640.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2014 Q4",
                    Date = new DateTime(2014, 10, 1),
                    Amount = 36846.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2015 Q1",
                    Date = new DateTime(2015, 1, 1),
                    Amount = 43433.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2015 Q2",
                    Date = new DateTime(2015, 4, 1),
                    Amount = 48575.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2015 Q3",
                    Date = new DateTime(2015, 7, 1),
                    Amount = 54533.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2015 Q4",
                    Date = new DateTime(2015, 10, 1),
                    Amount = 62388.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2016 Q1",
                    Date = new DateTime(2016, 1, 1),
                    Amount = 70706.0
                },
                new SalesPerQuarterViewModel
                {
                   Period = "2016 Q2",
                   Date = new DateTime(2016, 4, 1),
                   Amount = 75439.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2016 Q3",
                    Date = new DateTime(2016, 7, 1),
                    Amount = 83213.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2016 Q4",
                    Date = new DateTime(2016, 10, 1),
                    Amount = 88527.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2017 Q1",
                    Date = new DateTime(2017, 1, 1),
                    Amount = 99865.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2017 Q2",
                    Date = new DateTime(2017, 4, 1),
                    Amount = 107388.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2017 Q3",
                    Date = new DateTime(2017, 7, 1),
                    Amount = 117761.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2017 Q4",
                    Date = new DateTime(2017, 10, 1),
                    Amount = 125263.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2018 Q1",
                    Date = new DateTime(2018, 1, 1),
                    Amount = 135950.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2018 Q2",
                    Date = new DateTime(2018, 4, 1),
                    Amount = 144737.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2018 Q3",
                    Date = new DateTime(2018, 7, 1),
                    Amount = 155933.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2018 Q4",
                    Date = new DateTime(2018, 10, 1),
                    Amount = 167960.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2019 Q1",
                    Date = new DateTime(2019, 1, 1),
                    Amount = 182725.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2019 Q2",
                    Date = new DateTime(2019, 4, 1),
                    Amount = 199079.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2019 Q3",
                    Date = new DateTime(2019, 7, 1),
                    Amount = 234952.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2019 Q4",
                    Date = new DateTime(2019, 10, 1),
                    Amount = 271298.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2020 Q1",
                    Date = new DateTime(2020, 1, 1),
                    Amount = 323309.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2020 Q2",
                    Date = new DateTime(2020, 4, 1),
                    Amount = 358145.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2020 Q3",
                    Date = new DateTime(2020, 7, 1),
                    Amount = 460927.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2020 Q4",
                    Date = new DateTime(2020, 10, 1),
                    Amount = 579568.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2021 Q1",
                    Date = new DateTime(2021, 1, 1),
                    Amount = 669590.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2021 Q2",
                    Date = new DateTime(2021, 4, 1),
                    Amount = 793564.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2021 Q3",
                    Date = new DateTime(2021, 7, 1),
                    Amount = 941133.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2021 Q4",
                    Date = new DateTime(2021, 10, 1),
                    Amount = 1133020.0
                },
                new SalesPerQuarterViewModel
                {
                    Period = "2022 Q1",
                    Date = new DateTime(2022, 1, 1),
                    Amount = 426324.0
                }
            };
        }
    }
}