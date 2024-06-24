using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models
{
    public class DetailProductService : IDisposable
    {
        private static bool UpdateDatabase = false;
        private DemoDBContext entities;

        public DetailProductService(DemoDBContext entities)
        {
            this.entities = entities;
        }

        public IList<DetailProductViewModel> GetDetailProducts()
        {
            var result = HttpContext.Current.Session["DetailProducts"] as IList<DetailProductViewModel>;

            if (result == null || UpdateDatabase)
            {
                result = entities.DetailProducts.Select(product => new DetailProductViewModel
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice.HasValue ? product.UnitPrice.Value : default(decimal),
                    UnitsInStock = product.UnitsInStock.HasValue ? product.UnitsInStock.Value : default(short),
                    QuantityPerUnit = product.QuantityPerUnit,
                    Discontinued = product.Discontinued,
                    UnitsOnOrder = product.UnitsOnOrder.HasValue ? (int)product.UnitsOnOrder.Value : default(int),
                    CategoryID = product.CategoryID,
                    Country = new CountryViewModel()
                    {
                        CountryID = product.Country.CountryID,
                        CountryNameShort = product.Country.CountryNameShort,
                        CountryNameLong = product.Country.CountryNameLong
                    },
                    CustomerRating = product.CustomerRating,
                    TargetSales = product.TargetSales,
                    CountryID = product.CountryID,
                    Category = new CategoryViewModel()
                    {
                        CategoryID = product.Category.CategoryID,
                        CategoryName = product.Category.CategoryName
                    },
                    LastSupply = DateTime.Today
                }).ToList();

                HttpContext.Current.Session["Products"] = result;
            }

            return result;
        }

        public IEnumerable<DetailProductViewModel> Read()
        {
            return GetDetailProducts();
        }

        public void Create(DetailProductViewModel product)
        {
            if (!UpdateDatabase)
            {
                var first = GetDetailProducts().OrderByDescending(e => e.ProductID).FirstOrDefault();
                var id = (first != null) ? first.ProductID : 0;

                product.ProductID = id + 1;

                if (product.CategoryID == null)
                {
                    product.CategoryID = 1;
                }

                if (product.Category == null)
                {
                    product.Category = new CategoryViewModel() { CategoryID = 1, CategoryName = "Beverages" };
                }

                if (product.CountryID == null)
                {
                    product.CountryID = 1;
                }

                if (product.Country == null)
                {
                    product.Country = new CountryViewModel() { CountryID = 1, CountryNameShort = "bg", CountryNameLong = "Bulgaria" };
                }



                GetDetailProducts().Insert(0, product);
            }
            else
            {
                var entity = new DetailProduct();

                entity.ProductName = product.ProductName;
                entity.UnitPrice = product.UnitPrice;
                entity.UnitsInStock = (short)product.UnitsInStock;
                entity.Discontinued = product.Discontinued;
                entity.CategoryID = product.CategoryID;
                entity.CustomerRating = product.CustomerRating;
                entity.TargetSales = product.TargetSales;

                if (entity.CategoryID == null)
                {
                    entity.CategoryID = 1;
                }

                if (product.Category != null)
                {
                    entity.CategoryID = product.Category.CategoryID;
                }

                if (product.CountryID == null)
                {
                    product.CountryID = 1;
                }

                if (product.Country != null)
                {
                    entity.CountryID = product.Country.CountryID;
                }

                entities.DetailProducts.Add(entity);
                entities.SaveChanges();

                product.ProductID = entity.ProductID;
            }
        }

        public void Update(DetailProductViewModel product)
        {
            if (!UpdateDatabase)
            {
                var target = One(e => e.ProductID == product.ProductID);

                if (target != null)
                {
                    target.ProductName = product.ProductName;
                    target.UnitPrice = product.UnitPrice;
                    target.UnitsInStock = product.UnitsInStock;
                    target.Discontinued = product.Discontinued;
                    target.CustomerRating = product.CustomerRating;
                    target.TargetSales = product.TargetSales;

                    if (product.CategoryID == null)
                    {
                        product.CategoryID = 1;
                    }

                    if (product.Category != null)
                    {
                        product.CategoryID = product.Category.CategoryID;
                    }
                    else
                    {
                        product.Category = new CategoryViewModel()
                        {
                            CategoryID = (int)product.CategoryID,
                            CategoryName = entities.Categories.Where(s => s.CategoryID == product.CategoryID).Select(s => s.CategoryName).First()
                        };
                    }

                    if (product.Country != null)
                    {
                        product.CategoryID = product.Country.CountryID;
                    }
                    else
                    {
                        product.Country = new CountryViewModel()
                        {
                            CountryID = (byte)product.CountryID,
                            CountryNameShort = entities.Countries.Where(s => s.CountryID == product.CategoryID).Select(s => s.CountryNameShort).First(),
                            CountryNameLong = entities.Countries.Where(s => s.CountryID == product.CategoryID).Select(s => s.CountryNameLong).First()
                        };
                    }

                    target.CategoryID = product.CategoryID;
                    target.Category = product.Category;
                }
            }
            else
            {
                var entity = new DetailProduct();

                entity.ProductID = product.ProductID;
                entity.ProductName = product.ProductName;
                entity.UnitPrice = product.UnitPrice;
                entity.UnitsInStock = (short)product.UnitsInStock;
                entity.Discontinued = product.Discontinued;
                entity.CategoryID = product.CategoryID;
                entity.CustomerRating = product.CustomerRating;
                entity.TargetSales = product.TargetSales;

                if (product.Category != null)
                {
                    entity.CategoryID = product.Category.CategoryID;
                }

                if (product.Country != null)
                {
                    entity.CountryID = product.Country.CountryID;
                }

                entities.DetailProducts.Attach(entity);
                entities.Entry(entity).State = EntityState.Modified;
                entities.SaveChanges();
            }
        }

        public void Destroy(DetailProductViewModel product)
        {
            if (!UpdateDatabase)
            {
                var target = GetDetailProducts().FirstOrDefault(p => p.ProductID == product.ProductID);
                if (target != null)
                {
                    GetDetailProducts().Remove(target);
                }
            }
            else
            {
                var entity = new DetailProduct();

                entity.ProductID = product.ProductID;

                entities.DetailProducts.Attach(entity);

                entities.DetailProducts.Remove(entity);

                var orderDetails = entities.OrderDetails.Where(pd => pd.ProductID == entity.ProductID);

                foreach (var orderDetail in orderDetails)
                {
                    entities.OrderDetails.Remove(orderDetail);
                }

                entities.SaveChanges();
            }
        }

        public DetailProductViewModel One(Func<DetailProductViewModel, bool> predicate)
        {
            return GetDetailProducts().FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}