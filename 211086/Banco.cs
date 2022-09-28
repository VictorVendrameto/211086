using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace _211086
{
    public class Banco
    {
        //criando as variaveis publicas para a conexão e consulta serao usadas em todo o projeto
        //Connection responsavel pela conexão com o MySql
        public static MySqlConnection Conexao;
        
        //command responsavel pelas instruções SQL a serem executadas;
        public static MySqlCommand Comando;

        //Adapter responsavel por inserir dados em um datatable
        public static MySqlDataAdapter Adaptador;

        //DataTable responsavel por ligar o banco em controles com a propriedade DataSource
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                //estabelece os parametros para a conexao com o Banco
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                //Abre a conexao com o banco de dados
                Conexao.Open();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            }
        /// 
        /// 
        ///
        public static void FecharConexao()
        {
            try
            {
                //Fecha conexao com o banco de dados
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                //Chama a funçao para abertura de conexao com o banco
                AbrirConexao();

                //Informa a instruçao SQL
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE venda", Conexao);

                //Executa o Query no MySQL (Raio do workbench)
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades " +
                                            "(id integer auto_increment primary key, " +
                                            "nome char(40)," +
                                            "uf char(02)", Conexao);

                //Chama a funçao para fechar a conexao com o banco
                FecharConexao();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
