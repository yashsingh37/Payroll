﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayRoll_Practies_Exam_2.Startup))]
namespace PayRoll_Practies_Exam_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
