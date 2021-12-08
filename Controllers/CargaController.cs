using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuntosVerdes.Managers;
using PuntosVerdes.Models;
using PuntosVerdes.ModelsCSV;
using Newtonsoft.Json.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PuntosVerdes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargaController : ControllerBase
    {
        private readonly CooperativaManager _cooperativaManager;
        private readonly BarrioManager _barrioManager;
        private readonly ComunaManager _comunaManager;
        private readonly MaterialManager _materialManager;
        private readonly PuntoVerdeManager _puntoVerdeManager;
        private readonly PuntoVerdeMaterialesManager _puntoVerdeMaterialesManager;
        private readonly RecoleccionMaterialesManager _recoleccionMaterialesManager;
        private readonly VisitasManager _visitasManager;
        public CargaController(
            CooperativaManager cooperativaManager,
            BarrioManager barrioManager,
            ComunaManager comunaManager,
            MaterialManager materialManager,
            PuntoVerdeManager puntoVerdeManager,
            PuntoVerdeMaterialesManager puntoVerdeMaterialesManager,
            RecoleccionMaterialesManager recoleccionMaterialesManager,
            VisitasManager visitasManager
            )
        {
            _barrioManager = barrioManager;
            _comunaManager = comunaManager;
            _cooperativaManager = cooperativaManager;
            _materialManager = materialManager;
            _puntoVerdeManager = puntoVerdeManager;
            _puntoVerdeMaterialesManager = puntoVerdeMaterialesManager;
            _recoleccionMaterialesManager = recoleccionMaterialesManager;
            _visitasManager = visitasManager;
        }
        // GET: api/<ComunaController>
        [HttpGet]
        public async Task<ActionResult<List<Cooperativa>>> Get()
        {
            return await _cooperativaManager.GetAllAsync();
        }
        /*
        // GET api/<ComunaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/
        // POST api/<ComunaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] IFormFile file)
        {
            if (file.FileName.EndsWith(".csv"))
            {
                using TextReader sreader = new StreamReader(file.OpenReadStream());
                var csvReader = new CsvReader(sreader, CultureInfo.InvariantCulture);
                var records = csvReader.GetRecords<UbicacionPuntosVerdes>();
                List<JObject> jPesages = new List<JObject>();
                foreach (var record in records)
                {
                    var sName = record.Barrio.Trim();
                    var barrioDB = await _barrioManager.GetByNameAsync(sName);
                    
                    sName = record.Comuna.Trim();
                    var comunaDB = await _comunaManager.GetByNameAsync(sName);

                    sName = record.Cooperativ.Trim();
                    var cooperativaDB = await _cooperativaManager.GetByNameAsync(sName);
                    var aCoords = record.Wkt.Replace("POINT (", "").Replace(")", "").Split(" ");
                    
                    var punto = new PuntoVerde
                    {
                        Nombre = record.Nombre_punto.Trim(),
                        Codigo = record.Id.Trim(),
                        Latitud = float.Parse(aCoords[1]),
                        Longitud = float.Parse(aCoords[0]),
                        Calle = record.Calle,
                        Calle2 = record.Calle2,
                        BarrioId = barrioDB.Id,
                        CooperativaId = cooperativaDB.Id,
                        ComunaId = comunaDB.Id,
                        Tipo = record.Tipo
                    };
                    punto.Id = await _puntoVerdeManager.AddAsync(punto);
                    var materiales = record.Materiales.Split('/');
                    foreach (var material in materiales)
                    {
                        var sMaterial = material.Trim();
                        var materialDB = await _materialManager.GetByNameAsync(sMaterial);
                        await _puntoVerdeMaterialesManager.AddAsync(new PuntoverdeMateriales { 
                            MaterialId = materialDB.Id,
                            PuntoVerdeId = punto.Id
                        });
                    }

                }
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        // POST api/<ComunaController>
        [HttpPost("pesaje")]
        public async Task<ActionResult> Pesaje([FromForm] IFormFile file)
        {
            if (file.FileName.EndsWith(".csv"))
            {
                using TextReader sreader = new StreamReader(file.OpenReadStream());
                var csvReader = new CsvReader(sreader, CultureInfo.InvariantCulture);
                var records = csvReader.GetRecords<Pesaje>();
                List<JObject> jPesages = new List<JObject>();
                foreach (var record in records)
                {
                    var pv = await _puntoVerdeManager.GetByNameAsync(record.Punto);
                    var Vidrio = await _recoleccionMaterialesManager.GetByPvYearMonthMaterial(pv.Id, record.Anio, record.Mes, 6);
                    var PapelCarton = await _recoleccionMaterialesManager.GetByPvYearMonthMaterial(pv.Id, record.Anio, record.Mes, 12);
                    var Metal = await _recoleccionMaterialesManager.GetByPvYearMonthMaterial(pv.Id, record.Anio, record.Mes, 7);
                    var Plastico = await _recoleccionMaterialesManager.GetByPvYearMonthMaterial(pv.Id, record.Anio, record.Mes, 8);
                    var Telgopor = await _recoleccionMaterialesManager.GetByPvYearMonthMaterial(pv.Id, record.Anio, record.Mes, 10);
                    var PlasticosMas = await _recoleccionMaterialesManager.GetByPvYearMonthMaterial(pv.Id, record.Anio, record.Mes, 13);
                    var Tetra_brick = await _recoleccionMaterialesManager.GetByPvYearMonthMaterial(pv.Id, record.Anio, record.Mes, 9);
                    var Pequenios_elec = await _recoleccionMaterialesManager.GetByPvYearMonthMaterial(pv.Id, record.Anio, record.Mes, 14);
                    var Elect_uso = await _recoleccionMaterialesManager.GetByPvYearMonthMaterial(pv.Id, record.Anio, record.Mes, 15);
                    if (Vidrio == null)
                    {
                        await _recoleccionMaterialesManager.AddAsync(new RecoleccionMateriales
                        {
                            Anio = record.Anio,
                            Mes = record.Mes,
                            Pesaje = record.Vidrio,
                            PuntoVerdeId = pv.Id,
                            MaterialId = 6
                        });
                    } 
                    else
                    {
                        Vidrio.Pesaje += record.Vidrio;
                        _recoleccionMaterialesManager.Update(Vidrio);
                    }

                    if (PapelCarton == null)
                    {
                        await _recoleccionMaterialesManager.AddAsync(new RecoleccionMateriales
                        {
                            Anio = record.Anio,
                            Mes = record.Mes,
                            Pesaje = record.PapelCarton,
                            PuntoVerdeId = pv.Id,
                            MaterialId = 12
                        });
                    }
                    else
                    {
                        PapelCarton.Pesaje += record.PapelCarton;
                        _recoleccionMaterialesManager.Update(PapelCarton);
                    }

                    if (Metal == null)
                    {
                        await _recoleccionMaterialesManager.AddAsync(new RecoleccionMateriales
                        {
                            Anio = record.Anio,
                            Mes = record.Mes,
                            Pesaje = record.Metal,
                            PuntoVerdeId = pv.Id,
                            MaterialId = 7
                        });
                    }
                    else
                    {
                        Metal.Pesaje += record.Metal;
                        _recoleccionMaterialesManager.Update(Metal);
                    }

                    if (Plastico == null)
                    {
                        await _recoleccionMaterialesManager.AddAsync(new RecoleccionMateriales
                        {
                            Anio = record.Anio,
                            Mes = record.Mes,
                            Pesaje = record.Plastico,
                            PuntoVerdeId = pv.Id,
                            MaterialId = 8
                        });
                    }
                    else
                    {
                        Plastico.Pesaje += record.Plastico;
                        _recoleccionMaterialesManager.Update(Plastico);
                    }

                    if (Telgopor == null)
                    {
                        await _recoleccionMaterialesManager.AddAsync(new RecoleccionMateriales
                        {
                            Anio = record.Anio,
                            Mes = record.Mes,
                            Pesaje = record.Telgopor,
                            PuntoVerdeId = pv.Id,
                            MaterialId = 10
                        });
                    }
                    else
                    {
                        Telgopor.Pesaje += record.Telgopor;
                        _recoleccionMaterialesManager.Update(Telgopor);
                    }

                    if (PlasticosMas == null)
                    {
                        await _recoleccionMaterialesManager.AddAsync(new RecoleccionMateriales
                        {
                            Anio = record.Anio,
                            Mes = record.Mes,
                            Pesaje = record.PlasticosMas,
                            PuntoVerdeId = pv.Id,
                            MaterialId = 13
                        });
                    }
                    else
                    {
                        PlasticosMas.Pesaje += record.PlasticosMas;
                        _recoleccionMaterialesManager.Update(PlasticosMas);
                    }

                    if (Tetra_brick == null)
                    {
                        await _recoleccionMaterialesManager.AddAsync(new RecoleccionMateriales
                        {
                            Anio = record.Anio,
                            Mes = record.Mes,
                            Pesaje = record.Tetra_brick,
                            PuntoVerdeId = pv.Id,
                            MaterialId = 9
                        });
                    }
                    else
                    {
                        Tetra_brick.Pesaje += record.Tetra_brick;
                        _recoleccionMaterialesManager.Update(Tetra_brick);
                    }

                    if (Pequenios_elec == null)
                    {
                        await _recoleccionMaterialesManager.AddAsync(new RecoleccionMateriales
                        {
                            Anio = record.Anio,
                            Mes = record.Mes,
                            Pesaje = record.Pequenios_elec,
                            PuntoVerdeId = pv.Id,
                            MaterialId = 14
                        });
                    }
                    else
                    {
                        Pequenios_elec.Pesaje += record.Pequenios_elec;
                        _recoleccionMaterialesManager.Update(Pequenios_elec);
                    }

                    if (Elect_uso == null)
                    {
                        await _recoleccionMaterialesManager.AddAsync(new RecoleccionMateriales
                        {
                            Anio = record.Anio,
                            Mes = record.Mes,
                            Pesaje = record.Elect_uso,
                            PuntoVerdeId = pv.Id,
                            MaterialId = 15
                        });
                    }
                    else
                    {
                        Elect_uso.Pesaje += record.Elect_uso;
                        _recoleccionMaterialesManager.Update(Elect_uso);
                    }
                }
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        // POST api/<ComunaController>
        [HttpPost("visitas")]
        public async Task<ActionResult> Visitas([FromForm] IFormFile file)
        {
            if (file.FileName.EndsWith(".csv"))
            {
                using TextReader sreader = new StreamReader(file.OpenReadStream());
                var csvReader = new CsvReader(sreader, CultureInfo.InvariantCulture);
                var records = csvReader.GetRecords<VisitasCsv>();
                List<JObject> jPesages = new List<JObject>();
                foreach (var record in records)
                {
                    var pv = await _puntoVerdeManager.GetByNameAsync(record.Punto);
                    if (pv != null)
                    {
                        var visita = await _visitasManager.GetByPvYearMonth(pv.Id, record.Anio, record.Mes);
                        if (visita == null)
                        {
                            await _visitasManager.AddAsync(new Visitas
                            {
                                Anio = record.Anio,
                                Mes = record.Mes,
                                Cantidad = record.Visitas,
                                PuntoVerdeId = pv.Id
                            });
                        }
                        else
                        {
                            visita.Cantidad += record.Visitas;
                            _visitasManager.Update(visita);
                        }
                    }
                }
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
