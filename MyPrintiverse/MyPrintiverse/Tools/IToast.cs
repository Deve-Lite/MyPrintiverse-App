﻿
using CommunityToolkit.Maui.Core;
namespace MyPrintiverse.Tools;

internal interface IToast
{
    public Task Toast(string message, ToastDuration duration = ToastDuration.Short, double fontSize = 14);
}
