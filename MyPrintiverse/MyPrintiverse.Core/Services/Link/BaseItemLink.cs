﻿

using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.Core.Services.Link;

public abstract class BaseItemLink<T> : ILink<T>
{
    protected string BasePath { get; set; }
    public BaseItemLink(IConfigService<Config> configService)
    {
        BasePath = $"{configService.Config.Api.FullPath}/api/v1/{typeof(T).Name}s";
    }

    #region Add
    public string AddItem() => BasePath;
    #endregion

    #region Delete
    public string DeleteItem(string id) => $"{BasePath}/{id}";
    public string DeleteItems() => BasePath;
    #endregion

    #region Get
    public string GetItem(string id) => $"{BasePath}/{id}";
    public string GetItems() => BasePath;
    #endregion

    #region Update
    public string UpdateItem(string id) => $"{BasePath}/{id}";
    #endregion
}