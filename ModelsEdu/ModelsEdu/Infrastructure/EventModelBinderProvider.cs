﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelsEdu.Models;

namespace ModelsEdu.Infrastructure
{
    public class EventModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder binder = new EventModelBinder();
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Event) ? binder : null;
        }
    }
}
