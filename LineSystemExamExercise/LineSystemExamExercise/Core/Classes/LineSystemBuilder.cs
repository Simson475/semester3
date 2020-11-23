using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class LineSystemBuilder//TODO test
    {
        public LineSystem Build()
        {
            LineSystem lineSystem = new LineSystem();
            UserDatabase userDatabase = new UserDatabase();
            userDatabase.ImportUsers();
            ProductCatalog productCatalog = new ProductCatalog();
            productCatalog.ImportCSVfile();
            lineSystem.CurrentProductCatalog = productCatalog;
            lineSystem.CurrentUserDatabase = userDatabase;
            return lineSystem;
        }
    }
}
