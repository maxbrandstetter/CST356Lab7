﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_2.Startup))]
namespace Lab_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
