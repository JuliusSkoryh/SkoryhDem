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
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer("Server=DESKTOP-CQ9RL69;Database=DemSkoryh;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;"));

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

                //services.AddAsyncNavigationService<ProductListViewModel>(async (s, param) =>
                //{
                //    var navBar = s.GetRequiredService<NavigationBarViewModel>();
                //    var productService = s.GetRequiredService<IProductService>();
                //    var addProducNavigationService = s.GetRequiredService<NavigationService<AddProductViewModel>>();
                //    var productEditNavigationService = s.GetRequiredService<NavigationService<ProductEditViewModel>>();

                //    return await ProductListViewModel.CreateAsync(navBar, productService, addProducNavigationService, productEditNavigationService);
                //});




                services.AddTransient<ProductListViewModel>(s =>
                {
                    var navBar = s.GetRequiredService<NavigationBarViewModel>();
                    var productService = s.GetRequiredService<IProductService>();
                    var addProductNavigationService = s.GetRequiredService<NavigationService<AddProductViewModel>>();
                    var productEditNavigationService = s.GetRequiredService<NavigationService<ProductEditViewModel>>();

                    return ProductListViewModel.CreateAsync(navBar, productService, addProductNavigationService, productEditNavigationService);
                });
                services.AddSingleton<NavigationService<ProductListViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, ProductListViewModel> viewModelFactory = parameter =>
                    {
                        var navBar = s.GetRequiredService<NavigationBarViewModel>();
                        var productService = s.GetRequiredService<IProductService>();
                        var addProductNavigationService = s.GetRequiredService<NavigationService<AddProductViewModel>>();
                        var productEditNavigationService = s.GetRequiredService<NavigationService<ProductEditViewModel>>();

                        return ProductListViewModel.CreateAsync(navBar, productService, addProductNavigationService, productEditNavigationService);
                    };

                    return new NavigationService<ProductListViewModel>(navigationStore, viewModelFactory);
                });





                
                services.AddTransient(s =>
                {
                    var productService = s.GetRequiredService<IProductService>();
                    var materialService = s.GetRequiredService<IMaterialService>();
                    var navigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();

                    return AddProductViewModel.CreateAsync(productService, materialService, navigationService);
                });
                services.AddSingleton<NavigationService<AddProductViewModel>>( s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    Func<object?, AddProductViewModel> viewModelFactory = parameter =>
                    {
                        var productService = s.GetRequiredService<IProductService>();
                        var materialService = s.GetRequiredService<IMaterialService>();
                        var navigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();

                        return AddProductViewModel.CreateAsync(productService, materialService, navigationService);
                    };

                    var productService = s.GetRequiredService<IProductService>();
                    var materialService = s.GetRequiredService<IMaterialService>();
                    var navigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();

                    return new NavigationService<AddProductViewModel>(navigationStore, viewModelFactory);
                });


                services.AddTransient<MakeRequestViewModel>(s =>
                {
                    var requestService = s.GetRequiredService<IRequestService>();
                    var productService = s.GetRequiredService<IProductService>();
                    var partnerService = s.GetRequiredService<IPartnerService>();

                    var navigationService = s.GetRequiredService<NavigationService<RequestListViewModel>>();
                    var productNavigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();

                    return Task.Run(() => MakeRequestViewModel.CreateAsync(requestService, productService, partnerService, navigationService)).GetAwaiter().GetResult();
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
                    var closeRequestCommand = s.GetRequiredService<CloseRequestCommand>();

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
                        return RequestListViewModel.CreateAsync(navigationBar, requestService, makeRequestNavigationService, s.GetRequiredService<CloseRequestCommand>());
                    });
                });
                //services.AddSingleton<NavigationService<RequestListViewModel>>(s =>
                //{
                //    var navigationStore = s.GetRequiredService<NavigationStore>();
                //    Func<object?, RequestListViewModel> viewModelFactory = parameter => s.GetRequiredService<RequestListViewModel>();
                //    return new NavigationService<RequestListViewModel>(navigationStore, viewModelFactory);
                //});

                //services.AddNavigationService<RequestListViewModel>();
                //services.AddNavigationService<MakeRequestViewModel>();
                //services.AddTransient<ProductEditViewModel>(s =>
                //{
                //    var navBar = s.GetRequiredService<NavigationBarViewModel>();
                //    var productService = s.GetRequiredService<IProductService>();
                //    var addProductNavigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();
                //    var productEditNavigationService = s.GetRequiredService<NavigationService<ProductEditViewModel>>();

                //    return ProductEditViewModel.CreateAsync(id, productService, materialService, navigationServic).GetAwaiter().GetResult();
                //});




                //services.AddAsyncNavigationService<ProductEditViewModel>((s, param) =>
                //{
                //    var id = param as Guid?;
                //    if (id == null)
                //    {
                //        throw new ArgumentException("Product ID is required to create ProductEditViewModel");
                //    }

                //    var productService = s.GetRequiredService<IProductService>();
                //    var materialService = s.GetRequiredService<IMaterialService>();
                //    var navigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();

                //    return ProductEditViewModel.CreateAsync(id, productService, materialService, navigationService);
                //});
                services.AddSingleton<NavigationService<ProductEditViewModel>>(s =>
                {
                    var navigationStore = s.GetRequiredService<NavigationStore>();

                    return new NavigationService<ProductEditViewModel>(navigationStore, parameter =>
                    {
                        var id = parameter as Guid?;
                        if (id == null)
                        {
                            throw new ArgumentException("Product ID is required to create ProductEditViewModel");
                        }

                        var productService = s.GetRequiredService<IProductService>();
                        var materialService = s.GetRequiredService<IMaterialService>();
                        var navigationService = s.GetRequiredService<NavigationService<ProductListViewModel>>();

                        return ProductEditViewModel.CreateAsync(id, productService, materialService, navigationService);
                    });
                });



                services.AddTransient<NavigationBarViewModel>(s =>
                {
                    return new NavigationBarViewModel(
                        s.GetRequiredService<NavigationService<ProductListViewModel>>(),
                        s.GetRequiredService<NavigationService<RequestListViewModel>>());
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

                var mainWindow = _host.Services.GetRequiredService<MainWindow>();
                var navigationStore = _host.Services.GetRequiredService<NavigationStore>();
                var initialViewModel = _host.Services.GetRequiredService<ProductListViewModel>();

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
