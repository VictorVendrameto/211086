using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211086.Model
{
    internal class Clientes
    {
        public int id { get; set; }
        public int id_cidade { get; set; }
        public string nome { get; set; }
        public DateTime data_nasc { get; set; }
        public double renda { get; set; }
        public string cpf { get; set; }
        public string foto { get; set; }
        public bool venda { get; set; }

        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("INSERT INTO Clientes (id_cidade, nome, data_nasc, renda, foto, venda" +
                    " VALUES (@id_cidade, @nome, @data_nasc, @renda, @foto, @venda", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@id_cidade", id_cidade);
                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@data_nasc", data_nasc);
                Banco.Comando.Parameters.AddWithValue("@renda", renda);
                Banco.Comando.Parameters.AddWithValue("@foto",foto);
                Banco.Comando.Parameters.AddWithValue("@venda", venda);
                
                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("UPDATE Clientes SET id_cidade=@id_cidade, nome=@nome, data_nasc=@data_nasc," +
                                                    "renda=@renda, cpf=@cpf, foto=@foto, venda=@venda WHERE id=@id", Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@id_cidade", id_cidade);
                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@data_nasc", data_nasc);
                Banco.Comando.Parameters.AddWithValue("@renda", renda);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.Parameters.AddWithValue("@venda", venda);
                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                Banco.AbrirConexao();

                Banco.Comando = new MySqlCommand("DELETE FROM Clientes WHERE id=@id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }
            catch
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("SELECT cl.*, ci.nome AS Cidades, ci.uf " +
                                                    "FROM Clientes cl" + 
                                                    "JOIN Cidades ci ON (cl.id_cidade= ci.id)" + 
                                                    "WHERE cl.nome LIKE ?Nome ORDER BY cl.nome",
                                                    Banco.Conexao);

                Banco.Comando.Parameters.AddWithValue("@nome", nome + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);

                Banco.FecharConexao();
                return Banco.datTabela;
            }
            catch
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
