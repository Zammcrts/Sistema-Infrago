using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Data
{
    public class SeederDB
    {
        private readonly DataContext dataContext;

        public SeederDB(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckStockistsAsync();
            await CheckOrdersAsync();
            await CheckOrdersDetailsAsync();
            await CheckDepartmentsAsync();
            await CheckMaterialsAsync();
            await CheckAssignmentsAsync();
            await CheckClientsAsync();
            await CheckProjectsAsync();

        }

        private async Task CheckProjectsAsync()
        {
            if (!dataContext.Projects.Any())
            {
                dataContext.Projects.Add(new Project { Client = "Hospital Manuel Cervantes", StartDate = "01/01/2024", EndDate = "30/06/2024", AssignationDate = "15/12/2023", Budget = 500000, Status = "En progreso" });
                dataContext.Projects.Add(new Project { Client = "Escuela Primaria La Reforma", StartDate = "10/02/2024", EndDate = "30/09/2024", AssignationDate = "15/01/2024", Budget = 800000, Status = "Pendiente" });
                dataContext.Projects.Add(new Project { Client = "Conjunto Habitacional Las Palmas", StartDate = "01/06/2024", EndDate = "01/12/2024", AssignationDate = "01/05/2024", Budget = 1200000, Status = "En progreso" });
                dataContext.Projects.Add(new Project { Client = "Casa Residencial Monterreal", StartDate = "15/03/2024", EndDate = "15/09/2024", AssignationDate = "01/02/2024", Budget = 600000, Status = "En progreso" });

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckClientsAsync()
        {
            if(!dataContext.Clients.Any())
            {
                dataContext.Clients.Add(new Client { Name = "Hospital Manuel Cervantes", Email = "hospital.mc@gmail.com", Phone = "1478523690", State = "Michoacan", Township = "Acapozulco", Street = "Manuel Turizo", ExteriorNumber = "855", ZipCode = "789520", Project = "Módulo de vacunación" });
                dataContext.Clients.Add(new Client { Name = "Clínica San Juan", Email = "csanjuan@gmail.com", Phone = "1234567890", State = "Guerrero", Township = "Taxco", Street = "Calle Hidalgo", ExteriorNumber = "75", ZipCode = "40200", Project = "Ampliación de quirófano" });
                dataContext.Clients.Add(new Client { Name = "Laboratorio Central", Email = "labcentral@hotmail.com", Phone = "0987654321", State = "Puebla", Township = "Atlixco", Street = "Boulevard Norte", ExteriorNumber = "120", ZipCode = "74200", Project = "Renovación de equipo médico" });
                dataContext.Clients.Add(new Client { Name = "Hospital San Carlos", Email = "hscarlos@outlook.com", Phone = "5551234567", State = "Ciudad de México", Township = "Cuauhtémoc", Street = "Insurgentes Sur", ExteriorNumber = "350", ZipCode = "06600", Project = "Construcción de nueva ala pediátrica" });

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckAssignmentsAsync()
        {
            if (!dataContext.Assignments.Any())
            {
                var project1 = dataContext.Projects.FirstOrDefault(x => x.Client == "Hospital Manuel Cervantes");
                var project2 = dataContext.Projects.FirstOrDefault(x => x.Client == "Escuela Primaria La Reforma");
                var project3 = dataContext.Projects.FirstOrDefault(x => x.Client == "Conjunto Habitacional Las Palmas");
                var project4 = dataContext.Projects.FirstOrDefault(x => x.Client == "Casa Residencial Monterreal");

                var material1 = dataContext.Materials.FirstOrDefault(x => x.Name == "Cemento blanco Cruz Azul");
                var material2 = dataContext.Materials.FirstOrDefault(x => x.Name == "Varilla de acero 3/8");
                var material3 = dataContext.Materials.FirstOrDefault(x => x.Name == "Grava 3/4");
                var material4 = dataContext.Materials.FirstOrDefault(x => x.Name == "Arena fina");

                if (project1 != null && material1 != null)
                {
                    dataContext.Assignments.Add(new Assignment { Proyect = "Hospital Manuel Cervantes", Quantity = 30, Project = project1, Material = material1 });
                }

                if (project2 != null && material2 != null)
                {
                    dataContext.Assignments.Add(new Assignment { Proyect = "Escuela Primaria La Reforma", Quantity = 50, Project = project2, Material = material2 });
                }

                if (project3 != null && material3 != null)
                {
                    dataContext.Assignments.Add(new Assignment { Proyect = "Conjunto Habitacional Las Palmas", Quantity = 100, Project = project3, Material = material3 });
                }

                if (project4 != null && material4 != null)
                {
                    dataContext.Assignments.Add(new Assignment { Proyect = "Casa Residencial Monterreal", Quantity = 75, Project = project4, Material = material4 });
                }

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckMaterialsAsync()
        {
            if (!dataContext.Materials.Any())
            {
                dataContext.Materials.Add(new Material { Name ="Cemento blanco Cruz Azul", QuantityInStock = 50, PricePerUnit = 753 });
                dataContext.Materials.Add(new Material { Name = "Varilla de acero 3/8", QuantityInStock = 200, PricePerUnit = 115 });
                dataContext.Materials.Add(new Material { Name = "Grava 3/4", QuantityInStock = 100, PricePerUnit = 280 });
                dataContext.Materials.Add(new Material { Name = "Arena fina", QuantityInStock = 150, PricePerUnit = 320 });

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckDepartmentsAsync()
        {
            if (!dataContext.Departments.Any())
            {
                dataContext.Departments.Add(new Department { Name = "Departamento de Finanzas", Order = "500 bultos cemento" });
                dataContext.Departments.Add(new Department { Name = "Departamento de Finanzas", Order = "300 kilos de acero" });
                dataContext.Departments.Add(new Department { Name = "Departamento de Finanzas", Order = "200 metros cúbicos de arena" });
                dataContext.Departments.Add(new Department { Name = "Departamento de Finanzas", Order = "100 metros cúbicos de grava" });

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckOrdersDetailsAsync()
        {
            if (!dataContext.Orders.Any())
            {
                var order1 = dataContext.Orders.FirstOrDefault(x => x.Details == "30 bultos de cemento");
                var material1 = dataContext.Materials.FirstOrDefault(x => x.Name == "Cemento blanco Cruz Azul");
                if (order1 != null && material1 != null)
                {
                    dataContext.OrderDetails.Add(new OrderDetail { Order = order1, Material = material1, Quantity = 30, PricePerUnit = 753 });
                }

                var order2 = dataContext.Orders.FirstOrDefault(x => x.Details == "100 metros cúbicos de arena");
                var material2 = dataContext.Materials.FirstOrDefault(x => x.Name == "Arena fina");
                if (order2 != null && material2 != null)
                {
                    dataContext.OrderDetails.Add(new OrderDetail { Order = order2, Material = material2, Quantity = 100, PricePerUnit = 320 });
                }

                var order3 = dataContext.Orders.FirstOrDefault(x => x.Details == "150 metros cúbicos de grava");
                var material3 = dataContext.Materials.FirstOrDefault(x => x.Name == "Grava 3/4");
                if (order3 != null && material3 != null)
                {
                    dataContext.OrderDetails.Add(new OrderDetail { Order = order3, Material = material3, Quantity = 150, PricePerUnit = 280 });
                }

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckOrdersAsync()
        {
            if (!dataContext.Orders.Any())
            {
                var stockist = dataContext.Stockists.FirstOrDefault(x => x.ProviderName == "Materiales Ariza");
                var department = dataContext.Departments.FirstOrDefault(x => x.Name == "Departamento de Finanzas");
                if (stockist != null && department != null)
                {
                    dataContext.Orders.Add(new Order { Department = department, Stockists = stockist, Details = "50 bultos de mortero", OrderDate ="10/10/2024", DeliveyDate = "11/10/2024", TotalCost = 8500 });
                    dataContext.Orders.Add(new Order { Department = department, Stockists = stockist, Details = "30 bultos de cemento", OrderDate = "12/10/2024", DeliveyDate = "13/10/2024", TotalCost = 5100 });
                    dataContext.Orders.Add(new Order { Department = department, Stockists = stockist, Details = "100 metros cúbicos de arena", OrderDate = "14/10/2024", DeliveyDate = "15/10/2024", TotalCost = 12000 });
                    dataContext.Orders.Add(new Order { Department = department, Stockists = stockist, Details = "150 metros cúbicos de grava", OrderDate = "16/10/2024", DeliveyDate = "17/10/2024", TotalCost = 18000 });
                }
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckStockistsAsync()
        {
            if (!dataContext.Stockists.Any())
            {

                dataContext.Stockists.Add(new Stockist { ProviderName = "Materiales Ariza", Email = "materiales.ariza@gmail.com", Phone = "1234567890", State = "Morelos", Township = "Axochiapan", Street = "Carretera Quebrantadero", ExteriorNumber =  "85", ZipCode="62955", Material = "Cemento"});
                dataContext.Stockists.Add(new Stockist { ProviderName = "Distribuidora Sol", Email = "contacto@distribuidorasol.com", Phone = "9876543210", State = "Puebla", Township = "Atlixco", Street = "Av. Revolución", ExteriorNumber = "120", ZipCode = "74200", Material = "Grava" });

                dataContext.Stockists.Add(new Stockist { ProviderName = "Ferretería La Mano", Email = "ventas@lamanoferreteria.mx", Phone = "5551234567", State = "Ciudad de México", Township = "Coyoacán", Street = "Calzada de Tlalpan", ExteriorNumber = "450", ZipCode = "04100", Material = "Tubería" });

                dataContext.Stockists.Add(new Stockist { ProviderName = "Construcción y Materiales Ramírez", Email = "ramirez.construccion@outlook.com", Phone = "3312345678", State = "Jalisco", Township = "Guadalajara", Street = "Av. Vallarta", ExteriorNumber = "700", ZipCode = "44100", Material = "Concreto" });

                await dataContext.SaveChangesAsync();
            }
        }
    }
}
