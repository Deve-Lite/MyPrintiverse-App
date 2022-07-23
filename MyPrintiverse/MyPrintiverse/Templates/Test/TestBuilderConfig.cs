

namespace MyPrintiverse.Templates.Test;

public static class TestBuilderConfig
{
    public static MauiAppBuilder ConfigureTestViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<TestPage>();

        return builder;
    }

    public static MauiAppBuilder ConfigureTestViewsModels(this MauiAppBuilder builder)
    {
        // template
        // builder.Services.AddSingleton<...ViewModel>();
        builder.Services.AddSingleton<TestViewModel>();

        return builder;
    }
}
