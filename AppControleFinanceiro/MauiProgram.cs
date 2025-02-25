﻿using AppControleFinanceiro.Repositories;
using AppControleFinanceiro.Views;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace AppControleFinanceiro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterDatabaseAndRepositories()
                .RegisterViews();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterDatabaseAndRepositories(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<LiteDatabase>(
                options => {
                    return new LiteDatabase($"Filename={AppSettings.DatabaseFullPath}; Connection=Shared");
                }
                );
            Console.WriteLine(AppSettings.DatabaseFullPath);
            builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<TransactionAdd>();
            builder.Services.AddTransient<TransactionEdit>();
            builder.Services.AddTransient<TransactionList>();
            return builder;
        }
    }
}
