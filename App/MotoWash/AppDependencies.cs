﻿using LightForms;
using MotoWash.Services;
using System.Threading.Tasks;

namespace MotoWash
{
    public class AppDependencies
    {
        private ICrossContainer Container { get; }

        public AppDependencies(ICrossContainer container)
        {
            Container = container;
            // Shared dependencies
            container.Register<IProgressPopup, ProgressPopup>();
            container.Register<IToastPopup, ToastPopup>();
            container.Register<IConfirmationPopup, ConfirmationPopup>();
            container.Register<INotificationHandler, NotificationHandler>();
            container.Register<IActionSheetService, ActionSheetService>();
            container.Register<IMediaService, MediaService>();
            container.Register<IStorageService<Settings>, StorageService<Settings>>();

            // Factories
            container.Register<IEnumFactory<AppMode, IBaseUrl>, EnumFactory<AppMode, IBaseUrl>>();
            container.Register<IEnumFactory<MediaSource, IStreamSource>, EnumFactory<MediaSource, IStreamSource>>();
            container.Register<IEnumFactory<NotificationAction, INotificationAction>, EnumFactory<NotificationAction, INotificationAction>>();

            var ibaseurl = container.Create<IEnumFactory<AppMode, IBaseUrl>>().Resolve(AppMode.Development);

            // API
            container.Register<IAuthenticationService>(() => new AuthenticationService(ibaseurl));
        }

        /// <summary>
        /// Ejecuta todas las dependencias que requieran await
        /// </summary>
        /// <returns></returns>
        public async Task Async()
        {
            var mode = AppMode.Development;
            await Container.Create<IStorageService<Settings>>().Set(s => s.Mode, mode);
        }
    }
}
