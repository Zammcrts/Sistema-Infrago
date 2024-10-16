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
            // parte dos
            await CheckMaintenancesAsync();
            await CheckMaintenanceDetailsAsync();
            await CheckMachineriesAsync();
            await CheckMachineryAssignmentsAsync();
            await CheckToolsAsync();
            await CheckToolAssignmentsAsync();
            await CheckServicesAsync();
            await CheckProjectDetailsAsync();

        }

        private async Task CheckProjectDetailsAsync()
        {
            if (!dataContext.ProjectDetails.Any())
            {
                var project1 = dataContext.Projects.FirstOrDefault(x => x.Client == "Hospital Manuel Cervantes");
                var project2 = dataContext.Projects.FirstOrDefault(x => x.Client == "Escuela Primaria La Reforma");
                var service1 = dataContext.Services.FirstOrDefault(x => x.ServiceName == "Instalación de Electricidad");
                var service2 = dataContext.Services.FirstOrDefault(x => x.ServiceName == "Reparación de Plomería");

                if (project1 != null && service1 != null)
                {
                    dataContext.ProjectDetails.Add(new ProjectDetails
                    {
                        DetailDescription = "Instalación completa de sistemas eléctricos",
                        ServiceType = "Instalación",
                        Cost = 5000.75f,
                        Project = project1,
                        Service = service1
                    });
                }

                if (project2 != null && service2 != null)
                {
                    dataContext.ProjectDetails.Add(new ProjectDetails
                    {
                        DetailDescription = "Reemplazo de tuberías en todo el edificio",
                        ServiceType = "Reparación",
                        Cost = 1200.50f,
                        Project = project2,
                        Service = service2
                    });
                }

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckServicesAsync()
        {
            if (!dataContext.Services.Any())
            {
                dataContext.Services.Add(new Service
                {
                    ServiceName = "Instalación de Electricidad",
                    Cost = 1500.50f
                });
                dataContext.Services.Add(new Service
                {
                    ServiceName = "Reparación de Plomería",
                    Cost = 800.00f
                });
                dataContext.Services.Add(new Service
                {
                    ServiceName = "Mantenimiento de Clima",
                    Cost = 1200.75f
                });
                dataContext.Services.Add(new Service
                {
                    ServiceName = "Servicios de Pintura",
                    Cost = 950.30f
                });

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckToolAssignmentsAsync()
        {
            if (!dataContext.ToolAssignments.Any())
            {
                var tool1 = dataContext.Tools.FirstOrDefault(x => x.ToolName == "Taladro Eléctrico");
                var tool2 = dataContext.Tools.FirstOrDefault(x => x.ToolName == "Sierra Circular");
                var tool3 = dataContext.Tools.FirstOrDefault(x => x.ToolName == "Martillo");

                var project1 = dataContext.Projects.FirstOrDefault(x => x.Client == "Hospital Manuel Cervantes");
                var project2 = dataContext.Projects.FirstOrDefault(x => x.Client == "Escuela Primaria La Reforma");
                var project3 = dataContext.Projects.FirstOrDefault(x => x.Client == "Conjunto Habitacional Las Palmas");

                if (tool1 != null && project1 != null)
                {
                    dataContext.ToolAssignments.Add(new ToolAssignment { ToolAssignmentID = 1, AssignmentDate = 20231010, Tool = tool1, Project = project1 });
                }

                if (tool2 != null && project2 != null)
                {
                    dataContext.ToolAssignments.Add(new ToolAssignment { ToolAssignmentID = 2, AssignmentDate = 20231011, Tool = tool2, Project = project2 });
                }

                if (tool3 != null && project3 != null)
                {
                    dataContext.ToolAssignments.Add(new ToolAssignment { ToolAssignmentID = 3, AssignmentDate = 20231012, Tool = tool3, Project = project3 });
                }

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckToolsAsync()
        {
            if (!dataContext.Tools.Any())
            {
                var tool1 = dataContext.Tools.FirstOrDefault(x => x.ToolName == "Taladro Eléctrico");
                var tool2 = dataContext.Tools.FirstOrDefault(x => x.ToolName == "Sierra Circular");
                var tool3 = dataContext.Tools.FirstOrDefault(x => x.ToolName == "Martillo");
                var tool4 = dataContext.Tools.FirstOrDefault(x => x.ToolName == "Destornillador");
                var tool5 = dataContext.Tools.FirstOrDefault(x => x.ToolName == "Llave Inglesa");
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckMachineryAssignmentsAsync()
        {
            if (!dataContext.MachineryAssignments.Any())
            {
                var machinery1 = dataContext.Machineries.FirstOrDefault(x => x.Machine == "Torno Mecánico");
                var machinery2 = dataContext.Machineries.FirstOrDefault(x => x.Machine == "Fresadora CNC");
                var machinery3 = dataContext.Machineries.FirstOrDefault(x => x.Machine == "Prensa Hidráulica");

                if (machinery1 != null)
                {
                    dataContext.MachineryAssignments.Add(new MachineryAssignment
                    {
                        MachineProject = "Hospital Manuel Cervantes",
                        AssignationDate = "15/01/2024",
                        Machinery = machinery1
                    });
                }

                if (machinery2 != null)
                {
                    dataContext.MachineryAssignments.Add(new MachineryAssignment
                    {
                        MachineProject = "Escuela Primaria La Reforma",
                        AssignationDate = "20/01/2024",
                        Machinery = machinery2
                    });
                }

                if (machinery3 != null)
                {
                    dataContext.MachineryAssignments.Add(new MachineryAssignment
                    {
                        MachineProject = "Conjunto Habitacional Las Palmas",
                        AssignationDate = "25/01/2024",
                        Machinery = machinery3
                    });
                }

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckMachineriesAsync()
        {
            if (!dataContext.Machineries.Any())
            {
                dataContext.Machineries.Add(new Machinery
                {
                    Code = "TM001",
                    Machine_Model = "Torno Mecánico TMX-120",
                    Machine = "Torno Mecánico",
                    Capacity = "1500 RPM"
                });
                dataContext.Machineries.Add(new Machinery
                {
                    Code = "FC002",
                    Machine_Model = "Fresadora CNC FCN-200",
                    Machine = "Fresadora CNC",
                    Capacity = "5000 RPM"
                });
                dataContext.Machineries.Add(new Machinery
                {
                    Code = "PH003",
                    Machine_Model = "Prensa Hidráulica PH-550",
                    Machine = "Prensa Hidráulica",
                    Capacity = "550 Toneladas"
                });

                await dataContext.SaveChangesAsync();
            }
        }

        // revisar pq aurelio se confundio
        private async Task CheckMaintenanceDetailsAsync()
        {
            if (!dataContext.MaintenanceDetails.Any())
            {
                var maintenance1 = dataContext.Maintenances.FirstOrDefault(x => x.MaintenanceType == "Preventivo");
                var maintenance2 = dataContext.Maintenances.FirstOrDefault(x => x.MaintenanceType == "Correctivo");
                var maintenance3 = dataContext.Maintenances.FirstOrDefault(x => x.MaintenanceType == "Predictivo");

                var machinery1 = dataContext.Machineries.FirstOrDefault(x => x.Machine == "Torno Mecánico");
                var machinery2 = dataContext.Machineries.FirstOrDefault(x => x.Machine == "Fresadora CNC");
                var machinery3 = dataContext.Machineries.FirstOrDefault(x => x.Machine == "Prensa Hidráulica");

                if (maintenance1 != null && machinery1 != null)
                {
                    dataContext.MaintenanceDetails.Add(new MaintenanceDetails { Machine = "Torno Mecánico", MaintenanceDate = "01/03/2024", MaintenanceType = "Preventivo", Description = "Cambio de aceite y limpieza general", Cost = 2500, Maintenance = maintenance1, Machinery = machinery1 });
                }

                if (maintenance2 != null && machinery2 != null)
                {
                    dataContext.MaintenanceDetails.Add(new MaintenanceDetails { Machine = "Fresadora CNC", MaintenanceDate = "15/04/2024", MaintenanceType = "Correctivo", Description = "Reparación de sistema hidráulico", Cost = 4500, Maintenance = maintenance2, Machinery = machinery2 });
                }

                if (maintenance3 != null && machinery3 != null)
                {
                    dataContext.MaintenanceDetails.Add(new MaintenanceDetails { Machine = "Prensa Hidráulica", MaintenanceDate = "10/05/2024", MaintenanceType = "Predictivo", Description = "Revisión de componentes críticos", Cost = 3500, Maintenance = maintenance3, Machinery = machinery3 });
                }

                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckMaintenancesAsync()
        {
            if (!dataContext.Maintenances.Any())
            {
                dataContext.Maintenances.Add(new Maintenance { MaintenanceID = 1001, EquipmentID = 1, MaintenanceDate = 20231010, MaintenanceType = "Preventivo", Description = "Revisión general y limpieza del motor", Cost = 1200.50f });
                dataContext.Maintenances.Add(new Maintenance { MaintenanceID = 1002, EquipmentID = 2, MaintenanceDate = 20231011, MaintenanceType = "Correctivo", Description = "Reemplazo de piezas desgastadas", Cost = 850.75f });
                dataContext.Maintenances.Add(new Maintenance { MaintenanceID = 1003, EquipmentID = 3, MaintenanceDate = 20231012, MaintenanceType = "Predictivo", Description = "Inspección con herramientas de diagnóstico", Cost = 650.00f });
                dataContext.Maintenances.Add(new Maintenance { MaintenanceID = 1004, EquipmentID = 4, MaintenanceDate = 20231013, MaintenanceType = "Correctivo", Description = "Ajuste de piezas móviles y lubricación", Cost = 900.00f });

                await dataContext.SaveChangesAsync();
            }
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
                    dataContext.Assignments.Add(new Assignment { ProjectName = "Hospital Manuel Cervantes", Quantity = 30, Project = project1, Material = material1 });
                }

                if (project2 != null && material2 != null)
                {
                    dataContext.Assignments.Add(new Assignment { ProjectName = "Escuela Primaria La Reforma", Quantity = 50, Project = project2, Material = material2 });
                }

                if (project3 != null && material3 != null)
                {
                    dataContext.Assignments.Add(new Assignment { ProjectName = "Conjunto Habitacional Las Palmas", Quantity = 100, Project = project3, Material = material3 });
                }

                if (project4 != null && material4 != null)
                {
                    dataContext.Assignments.Add(new Assignment { ProjectName = "Casa Residencial Monterreal", Quantity = 75, Project = project4, Material = material4 });
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
