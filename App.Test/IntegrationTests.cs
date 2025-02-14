using App.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Test
{
    internal class IntegrationTests
    {
        /*TEST INTEGRACION*/

        /*Este Test comprueba la conexion con la API*/

        [Test]
        public async Task TestAPIConnection()
        {
            CVEManagement cveManagement = new CVEManagement();
            Assert.That(await cveManagement.GetCVEInfo("WordPress"), Is.Not.Null);
        }
    }
}
