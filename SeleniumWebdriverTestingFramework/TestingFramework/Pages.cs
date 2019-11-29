using System;
using System.Collections.Generic;
using System.Text;

namespace TestingFramework
{
    public static class Pages
    {
        public static HomePage HomePage
        {
            get
            {
                var homePage = new HomePage();
                //PageFactory.InitElements(Browser.Driver, homePage);
                return homePage;
            }
        }
    }
}
