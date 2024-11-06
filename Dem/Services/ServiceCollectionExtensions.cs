using Dem.Services.Stores;
using Dem.Primitives;
using Microsoft.Extensions.DependencyInjection;

namespace Dem.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNavigationService<TViewModel>(this IServiceCollection services, Func<IServiceProvider, object?, TViewModel> viewModelFactory)
            where TViewModel : ViewModelBase
        {
            services.AddSingleton<NavigationService<TViewModel>>(s =>
                new NavigationService<TViewModel>(
                    s.GetRequiredService<NavigationStore>(),
                    parameter => viewModelFactory(s, parameter)));
            return services;
        }

        public static IServiceCollection AddAsyncNavigationService<TViewModel>(
        this IServiceCollection services,
        Func<IServiceProvider, object?, Task<TViewModel>> asyncFactory)
        where TViewModel : ViewModelBase
        {
            services.AddSingleton<NavigationService<TViewModel>>(s =>
            {
                var navigationStore = s.GetRequiredService<NavigationStore>();

                Func<object?, TViewModel> viewModelFactory = parameter => asyncFactory(s, parameter).GetAwaiter().GetResult();
                return new NavigationService<TViewModel>(navigationStore, viewModelFactory);
            });

            return services;
        }
    }
}
