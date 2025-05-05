using Dem.Models.Entities;
using Dem.Models.Enums;
using Dem.Services.DbServices.DbServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Dem.Services
{
    class InitService
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.Migrate();

            Guid? supplier1Id = null;
            Guid? supplier2Id = null;

            Guid? material1Id = null;
            Guid? material2Id = null;

            Guid? partner1Id = null;
            Guid? partner2Id = null;
            Guid? partner3Id = null;
            Guid? partner4Id = null;
            Guid? partner5Id = null;

            if (!context.Suppliers.Any())
            {
                supplier1Id = Guid.NewGuid();
                supplier2Id = Guid.NewGuid();
                var supplier1 = new Supplier((Guid)supplier1Id, "Поставщик 4", "ООО", "1234567890");
                var supplier2 = new Supplier((Guid)supplier2Id, "Базовый поставщик", "ООО", "9876543210");

                context.Suppliers.AddRange(supplier1, supplier2);
            }
            if (!context.Materials.Any())
            {
                material1Id = Guid.NewGuid();
                material2Id = Guid.NewGuid();

                var material1 = new Material((Guid)material1Id, "Материал 1", "тип 1", 5, "шт.", null, 1200m, supplier1Id);

                var material2 = new Material((Guid)material2Id, "Материал 2", "тип 2", 100, "шт.", null, 350m, supplier2Id);

                context.Materials.AddRange(material1, material2);

                Guid product1Id = Guid.NewGuid();
                Guid product2Id = Guid.NewGuid();
                Guid product3Id = Guid.NewGuid();
                Guid product4Id = Guid.NewGuid();
                Guid product5Id = Guid.NewGuid();

                var product1 = new Product(product1Id, "Паркетная доска", "Паркетная доска Ясень темный однополосная 14 мм", "8758385",
                    null, 21, 4456.90m, new List<Material>() { material1 });
                var product2 = new Product(product2Id, "Паркетная доска", "Инженерная доска Дуб Французская елка однополосная 12 мм", "8858958",
                    null, 22, 7330.99m, new List<Material>() { material2 });
                var product3 = new Product(product3Id, "Ламинат", "Ламинат Дуб дымчато-белый 33 класс 12 мм", "7750282",
                    null, 23, 1799.33m, new List<Material>() {material1, material2 });
                var product4 = new Product(product4Id, "Ламинат", "Ламинат Дуб серый 32 класс 8 мм с фаской", "7028748",
                    null, 24, 3890.41m, new List<Material>() { material1 });
                var product5 = new Product(product5Id, "Пробковое покрытие", "Пробковое напольное клеевое покрытие 32 класс 4 мм", "5012543",
                    null, 25, 5450.59m, new List<Material>() { material1, material2 });

            }

            if (!context.Partners.Any())
            {
                partner1Id = Guid.NewGuid();
                partner2Id = Guid.NewGuid();
                partner3Id = Guid.NewGuid();
                partner4Id = Guid.NewGuid();
                partner5Id = Guid.NewGuid();


                var partner1 = new Partner((Guid)partner1Id, "ЗАО", "База Строитель", "Иванова Александра Ивановна", "aleksandraivanova@ml.ru", "4931234567",
                    "652050, Кемеровская область, город Юрга, ул. Лесная, 15", "2222455179", 7, null);

                var partner2 = new Partner((Guid)partner2Id, "ООО", "Паркет 29", "Петров Василий Петрович", "vppetrov@vl.ru", "9871235678",
                    "164500, Архангельская область, город Северодвинск, ул. Строителей, 18", "3333888520", 7, null);

                var partner3 = new Partner((Guid)partner3Id, "ПАО", "Стройсервис", "Соловьев Андрей Николаевич", "ansolovev@st.ru", "8122233200",
                    "188910, Ленинградская область, город Приморск, ул. Парковая, 21", "4440391035", 7, null);

                var partner4 = new Partner((Guid)partner4Id, "ОАО", "Ремонт и отделка", "Воробьева Екатерина Валерьевна", "ekaterina.vorobeva@ml.ru", "4442223311",
                    "143960, Московская область, город Реутов, ул. Свободы, 51", "1111520857", 5, null);

                var partner5 = new Partner((Guid)partner5Id, "ЗАО", "МонтажПро", "Степанов Степан Сергеевич", "stepanov@stepan.ru", "9128883333",
                    "309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122", "5552431140", 10, null);

                context.Partners.AddRange(partner1, partner2, partner3, partner4, partner5);
            }

            if (!context.Employees.Any())
            {
                var employee = new Employee(Guid.NewGuid(), "Иванов Иван Иванович", DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), true, HealhStatus.good, 
                    "Инженер", "admin@example.com", "admin123", EmployeeStatus.manager);

                context.Employees.Add(employee);
            }

            context.SaveChanges();
        }


    }
}
