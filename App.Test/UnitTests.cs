using App.Controller;
using App.Data;
using App.View;
using System.Text.Json;
using Moq;
namespace App.Test
{
    [TestFixture]
    public class UnitTests
    {
        private readonly CVEs _data = new();
        private string _jsonText;
        private JsonDocument _docJson;
        private Mock<CVEManagement> _fakeResponse;
        private Cve _fakeObject;

        /* Inicia las variables antes de la ejecución de los test*/
        [SetUp]
        public void Setup()
        {
            _data.CveList.Add(new Cve("ID", "Souce", "Published", "LastModified", "VulnStaus", "Description", 0));
            _jsonText = """
                   {
                  "resultsPerPage": 1,
                  "startIndex": 0,
                  "totalResults": 1,
                  "format": "NVD_CVE",
                  "version": "2.0",
                  "timestamp": "2025-02-14T10:32:36.870",
                  "vulnerabilities": [
                    {
                      "cve": {
                        "id": "CVE-2019-1010218",
                        "sourceIdentifier": "josh@bress.net",
                        "published": "2019-07-22T18:15:10.917",
                        "lastModified": "2024-11-21T04:18:03.857",
                        "vulnStatus": "Modified",
                        "cveTags": [],
                        "descriptions": [
                          {
                            "lang": "en",
                            "value": "Cherokee Webserver Latest Cherokee Web server Upto Version 1.2.103 (Current stable) is affected by: Buffer Overflow - CWE-120. The impact is: Crash. The component is: Main cherokee command. The attack vector is: Overwrite argv[0] to an insane length with execl. The fixed version is: There's no fix yet."
                          },
                          {
                            "lang": "es",
                            "value": "El servidor web de Cherokee más reciente de Cherokee Webserver Hasta Versión 1.2.103 (estable actual) está afectado por: Desbordamiento de Búfer - CWE-120. El impacto es: Bloqueo. El componente es: Comando cherokee principal. El vector de ataque es: Sobrescribir argv[0] en una longitud no sana con execl. La versión corregida es: no hay ninguna solución aún."
                          }
                        ],
                        "metrics": {
                          "cvssMetricV31": [
                            {
                              "source": "nvd@nist.gov",
                              "type": "Primary",
                              "cvssData": {
                                "version": "3.1",
                                "vectorString": "CVSS:3.1/AV:N/AC:L/PR:N/UI:N/S:U/C:N/I:N/A:H",
                                "baseScore": 7.5,
                                "baseSeverity": "HIGH",
                                "attackVector": "NETWORK",
                                "attackComplexity": "LOW",
                                "privilegesRequired": "NONE",
                                "userInteraction": "NONE",
                                "scope": "UNCHANGED",
                                "confidentialityImpact": "NONE",
                                "integrityImpact": "NONE",
                                "availabilityImpact": "HIGH"
                              },
                              "exploitabilityScore": 3.9,
                              "impactScore": 3.6
                            }
                          ],
                          "cvssMetricV2": [
                            {
                              "source": "nvd@nist.gov",
                              "type": "Primary",
                              "cvssData": {
                                "version": "2.0",
                                "vectorString": "AV:N/AC:L/Au:N/C:N/I:N/A:P",
                                "baseScore": 5,
                                "accessVector": "NETWORK",
                                "accessComplexity": "LOW",
                                "authentication": "NONE",
                                "confidentialityImpact": "NONE",
                                "integrityImpact": "NONE",
                                "availabilityImpact": "PARTIAL"
                              },
                              "baseSeverity": "MEDIUM",
                              "exploitabilityScore": 10,
                              "impactScore": 2.9,
                              "acInsufInfo": false,
                              "obtainAllPrivilege": false,
                              "obtainUserPrivilege": false,
                              "obtainOtherPrivilege": false,
                              "userInteractionRequired": false
                            }
                          ]
                        },
                        "weaknesses": [
                          {
                            "source": "josh@bress.net",
                            "type": "Secondary",
                            "description": [
                              {
                                "lang": "en",
                                "value": "CWE-120"
                              }
                            ]
                          },
                          {
                            "source": "nvd@nist.gov",
                            "type": "Primary",
                            "description": [
                              {
                                "lang": "en",
                                "value": "CWE-787"
                              }
                            ]
                          }
                        ],
                        "configurations": [
                          {
                            "nodes": [
                              {
                                "operator": "OR",
                                "negate": false,
                                "cpeMatch": [
                                  {
                                    "vulnerable": true,
                                    "criteria": "cpe:2.3:a:cherokee-project:cherokee_web_server:*:*:*:*:*:*:*:*",
                                    "versionEndIncluding": "1.2.103",
                                    "matchCriteriaId": "DCE1E311-F9E5-4752-9F51-D5DA78B7BBFA"
                                  }
                                ]
                              }
                            ]
                          }
                        ],
                        "references": [
                          {
                            "url": "https://i.imgur.com/PWCCyir.png",
                            "source": "josh@bress.net",
                            "tags": [
                              "Exploit",
                              "Third Party Advisory"
                            ]
                          },
                          {
                            "url": "https://i.imgur.com/PWCCyir.png",
                            "source": "af854a3a-2127-422b-91ae-364da2661108",
                            "tags": [
                              "Exploit",
                              "Third Party Advisory"
                            ]
                          }
                        ]
                      }
                    }
                  ]
                }
                """;
            _docJson = JsonDocument.Parse(_jsonText);
            _fakeResponse = new Mock<CVEManagement>();
            _fakeResponse.Setup(client => client.GetCVEInfo(It.IsAny<string>())).ReturnsAsync(_docJson);
            _fakeObject = new Cve(
                "CVE-2019-1010218",
                "josh@bress.net",
                "2019-07-22T18:15:10.917",
                "2024-11-21T04:18:03.857",
                "Modified",
                "El servidor web de Cherokee más reciente de Cherokee Webserver Hasta Versión 1.2.103 (estable actual) está afectado por: Desbordamiento de Búfer - CWE-120. El impacto es: Bloqueo. El componente es: Comando cherokee principal. El vector de ataque es: Sobrescribir argv[0] en una longitud no sana con execl. La versión corregida es: no hay ninguna solución aún.",
                5f
            );
        }

        /* Limpia las variables despues de la ejecución de cada test*/
        [TearDown]
        public void TearDown()
        {
            _docJson.Dispose();
        }

        /*TEST MODEL*/

        /* Test que comprueba si algun parametro del ejemplo de Datos esta vacio usando Assert.Fail/Assert.Pass*/
        [Test]
        public void TestModelTesting()
        {
            if (_data.CveList[0].CheckCVE())
            {
                Assert.Pass();
            }
        }
        /* Test que comprueba si algun parametro del ejemplo de Datos esta vacio usando Assert.IsTrue/Assert.IsFalse */
        [Test]
        public void TestModelTesting2()
        {
            Assert.IsTrue(_data.CveList[0].CheckCVE());
        }

        /*TEST VIEW*/

        /*Este Test comprueba si el codigo que convierte el Json a la tabla es correcto, solo el codigo, no la conexion*/

        [Test]
        public async Task TestMockAPICode()
        {   
            Form form1 = new Form();
            form1.cveManagement = _fakeResponse.Object;
            Assert.That(await form1.GetCVEs(), Is.EqualTo("Successful"));
        }

        [Test]
        public void TestBuildDataView()
        {
            Form form1 = new Form();
            Assert.That(form1.BuildDataView(_docJson), Is.EqualTo("Successful"));
        }

        /*TEST CONTROLLER*/

        [Test]
        public void TestNullFormatCVE()
        {
            Assert.Throws<NullReferenceException>(() => { CVEManagement.FormatJSONCVEs(null); });
        }

        [Test]
        public void TestCorrectFormatCVE()
        {
            Assert.That(CVEManagement.FormatJSONCVEs(_docJson).CveList[0].ToString(), Is.EqualTo(_fakeObject.ToString()));
        }

    }
}