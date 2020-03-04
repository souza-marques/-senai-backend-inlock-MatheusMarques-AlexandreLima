using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudiosRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-PMKAL0V7\\SQLEXPRESS; initial catalog=InLock_Games_Manha; integrated security=true";

        public List<EstudiosDomain> Listar()
        {
            List<EstudiosDomain> estudios = new List<EstudiosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudios";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.HasRows)
                    {
                        EstudiosDomain estudio = new EstudiosDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            NomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        estudios.Add(estudio);
                    }
                }
            }

            return estudios;
        }
    }
}
