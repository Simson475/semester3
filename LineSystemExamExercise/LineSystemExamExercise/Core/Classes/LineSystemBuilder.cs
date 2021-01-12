using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    /// <summary>
    /// a class that can build line systems
    /// </summary>
    public class LineSystemBuilder
    {
        /// <summary>
        /// Builds a line system with txtlogger, an imported user database and an imported product catalog.
        /// </summary>
        /// <returns>the built line system</returns>
        public LineSystem Build()
        {
            LineSystem lineSystem = new LineSystem();
            _ = new TxtLogger(lineSystem);
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
