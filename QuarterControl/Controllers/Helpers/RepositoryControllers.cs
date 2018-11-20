using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuarterControl.Models.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterControl.Controllers.Helpers
{
    public class RepositoryControllers : Controller
    {
        /// <summary>
        /// Este método obtiene el contexto para luego obtener el connectionString correspondiente
        /// </summary>
        private readonly QuarterControlDBContext _context;
        public RepositoryControllers(QuarterControlDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Este método obtiene un objeto Repository a través de un codbar,
        /// para ello utiliza el Stored Procedure QC_getGarron
        /// </summary>
        /// <param name="codbar">Parámetro de tipo string que se refiere al codbar del garrón</param>
        /// <returns>Objeto Repository con la información del garrón pickeado</returns>
        public Repository GetInformation(string codbar)
        {
            string connStr =  _context.Database.GetDbConnection().ConnectionString;
            Repository rep = new Repository();
            string storeProcedure = "QC_getGarron";
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(storeProcedure, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@codbar", SqlDbType.VarChar);
                cmd.Parameters["@codbar"].Value = codbar;

                try
                {
                    conn.Open();
                    System.Diagnostics.Debug.WriteLine(cmd.CommandText);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();

                    rep.GarronId = (int)rdr["GarronId"];
                    rep.GarronNro = (int)rdr["GarronNro"];
                    rep.TropaId = (int)rdr["TropaId"];
                    rep.TropaNro = (int)rdr["TropaNro"];
                    rep.Calificacion = (string)rdr["Calificacion"];

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                
            }
                return rep;
        }
    }
}
