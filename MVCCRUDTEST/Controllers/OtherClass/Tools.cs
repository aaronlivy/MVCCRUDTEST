using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nelibur.ObjectMapper;
using Nelibur.ObjectMapper.Bindings;

namespace MVCCRUDTEST
{
    public class Tools
    {
        public static T2 TinyMapperTools<T1, T2>(T1 origin)
        {
            if (!TinyMapper.BindingExists<T1, T2>())
                TinyMapper.Bind<T1, T2>();
            T2 Result = TinyMapper.Map<T2>(origin);
            return Result;
        }

        public static T2 TinyMapperTools<T1, T2>(T1 origin, Action<IBindingConfig<T1, T2>> config)
        {
            if (!TinyMapper.BindingExists<T1, T2>())
                TinyMapper.Bind<T1, T2>(config);

            T2 Result = TinyMapper.Map<T2>(origin);
            return Result;
        }
    }
}