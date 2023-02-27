using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ClassificacaoCarros.View
{
    internal class Banco
    {

        public static MySqlConnection Conexao;

        public static MySqlCommand Comando;

        public static MySqlDataAdapter Adaptador;

        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
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
                AbrirConexao();

                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS garagem; USE garagem", Conexao);
                Comando.ExecuteNonQuery();


                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Marca " +
                                            "(id integer auto_increment primary key," +
                                            "descricao varchar(100))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Fabricante " +
                                            "(id integer auto_increment primary key," +
                                            "nome VARCHAR(50) NOT NULL," +
                                            "cnpj INT NOT NULL," +
                                            "email VARCHAR(110) NOT NULL)", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Tipo" +
                                          "(id integer auto_increment primary key," +
                                            "descricao varchar(100))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Combustivel" +
                                          "(id integer auto_increment primary key," +
                                            "descricao varchar(100))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Veiculo " +
                                           "(id integer auto_increment primary key," +
                                           "id_marca INT," +
                                           "modelo VARCHAR(45) NOT NULL," +
                                           "id_fabricante INT," +
                                           "id_tipo INT," +
                                           "ano INT NOT NULL," +
                                           "id_combustivel INT," +
                                           "cor VARCHAR(45) NOT NULL," +
                                           "numero_chassi INT NOT NULL," +
                                           "kilometragem INT NOT NULL," +
                                           "revisão TINYINT NULL," +
                                           "sinistro TINYINT NULL," +
                                           "roubo_furto TINYINT NULL," +
                                           "aluguel TINYINT NULL," +
                                           "venda TINYINT NULL," +
                                           "particular TINYINT NULL," +
                                           "obsevacao VARCHAR(150) NULL)", Conexao);
                Comando.ExecuteNonQuery();

                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
