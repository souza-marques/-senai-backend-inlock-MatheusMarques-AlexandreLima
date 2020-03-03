using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-GCOFA7F\\SQLEXPRESS; initial catalog=Peoples; user Id=sa; pwd=sa@132";

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(Nome, Descricao, DataLancamento, Valor, IdEstudio)" +
                                     "VALUES (@Nome, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdJogo, Nome, Descricao, DataLancamento, Valor, Jogos.IdEstudio, Estudios.NomeEstudio FROM Jogos" +
                                        "INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.HasRows)
                    {
                        JogosDomain jogo = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = rdr["Valor"].ToString(),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Estudio = new EstudiosDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };

                        jogos.Add(jogo);
                    }
                }
            }

            return jogos;
        }
    }
}
