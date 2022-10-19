using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace _211086.Model
{
    public class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

      
    }
    private void Incluir()
    {
        try
        {
            Banco.AbrirConexao();
            Banco.Comando = new MySqlCommand("INSERT INTO cidades (nome, uf) VALUES (@nome, @uf)", Banco.Conexao);
            Banco.Comando.Parameters.AddWithValue("@nome", nome);
            Banco.Comando.Parameters.AddWithValue("@uf", uf);

            Banco.Comando.ExecuteNonQuery();
            Banco.FecharConexao();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void Alterar()
    {
        try
        {
            Banco.AbrirConexao();
            Banco.Comando = new MySqlCommand("Update cidades set nome = @nome, uf = @uf where id = @id", Banco.Conexao);
            Banco.Comando.Parameters.AddWithValue("@nome", nome);
            Banco.Comando.Parameters.AddWithValue("@uf", uf);
            Banco.Comando.Parameters.AddWithValue("@id", id);

            Banco.Comando.ExecuteNonQuery();
            Banco.FecharConexao();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void Excluir()
    {
        try
        {
            Banco.AbrirConexao();
            Banco.Comando = new MySqlCommand("delete from cidade where id = @id", Banco.Conexao);
            Banco.Comando.Parameters.AddWithValue("@id", id);

            Banco.Comando.ExecuteNonQuery();
            Banco.FecharConexao();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public DataTable Consultar()
    {
        try
        {
            Banco.AbrirConexao();
            Banco.Comando = new MySqlCommand("SELECT * FROM cidade where nome like @nome" + "order by nome" , Banco.Conexao);
            Banco.Comando.Parameters.AddWithValue("@nome", nome + "%");
            Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
            Banco.datTabela = new DataTable();
            Banco.Adaptador.Fill(Banco.datTabela);

            Banco.FecharConexao();
            return Banco.datTabela;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
