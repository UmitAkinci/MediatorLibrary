﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrarySample.CQRS.Queries
{
    public interface IAdessoQuery<out TResponse> : IAdessoRequest<TResponse>
    {
    }
}
