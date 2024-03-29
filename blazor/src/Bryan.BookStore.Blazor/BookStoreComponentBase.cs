﻿using Bryan.BookStore.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Bryan.BookStore.Blazor;

public abstract class BookStoreComponentBase : AbpComponentBase
{
    protected BookStoreComponentBase()
    {
        LocalizationResource = typeof(BookStoreResource);
    }
}
