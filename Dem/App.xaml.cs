using Dem.Services.Stores;
using Dem.Primitives;
using Dem.Services;
using Dem.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services.DbServices;
using System.Reflection.Metadata;
using System.Data.Common;
using System.Windows.Navigation;
using Dem.Commands;
using static System.Formats.Asn1.AsnWriter;

namespace Dem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationDbContext>();                

                services.AddSingleton<NavigationStore>();
                services.AddTransient<NavigateCommand<RequestListViewModel>>(s =>
                {
                    var navigationService = s.GetRequiredService<NavigationService<RequestListViewModel>>();
                    return new NavigateCommand<RequestListViewModel>(navigationService);
                });

                services.AddSingleton<MainViewModel>();

                services.AddTransient<CloseRequestCommand>();

                services.AddTransient<IEmployeeService, EmployeeService>();
                services.AddTransient<IMaterialService, MaterialService>();
                services.AddTransient<IProductService, ProductService>();
                services.AddTransient<IRequestService, RequestService>();
                services.AddTransient<IPartnerService, PartnerService>();
                services.AddTransient<ISupplierService, SupplierService>();



                services.AddTransient<ProductListViewModel>(s =>
                {
                    var navBar = s.GetRequiredService<NavigationBarViewModel>();
                    var productService = s.GetRequiredService<IProductService>();
                    var materialService = s.GetRequiredService<IMaterialService>();

                    var addProductNavigationService = s.GetRequiredService<NavigationService<AddProductViewModel>>();
                    var productEditNavigationService = s.GetRequiredService<NavigationService<ProductEditViewModel>>();
                    var editMaterialNavigationService = s.GetRequiredService<NavigationService<EditMaterialViewModel>>();

                    return ProductListViewModel.Create(navBar, productService, materialService, addProductNavigationService, productEditNavigationService, editMaterialNavigationService);
                });
                services.AddSingleton<NavigationService<ProductListViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, ProductListViewModel> viewModelFactory = parameter =>
                    {
                        var navBar = s.GetRequiredService<NavigationBarViewModel>();
                        var productService = s.GetRequiredService<IProductService>();
                        var materialService = s.GetRequiredService<IMaterialService>();

                        var addProductNavigationService = s.GetRequiredService<NavigationService<AddProductViewModel>>();
                        var productEditNavigationService = s.GetRequiredService<NavigationService<ProductEditViewModel>>();
                        var editMaterialNavigationService = s.GetRequiredService<NavigationService<EditMaterialViewModel>>();

                        return ProductListViewModel.Create(navBar, productService, materialService, addProductNavigationService, productEditNavigationService, editMaterialNavigationService);
                    };

                    return new NavigationService<ProductListViewModel>(navigationStore, viewModelFactory);
                });


                services.AddTransient<MaterialListViewModel>(s =>
                {
                    var navBar = s.GetRequiredService<NavigationBarViewModel>();
                    var materialService = s.GetRequiredService<IMaterialService>();
                    var addMaterialNavigationService = s.GetRequiredService<NavigationService<AddMaterialViewModel>>();
                    var editMaterialNavigationService = s.GetRequiredService<NavigationService<EditMaterialViewModel>>();

                    return MaterialListViewModel.Create(navBar, materialService, addMaterialNavigationService, editMaterialNavigationService);
                });
                services.AddSingleton<NavigationService<MaterialListViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, MaterialListViewModel> viewModelFactory = parameter =>
                    {
                        var navBar = s.GetRequiredService<NavigationBarViewModel>();
                        var materialService = s.GetRequiredService<IMaterialService>();
                        var addMaterialNavigationService = s.GetRequiredService<NavigationService<AddMaterialViewModel>>();
                        var editMaterialNavigationService = s.GetRequiredService<NavigationService<EditMaterialViewModel>>();


                        return MaterialListViewModel.Create(navBar, materialService, addMaterialNavigationService, editMaterialNavigationService);
                    };

                    return new NavigationService<MaterialListViewModel>(navigationStore, viewModelFactory);
                });

                services.AddTransient<LoginViewModel>(s =>
                {
                    var employeeService = s.GetRequiredService<IEmployeeService>();
                    var productListNavigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();

                    return LoginViewModel.Create(employeeService, productListNavigationService);
                });
                services.AddSingleton<NavigationService<LoginViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, LoginViewModel> viewModelFactory = parameter =>
                    {
                        var employeeService = s.GetRequiredService<IEmployeeService>();
                        var productListNavigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();

                        return LoginViewModel.Create(employeeService, productListNavigationService);
                    };

                    return new NavigationService<LoginViewModel>(navigationStore, viewModelFactory);
                });


                // посмотри связь ProductList and ProductEdit видимо надо убрать доп nav service



                services.AddTransient<PartnerListViewModel>(s =>
                {
                    var navBar = s.GetRequiredService<NavigationBarViewModel>();
                    var partnerService = s.GetRequiredService<IPartnerService>();
                    var addPartnerNavigationService = s.GetRequiredService<NavigationService<AddPartnerViewModel>>();
                    var editPartnerNavigationService = s.GetRequiredService<NavigationService<EditPartnerViewModel>>();

                    return PartnerListViewModel.CreateAsync(navBar, partnerService, addPartnerNavigationService, editPartnerNavigationService);
                });
                services.AddSingleton<NavigationService<PartnerListViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, PartnerListViewModel> viewModelFactory = parameter =>
                    {
                        var navBar = s.GetRequiredService<NavigationBarViewModel>();
                        var partnerService = s.GetRequiredService<IPartnerService>();
                        var addPartnerNavigationService = s.GetRequiredService<NavigationService<AddPartnerViewModel>>();
                        var editPartnerNavigationService = s.GetRequiredService<NavigationService<EditPartnerViewModel>>();

                        return PartnerListViewModel.CreateAsync(navBar, partnerService, addPartnerNavigationService, editPartnerNavigationService);
                    };

                    return new NavigationService<PartnerListViewModel>(navigationStore, viewModelFactory);
                });



                services.AddTransient<AddProductViewModel>(s =>
                {
                    var productService = s.GetRequiredService<IProductService>();
                    var materialService = s.GetRequiredService<IMaterialService>();
                    var productListNavigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();
                    var editMaterialNavigationService = s.GetRequiredService<NavigationService<EditMaterialViewModel>>();


                    return AddProductViewModel.CreateAsync(productService, materialService, productListNavigationService, editMaterialNavigationService);
                });
                services.AddSingleton<NavigationService<AddProductViewModel>>( s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, AddProductViewModel> viewModelFactory = parameter =>
                    {
                        var productService = s.GetRequiredService<IProductService>();
                        var materialService = s.GetRequiredService<IMaterialService>();
                        var productListNavigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();
                        var editMaterialNavigationService = s.GetRequiredService<NavigationService<EditMaterialViewModel>>();

                        return AddProductViewModel.CreateAsync(productService, materialService, productListNavigationService, editMaterialNavigationService);
                    };

                    var productService = s.GetRequiredService<IProductService>();
                    var materialService = s.GetRequiredService<IMaterialService>();
                    var navigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();

                    return new NavigationService<AddProductViewModel>(navigationStore, viewModelFactory);
                });




                services.AddTransient<AddPartnerViewModel>(s =>
                {
                    var partnerService = s.GetRequiredService<IPartnerService>();
                    var navigationService = s.GetRequiredService<NavigationService<PartnerListViewModel>>();

                    return new AddPartnerViewModel(partnerService, navigationService);
                });
                services.AddSingleton<NavigationService<AddPartnerViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, AddPartnerViewModel> viewModelFactory = parameter =>
                    {
                        var partnerService = s.GetRequiredService<IPartnerService>();
                        var navigationService = s.GetRequiredService<NavigationService<PartnerListViewModel>>();

                        return new AddPartnerViewModel(partnerService, navigationService);
                    };

                    return new NavigationService<AddPartnerViewModel>(navigationStore, viewModelFactory);
                });




                services.AddTransient<MakeRequestViewModel>(s =>
                {
                    var requestService = s.GetRequiredService<IRequestService>();
                    var productService = s.GetRequiredService<IProductService>();
                    var partnerService = s.GetRequiredService<IPartnerService>();

                    var navigationService = s.GetRequiredService<NavigationService<RequestListViewModel>>();

                    return MakeRequestViewModel.CreateAsync(requestService, productService, partnerService, navigationService);
                });
                services.AddSingleton<NavigationService<MakeRequestViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, MakeRequestViewModel> viewModelFactory = parameter =>
                    {
                        var productService = s.GetRequiredService<IProductService>();
                        var partnerService = s.GetRequiredService<IPartnerService>();
                        var requestService = s.GetRequiredService<IRequestService>();
                        var navigationRequestListService = s.GetRequiredService<NavigationService<RequestListViewModel>>();

                        return MakeRequestViewModel.CreateAsync(requestService, productService, partnerService, navigationRequestListService);
                    };

                    return new NavigationService<MakeRequestViewModel>(navigationStore, viewModelFactory);
                });




                services.AddTransient<RequestListViewModel>(s =>
                {
                    var navigationBarViewModel = s.GetRequiredService<NavigationBarViewModel>();
                    var requestService = s.GetRequiredService<IRequestService>();
                    var makeRequestNavigationService = s.GetRequiredService<NavigationService<MakeRequestViewModel>>();
                    var closeRequestCommand = s.GetRequiredService<NavigationService<RequestListViewModel>>();

                    return RequestListViewModel.CreateAsync(navigationBarViewModel, requestService, makeRequestNavigationService, closeRequestCommand);
                });
                services.AddSingleton<NavigationService<RequestListViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();
                    return new NavigationService<RequestListViewModel>(navigationStore, parameter =>
                    {
                        var navigationBar = s.GetRequiredService<NavigationBarViewModel>();
                        var requestService = s.GetRequiredService<IRequestService>();
                        var makeRequestNavigationService = s.GetRequiredService<NavigationService<MakeRequestViewModel>>();
                        return RequestListViewModel.CreateAsync(navigationBar, requestService, makeRequestNavigationService, s.GetRequiredService<NavigationService<RequestListViewModel>>());
                    });
                });


                services.AddTransient<EmploeeListViewModel>(s =>
                {
                    var navigationBarViewModel = s.GetRequiredService<NavigationBarViewModel>();
                    var employeeService = s.GetRequiredService<IEmployeeService>();
                    var addEmployeeNavigationService = s.GetRequiredService<NavigationService<AddEmployeeViewModel>>();
                    var editEmployeeNavigationService = s.GetRequiredService<NavigationService<EditEmployeeViewModel>>();

                    return EmploeeListViewModel.CreateAsync(navigationBarViewModel, employeeService, addEmployeeNavigationService, editEmployeeNavigationService);
                });
                services.AddSingleton<NavigationService<EmploeeListViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();
                    return new NavigationService<EmploeeListViewModel>(navigationStore, parameter =>
                    {
                        var navigationBarViewModel = s.GetRequiredService<NavigationBarViewModel>();
                        var employeeService = s.GetRequiredService<IEmployeeService>();
                        var addEmployeeNavigationService = s.GetRequiredService<NavigationService<AddEmployeeViewModel>>();
                        var editEmployeeNavigationService = s.GetRequiredService<NavigationService<EditEmployeeViewModel>>();

                        return EmploeeListViewModel.CreateAsync(navigationBarViewModel, employeeService, addEmployeeNavigationService, editEmployeeNavigationService);
                    });
                });




                services.AddTransient<AddEmployeeViewModel>(s =>
                {
                    var employeeService = s.GetRequiredService<IEmployeeService>();
                    var navigationService = s.GetRequiredService<NavigationService<EmploeeListViewModel>>();

                    return AddEmployeeViewModel.CreateAsync(employeeService, navigationService);
                });
                services.AddSingleton<NavigationService<AddEmployeeViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, AddEmployeeViewModel> viewModelFactory = parameter =>
                    {
                        var employeeService = s.GetRequiredService<IEmployeeService>();
                        var navigationService = s.GetRequiredService<NavigationService<EmploeeListViewModel>>();

                        return AddEmployeeViewModel.CreateAsync(employeeService, navigationService);
                    };

                    return new NavigationService<AddEmployeeViewModel>(navigationStore, viewModelFactory);
                });



                services.AddTransient<AddMaterialViewModel>(s =>
                {
                    var materialService = s.GetRequiredService<IMaterialService>();
                    var supplierService = s.GetRequiredService<ISupplierService>();
                    var navigationService = s.GetRequiredService<NavigationService<MaterialListViewModel>>();

                    return AddMaterialViewModel.Create(materialService, navigationService, supplierService);
                });
                services.AddSingleton<NavigationService<AddMaterialViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, AddMaterialViewModel> viewModelFactory = parameter =>
                    {
                        var materialService = s.GetRequiredService<IMaterialService>();
                        var supplierService = s.GetRequiredService<ISupplierService>();
                        var navigationService = s.GetRequiredService<NavigationService<MaterialListViewModel>>();

                        return AddMaterialViewModel.Create(materialService, navigationService, supplierService);

                    };

                    return new NavigationService<AddMaterialViewModel>(navigationStore, viewModelFactory);
                });




                services.AddSingleton<NavigationService<ProductEditViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    return new NavigationService<ProductEditViewModel>(navigationStore, parameter =>
                    {
                        var id = parameter as Guid?;
                        if (id == null)
                        {
                            throw new ArgumentException("Отсутствует Id продукта");
                        }

                        var productService = s.GetRequiredService<IProductService>();
                        var materialService = s.GetRequiredService<IMaterialService>();
                        var productListNavigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();
                        var editMaterialNavigationService = s.GetRequiredService<NavigationService<EditMaterialViewModel>>();


                        return ProductEditViewModel.CreateAsync(id, productService, materialService, productListNavigationService, editMaterialNavigationService);
                    });
                });

                services.AddSingleton<NavigationService<EditMaterialViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    return new NavigationService<EditMaterialViewModel>(navigationStore, parameter =>
                    {
                        var id = parameter as Guid?;
                        if (id == null)
                        {
                            throw new ArgumentException("Отсутствует Id материала");
                        }

                        var materialService = s.GetRequiredService<IMaterialService>();
                        var supplierService = s.GetRequiredService<ISupplierService>();
                        var navigationService = s.GetRequiredService<NavigationService<MaterialListViewModel>>();

                        return EditMaterialViewModel.CreateAsync((Guid)id, materialService, supplierService, navigationService);
                    });
                });

                services.AddSingleton<NavigationService<EditPartnerViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    return new NavigationService<EditPartnerViewModel>(navigationStore, parameter =>
                    {
                        var id = parameter as Guid?;
                        if (id == null)
                        {
                            throw new ArgumentException("Отсутствует Id партнера");
                        }

                        var partnerService = s.GetRequiredService<IPartnerService>();
                        var navigationService = s.GetRequiredService<NavigationService<PartnerListViewModel>>();

                        return EditPartnerViewModel.CreateAsync((Guid)id, partnerService, navigationService);
                    });
                });

                services.AddSingleton<NavigationService<EditEmployeeViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    return new NavigationService<EditEmployeeViewModel>(navigationStore, parameter =>
                    {
                        var id = parameter as Guid?;
                        if (id == null)
                        {
                            throw new ArgumentException("Отсутствует Id работника");
                        }

                        var employeeService = s.GetRequiredService<IEmployeeService>();
                        var navigationService = s.GetRequiredService<NavigationService<EmploeeListViewModel>>();

                        return EditEmployeeViewModel.CreateAsync((Guid)id, employeeService, navigationService);
                    });
                });


                services.AddTransient<NavigationBarViewModel>(s =>
                {
                    return new NavigationBarViewModel(
                        s.GetRequiredService<NavigationService<ProductListViewModel>>(),
                        s.GetRequiredService<NavigationService<RequestListViewModel>>(),
                        s.GetRequiredService<NavigationService<PartnerListViewModel>>(),
                        s.GetRequiredService<NavigationService<EmploeeListViewModel>>(),
                        s.GetRequiredService<NavigationService<MaterialListViewModel>>());
                });

                services.AddSingleton<MainWindow>();
            })
            .Build();
        }




        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                _host.StartAsync().GetAwaiter().GetResult();
                var scope = _host.Services.CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // Заполнение данными БД
                // не проверял работу (впадлу), надеюсь на лучшее
                InitService.Seed(context);

                var mainWindow = _host.Services.GetRequiredService<MainWindow>();
                var navigationStore = _host.Services.GetRequiredService<NavigationStore>();
                var initialViewModel = _host.Services.GetRequiredService<LoginViewModel>();


                navigationStore.CurrentViewModel = initialViewModel;
                mainWindow.DataContext = _host.Services.GetRequiredService<MainViewModel>();
                mainWindow.Show();

                base.OnStartup(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"fuck");
            }
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            base.OnExit(e);
        }
    }

}
