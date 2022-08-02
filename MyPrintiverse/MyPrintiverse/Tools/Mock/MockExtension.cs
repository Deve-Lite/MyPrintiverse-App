

namespace MyPrintiverse.Tools.Mock;

public static class MockExtension
{
    public static MauiAppBuilder ConfigureMockServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<FilamentMock>();
        builder.Services.AddSingleton<FilamentTypeMock>();

        return builder;
    }
}
