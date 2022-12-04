using CarOnlineShop.Data.Repositories;
using CarOnlineShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.Data.Models
{
    public class DbInitializer
    {
        public static void ExceedDb(IApplicationBuilder application)
        {
            CarOnlineShopContext _context = application.ApplicationServices.GetRequiredService<CarOnlineShopContext>();
            

            if(!_context.Category.Any())
            {
                _context.Category.AddRange(Categories.Select(c=>c.Value));                
            }

            if (!_context.Product.Any())
            {
                _context.AddRange(
                    new Product
                    {
                        Name = "Accent",
                        Price = 6.19M,
                        Description = "СОЗДАН ДЛЯ ВАС.ACCENT СОЧЕТАЕТ ЭКОНОМИЧНОСТЬ И УДОБСТВО ГОРОДСКОГО СЕДАНА",
                        Category = Categories["Hyundai"],
                        ImageUrl = "/images/accent.jpg",
                        IsPreferredCar = true,
                        ImageThumbnailUrl = "/images/accent.png"
                    },
                    new Product
                    {
                        Name = "Sonata",
                        Price = 11.19M,
                        Description = "В Sonata есть все необходимые удобства для Вас и Вашей семьи",
                        Category = Categories["Hyundai"],
                        ImageUrl = "/images/sonata.jpg",
                        IsPreferredCar = false,
                        ImageThumbnailUrl = "/images/sonata.png"
                    },
                    new Product
                    {
                        Name = "Creta",
                        Price = 7.39M,
                        Description = "Стремительность во всем облике, ускользающие линии, динамика в совершенном проявлении",
                        Category = Categories["Hyundai"],
                        ImageUrl = "/images/creta.jpg",
                        IsPreferredCar = false,
                        ImageThumbnailUrl = "/images/creta.png"
                    },
                    new Product
                    {
                        Name = "Tucson",
                        Price = 10.69M,
                        Description = "ХОРОШ, КАК НИ КРУТИ. ПРИ ЛЮБОМ ОСВЕЩЕНИИ, В ЛЮБОМ РАКУРСЕ",
                        Category = Categories["Hyundai"],
                        ImageUrl = "/images/tucson.jpg",
                        IsPreferredCar = true,
                        ImageThumbnailUrl = "/images/tucson.png"
                    },
                    new Product
                    {
                        Name = "Santa-Fe",
                        Price = 15.89M,
                        Description = "ВСЕДОРОЖНИК, ОСНАЩЕНИЕ КОТОРОГО ПРЕВОСХОДИТ САМЫЕ СМЕЛЫЕ ОЖИДАНИЯ",
                        Category = Categories["Hyundai"],
                        ImageUrl = "/images/SantaFe.jpg",
                        IsPreferredCar = false,
                        ImageThumbnailUrl = "/images/hyundai_santaFe.png"
                    },
                    new Product
                    {
                        Name = "Corolla",
                        Price = 7.73M,
                        Description = "Стильная, эффективная и удобная новая Corolla принесет удовольствие от вождения любому независимо от его предпочтенийАНА",
                        Category = Categories["Toyota"],
                        ImageUrl = "/images/corolla.jpg",
                        IsPreferredCar = true,
                        ImageThumbnailUrl = "/images/toyota_corolla.png"
                    },                     
                    new Product
                    {
                        Name = "Camry",
                        Price = 9.96M,
                        Description = "Облик автомобиля заставляет замереть от сочетания утонченного и чувственного атлетизма и дерзкого стиля, которые источает автомобиль, будто приглашая в головокружительное турне",
                        Category = Categories["Toyota"],
                        ImageUrl = "/images/camry.jpg",
                        IsPreferredCar = false,
                        ImageThumbnailUrl = "/images/toyota_camry.png"
                    },
                    new Product
                    {
                        Name = "C-HR",
                        Price = 11.63M,
                        Description = "Абсолютно новый дерзкий рельефный дизайн, компактная форма — все в этом автомобиле бросает вызов городскому трафику, привычным стереотипам и размеренному ритму жизни!",
                        Category = Categories["Toyota"],
                        ImageUrl = "/images/creta.jpg",
                        IsPreferredCar = false,
                        ImageThumbnailUrl = "/images/toyota_c-hr.png"
                    },
                    new Product
                    {
                        Name = "Highlander",
                        Price = 19.42M,
                        Description = "Highlander олицетворяет абсолютную уверенность, сочетая в себе манёвренность и атлетичность",
                        Category = Categories["Toyota"],
                        ImageUrl = "/images/highlander.jpg",
                        IsPreferredCar = true,
                        ImageThumbnailUrl = "/images/toyota_highlander.png"
                    },
                    new Product
                    {
                        Name = "Prado",
                        Price = 15.70M,
                        Description = "Каждая деталь настоящего рамного внедорожника выражает решительность и готовность преодолевать любые преграды",
                        Category = Categories["Toyota"],
                        ImageUrl = "/images/prado.jpg",
                        IsPreferredCar = true,
                        ImageThumbnailUrl = "/images/toyota_prado.png"
                    },
                    new Product
                    {
                        Name = "Subaru XV",
                        Price = 11.09M,
                        Description = "Мощь, приносящая удовольствие Редкий автомобиль может сравниться с Subaru XV в том, что касается постоянной готовности к взрыву эмоций и непосредственности характера",
                        Category = Categories["Subaru"],
                        ImageUrl = "/images/subaru.jpg",
                        IsPreferredCar = true,
                        ImageThumbnailUrl = "/images/subaru_xv.jpg"
                    },
                    new Product
                    {
                        Name = "Forester",
                        Price = 11.69M,
                        Description = "Обзорность нового Forester уже получила самые высокие оценки экспертов",
                        Category = Categories["Subaru"],
                        ImageUrl = "/images/forester.jpg",
                        IsPreferredCar = false,
                        ImageThumbnailUrl = "/images/subaru_forester.jpg"
                    },
                    new Product
                    {
                        Name = "Legacy",
                        Price = 13.49M,
                        Description = "Двигатель третьего поколения демонстрирует уникальный опыт Subaru в разработке двигателей",
                        Category = Categories["Subaru"],
                        ImageUrl = "/images/creta.jpg",
                        IsPreferredCar = false,
                        ImageThumbnailUrl = "/images/subaru_legacy.png"
                    }                   
                );
            }
            _context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var categoryList = new Category[]
                    {
                        new Category {CategoryName = "Hyundai"},
                        new Category {CategoryName = "Toyota"},
                        new Category {CategoryName = "Subaru"}
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category category in categoryList)
                    {
                        categories.Add(category.CategoryName, category);
                    }
                }
                return categories;                
            }
        }



    }
}
